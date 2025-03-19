const apiUrl = "http://localhost:5256/api/company";
let table;

document.addEventListener("DOMContentLoaded", function () {
    // Initialize Tabulator
    table = new Tabulator("#company-table", {
        layout: "fitColumns",
        pagination: "local",
        paginationSize: 20,
        columns: [
            { title: "Company ID", field: "comId", sorter: "number", width: 100 },
            { title: "Name", field: "comName", sorter: "string",
                formatter: function(cell) {
                    let value = cell.getValue();
                    let id = cell.getRow().getData().comId;
                    return `<input type="text" id="name-${id}" value="${value}">`;
                }
            },
            { title: "Basic", field: "basic", sorter: "number",
                formatter: function(cell) {
                    let value = cell.getValue();
                    let id = cell.getRow().getData().comId;
                    return `<input type="number" id="basic-${id}" value="${value}">`;
                }
            },
            { title: "Hrent", field: "hrent", sorter: "number",
                formatter: function(cell) {
                    let value = cell.getValue();
                    let id = cell.getRow().getData().comId;
                    return `<input type="number" id="hrent-${id}" value="${value}">`;
                }
            },
            { title: "Medical", field: "medical", sorter: "number",
                formatter: function(cell) {
                    let value = cell.getValue();
                    let id = cell.getRow().getData().comId;
                    return `<input type="number" id="medical-${id}" value="${value}">`;
                }
            },
            { title: "Action", field: "action", formatter: "html", width: 150,
                formatter: function(cell) {
                    let comId = cell.getRow().getData().comId;
                    return `<button onclick="updateCompany(${comId})">Edit</button>
                                    <button onclick="deleteCompany(${comId})" style="color: red;">Delete</button>`;
                }
            }
        ]
    });

    // Fetch data from the API
    fetch(apiUrl)
        .then(response => response.json())
        .then(data => {
            table.setData(data);
        })
        .catch(error => console.error("Error fetching data:", error));
});

// Edit (Update) Company
async function updateCompany(companyId) {
    console.log("Updating company with ID:", companyId);

    // Find the row data
    const row = table.getRows().find(r => r.getData().comId === companyId);
    if (!row) {
        console.error(`Find Error - No matching row found: ${companyId}`);
        return;
    }

    // Read input values using correct IDs
    const updatedCompany = {
        comId: companyId,
        comName: document.getElementById(`name-${companyId}`).value,
        basic: parseInt(document.getElementById(`basic-${companyId}`).value),
        hrent: parseInt(document.getElementById(`hrent-${companyId}`).value),
        medical: parseInt(document.getElementById(`medical-${companyId}`).value),
    };

    try {
        const response = await fetch(`${apiUrl}/${companyId}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(updatedCompany)
        });

        if (response.ok) {
            alert("Company updated successfully!");
            row.update(updatedCompany);  // Update Tabulator row data
        } else {
            alert("Failed to update company.");
        }
    } catch (error) {
        console.error("Error updating company:", error);
    }
}



// � Delete Company
async function deleteCompany(companyId) {
    if (!confirm("Are you sure you want to delete this company?")) return;

    try {
        const response = await fetch(`${apiUrl}/${companyId}`, {
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



