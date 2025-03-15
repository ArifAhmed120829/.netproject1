document.addEventListener("DOMContentLoaded", function () {
    fetch("http://localhost:5256/api/Employee") // Adjust the URL if needed
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
                         <td>${employee.empName}</td>
                          <td>${employee.gross}</td>
                           <td>${employee.basic}</td>
                            <td>${employee.hRent}</td>
                             <td>${employee.medical}</td>
                              <td>${employee.others}</td>
                        
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

