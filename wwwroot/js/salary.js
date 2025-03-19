document.addEventListener("DOMContentLoaded", function () {
    const companyDropdown = document.getElementById("company-dropdown");
    const employeeDropdown = document.getElementById("employee-dropdown");
    const yearDropdown = document.createElement("select");
    const monthDropdown = document.createElement("select");
    const absentDisplay = document.createElement("p"); // Display for total absents
    const salaryTable = document.createElement("table"); // Table for salary details
    const formContainer = document.createElement("div");

    document.body.appendChild(formContainer);
    formContainer.appendChild(yearDropdown);
    formContainer.appendChild(monthDropdown);
    formContainer.appendChild(absentDisplay);
    formContainer.appendChild(salaryTable);

    // Create Salary Table Headers
    salaryTable.innerHTML = `
        <thead>
            <tr>
                <th>Basic Salary</th>
                <th>Absent Amount</th>
                <th>Payable Amount</th>
            </tr>
        </thead>
        <tbody></tbody>
    `;

    function fetchCompanies() {
        fetch("http://localhost:5256/api/company")
            .then(response => response.json())
            .then(data => {
                companyDropdown.innerHTML = `<option value="">-- Select Company --</option>`;
                data.forEach(company => {
                    let option = document.createElement("option");
                    option.value = company.comId;
                    option.textContent = company.comName;
                    companyDropdown.appendChild(option);
                });
            })
            .catch(error => console.error("Error fetching companies:", error));
    }

    function fetchEmployees(companyId) {
        fetch(`http://localhost:5256/api/employee/bycompany?companyId=${companyId}`)
            .then(response => response.json())
            .then(data => {
                employeeDropdown.innerHTML = `<option value="">-- Select Employee --</option>`;
                data.forEach(employee => {
                    let option = document.createElement("option");
                    option.value = employee.empId;
                    option.textContent = employee.empName;
                    employeeDropdown.appendChild(option);
                });
            })
            .catch(error => console.error("Error fetching employees:", error));
    }

    function fetchAttendanceSummary(employeeId) {
        fetch(`http://localhost:5256/api/AttendanceSummary?employeeId=${employeeId}`)
            .then(response => response.json())
            .then(data => {
                const years = new Set();
                const months = new Set();
                const absentsMap = {}; // Store absents using year and month keys

                data.forEach(item => {
                    years.add(item.year);
                    months.add(item.month);
                    absentsMap[`${item.year}-${item.month}`] = item.totalAbsents;
                });

                yearDropdown.innerHTML = '<option value="">-- Select Year --</option>';
                years.forEach(year => {
                    yearDropdown.innerHTML += `<option value="${year}">${year}</option>`;
                });

                monthDropdown.innerHTML = '<option value="">-- Select Month --</option>';
                months.forEach(month => {
                    monthDropdown.innerHTML += `<option value="${month}">${month}</option>`;
                });

                // Listen for year and month selection to display absents and fetch salary data
                function updateAbsentAndSalaryDisplay() {
                    const selectedYear = yearDropdown.value;
                    const selectedMonth = monthDropdown.value;
                    const selectedEmployeeId = employeeDropdown.value;

                    if (selectedYear && selectedMonth) {
                        const key = `${selectedYear}-${selectedMonth}`;
                        const totalAbsents = absentsMap[key] || 0;
                        absentDisplay.textContent = `Total Absents: ${totalAbsents}`;

                        // Fetch and display salary details
                        fetchSalaryDetails(selectedEmployeeId, selectedYear, selectedMonth);
                    } else {
                        absentDisplay.textContent = "";
                        salaryTable.querySelector("tbody").innerHTML = ""; // Clear salary data
                    }
                }

                yearDropdown.addEventListener("change", updateAbsentAndSalaryDisplay);
                monthDropdown.addEventListener("change", updateAbsentAndSalaryDisplay);
            })
            .catch(error => console.error("Error fetching attendance summary:", error));
    }

    function fetchSalaryDetails(employeeId, year, month) {
        fetch(`http://localhost:5256/api/Salary/GetSalary?employeeId=${employeeId}&year=${year}&month=${month}`)
            .then(response => {
                if (!response.ok) {
                    throw new Error("Salary data not found");
                }
                return response.json();
            })
            .then(data => {
                const salaryBody = salaryTable.querySelector("tbody");
                salaryBody.innerHTML = ""; // Clear previous data

                const row = document.createElement("tr");
                row.innerHTML = `
                    <td>${data.basic}</td>
                    <td>${data.absentAmount}</td>
                    <td>${data.payableAmount}</td>
                `;
                salaryBody.appendChild(row);
            })
            .catch(error => {
                console.error("Error fetching salary:", error);
                salaryTable.querySelector("tbody").innerHTML = `<tr><td colspan="3">Salary data not available</td></tr>`;
            });
    }

    companyDropdown.addEventListener("change", function () {
        const selectedCompanyId = companyDropdown.value;
        if (selectedCompanyId) {
            fetchEmployees(selectedCompanyId);
        } else {
            employeeDropdown.innerHTML = `<option value="">-- Select Employee --</option>`;
        }
    });

    employeeDropdown.addEventListener("change", function () {
        const selectedEmployeeId = employeeDropdown.value;
        if (selectedEmployeeId) {
            fetchAttendanceSummary(selectedEmployeeId);
        }
    });

    fetchCompanies();
});
