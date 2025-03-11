document.getElementById("submitBtn").addEventListener("click", function () {
    const companyData = {
        comName: document.getElementById("comName").value,
        basic: parseFloat(document.getElementById("basic").value),
        hrent: parseFloat(document.getElementById("hrent").value),
        medical: parseFloat(document.getElementById("medical").value),
        isInactive: document.getElementById("isInactive").checked
    };

    fetch("http://localhost:5256/api/company", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(companyData)
    })
        .then(response => response.json())
        .then(data => {
            console.log("Success:", data);
            alert("Company added successfully!");
        })
        .catch(error => {
            console.error("Error:", error);
            alert("Failed to add company.");
        });
});
