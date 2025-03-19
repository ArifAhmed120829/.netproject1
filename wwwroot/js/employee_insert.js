const apiUrl2 = "http://localhost:5256/api/Employee";
document.addEventListener("DOMContentLoaded", function () {
    fetch(apiUrl2)
        .then(response => response.json())
        .then(data => {
            console.log("Employee data:", data); // Log the fetched data
            const employeeDropdown = document.getElementById("employeeDropdown");
            // Clear dropdown before inserting new data
            employeeDropdown.innerHTML = `<option value="">-- Select Employee ID --</option>`;
            const tableBody = document.getElementById("employee-table");
            tableBody.innerHTML = ""; // Clear table before inserting new data

            // Ensure data is an array and not empty
            if (Array.isArray(data)) {
                data.forEach(employee => {
                    console.log("Processing Employee:", employee);  // Log each employee to check data structure
                    let row = `<tr>
                        <td>${employee.empId}</td> <!-- Directly use the EmpId value -->
                         <td><input type = "text" value = "${employee.empName}" id = "name-${employee.empId}"></td>
                          <td><input type="number" value="${employee.gross}" id="gross-${employee.empId}"></td>
                           <td><input type="number" value="${employee.basic}" id="basic-${employee.empId}"></td>
                            <td><input type="number" value="${employee.hRent}" id = "hRent-${employee.empId}"></td>
                               <td><input type="number" value="${employee.medical}" id = "medical-${employee.empId}"></td>
                                  <td><input type="number" value="${employee.others}" id = "others-${employee.empId}"></td>
                          
                              <td>
                              <button onclick="updateEmployee(${employee.empId})">Edit</button>
                              <button onclick="deleteEmployee(${employee.empId})" style="color: red;">Delete</button>
                              </td>
                        
                    </tr>`;
                    let option = document.createElement("option");
                    option.value = employee.empId;  // Use empId as value
                    option.textContent = employee.empId;  // Display empId in the dropdown
                    employeeDropdown.appendChild(option);
                    tableBody.innerHTML += row;
                });
            } else {
                console.error("Received data is not an array:", data);
            }
        })
        .catch(error => {
            console.error("Error fetching data:", error);
        });
});

// Listen for changes in the dropdown selection
document.getElementById("employeeDropdown").addEventListener("change", function () {
    const empId = this.value;  // Get selected Employee ID

    if (empId) {
        // Fetch detailed employee information for the selected ID
        fetch(`http://localhost:5256/api/Employee/${empId}`)
            .then(response => response.json())
            .then(data => {
                // Display employee details
                document.getElementById("employeeDetails").style.display = "block";  // Show details section

                // Fill in the details
                document.getElementById("empDept").textContent = `Department: ${data.department}`;
                document.getElementById("empDesig").textContent = `Designation: ${data.designation}`;
                document.getElementById("empShift").textContent = `Shift: ${data.shiftIn} - ${data.shiftOut}`;
                document.getElementById("empCompany").textContent = `Company: ${data.company}`;
                document.getElementById("empOthers").textContent = `Others: ${data.others}`;
            })
            .catch(error => {
                console.error("Error fetching employee details:", error);
            });
    } else {
        // Hide details if no employee is selected
        document.getElementById("employeeDetails").style.display = "none";
    }
});

//New section for updating and deleting employee

// � Edit (Update) Employee
async function updateEmployee(employeeId) {
    const updatedEmployee = {
        empId: employeeId,
        empName: document.getElementById(`name-${employeeId}`).value,
        gross: parseInt(document.getElementById(`gross-${employeeId}`).value),
        basic: parseInt(document.getElementById(`basic-${employeeId}`).value),
        hRent: parseInt(document.getElementById(`hRent-${employeeId}`).value),
        medical: parseInt(document.getElementById(`medical-${employeeId}`).value),
        others: parseInt(document.getElementById(`others-${employeeId}`).value)
        
    };

    try {
        const response = await fetch(`${apiUrl2}/${employeeId}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(updatedEmployee)
        });

        if (response.ok) {
            alert("Company updated successfully!");
        } else {
            alert("Failed to update company.");
        }
    } catch (error) {
        console.error("Error updating company:", error);
    }
}

// � Delete Employee
async function deleteEmployee(employeeId) {
    if (!confirm("Are you sure you want to delete this employee?")) return;

    try {
        const response = await fetch(`${apiUrl2}/${employeeId}`, {
            method: "DELETE"
        });

        if (response.ok) {
            alert("Company deleted successfully!");
        } else {
            alert("Failed to delete company.");
        }
    } catch (error) {
        console.error("Error deleting company:", error);
    }
}