document.addEventListener("DOMContentLoaded", function () {
    const companyDropdown = document.getElementById("company-dropdown");
    const employeeDropdown = document.getElementById("employee-dropdown");
    const attendanceSummaryTable = document.getElementById('attendance-summary-table').getElementsByTagName('tbody')[0];
    // Create attendance input fields dynamically
    const formContainer = document.createElement("div");
    formContainer.innerHTML = `
        <h2>Submit Attendance</h2>
        <label for="date">Date:</label>
        <input type="date" id="date" required>

        <label for="intime">In Time:</label>
        <input type="time" id="intime">

        <label for="outtime">Out Time:</label>
        <input type="time" id="outtime">

        <button id="submit-attendance">Submit Attendance</button>
    `;
    document.body.appendChild(formContainer); // Add form to the page
    const submitAttendanceBtn = document.getElementById("submit-attendance");
    
    // Fetch Companies
    function fetchCompanies() {
        fetch("http://localhost:5256/api/company") // Update URL if needed
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

    // Fetch Employees Based on Selected Company
    function fetchEmployees(companyId) {
        fetch(`http://localhost:5256/api/employee/bycompany?companyId=${companyId}`)  // ✅ Correct URL
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }
                return response.json();
            })
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


    // Listen for Company Selection Change
    companyDropdown.addEventListener("change", function () {
        const selectedCompanyId = companyDropdown.value;
        if (selectedCompanyId) {
            fetchEmployees(selectedCompanyId);
        } else {
            employeeDropdown.innerHTML = `<option value="">-- Select Employee --</option>`;
        }
    });

    // Fetch attendance summary for selected employee
    function fetchAttendanceSummary(employeeId) {
        fetch(`http://localhost:5256/api/AttendanceSummary?employeeId=${employeeId}`)
            .then(response => response.json())
            .then(data => {
                // Clear the table before adding new data
                attendanceSummaryTable.innerHTML = "";

                data.forEach(item => {
                    const row = document.createElement("tr");
                    row.innerHTML = `
                        <td>${item.year}</td>
                        <td>${item.month}</td>
                        <td>${item.totalAbsents}</td>
                    `;
                    attendanceSummaryTable.appendChild(row);
                });
            })
            .catch(error => {
                console.error("Error fetching attendance summary:", error);
            });
    }
    // Submit Attendance Data
    submitAttendanceBtn.addEventListener("click", function () {
        const selectedCompanyId = companyDropdown.value;
        const employeeId = employeeDropdown.value;
        const date = document.getElementById("date").value;
        const intime = document.getElementById("intime").value || null;
        const outtime = document.getElementById("outtime").value || null;

        if (!employeeId || !date) {
            alert("Please select an employee and enter a date.");
            return;
        }

        fetch("http://localhost:5256/api/Attendance", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({
                ComId: selectedCompanyId,
                EmpId: employeeId,
                Date: date,
                Intime: intime,
                Outtime: outtime
            })
        })
            .then(response => {
                if (!response.ok) throw new Error("Failed to insert attendance data");
                return response.json();
            })
            .then(() => {
                fetchAttendanceSummary(employeeId); // Refresh summary after inserting
            })
            .catch(error => console.error("Error:", error));
    });


    // Initialize Company Dropdown
    fetchCompanies();
});