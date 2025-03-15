document.getElementById("submitBtn").addEventListener("click", function () {
    const companyData = {
        comName: document.getElementById("comName").value,
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
//departments
document.getElementById("submitBtn2").addEventListener("click", function () {
    const departmentData = {
        deptName: document.getElementById("deptName").value,
        comId: parseFloat(document.getElementById("comId").value)
    };

    fetch("http://localhost:5256/api/department", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(departmentData)
    })
        .then(response => response.json())
        .then(data => {
            console.log("Success:", data);
            alert("Department added successfully!");
        })
        .catch(error => {
            console.error("Error:", error);
            alert("Failed to add department.");
        });
});
//designation
document.getElementById("submitBtn3").addEventListener("click", function () {
    const designationData = {
        desigName: document.getElementById("desigName").value,
        comId: parseFloat(document.getElementById("comId2").value)
    };

    fetch("http://localhost:5256/api/designation", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(designationData)
    })
        .then(response => response.json())
        .then(data => {
            console.log("Success:", data);
            alert("Designation added successfully!");
        })
        .catch(error => {
            console.error("Error:", error);
            alert("Failed to add designation.");
        });
});
//shift
document.getElementById("submitBtn4").addEventListener("click", function () {
    const shiftIn = document.getElementById("shiftIn").value; // Value in 'hh:mm' 
    const shiftOut = document.getElementById("shiftOut").value; // Value in 'hh:mm' format


    const shiftData = {
        shiftName: document.getElementById("shiftName").value,
        shiftIn: shiftIn,
        shiftOut: shiftOut,
        shiftLate: document.getElementById("shiftLate").checked,
        comId: parseFloat(document.getElementById("comId3").value)
    };

    fetch("http://localhost:5256/api/shift", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(shiftData)
    })
        .then(response => response.json())
        .then(data => {
            console.log("Success:", data);
            alert("Shift added successfully!");
        })
        .catch(error => {
            console.error("Error:", error);
            alert("Failed to add Shift.");
        });
});
//Employee
document.getElementById("submitBtn5").addEventListener("click", function () {
    const dtJoin = document.getElementById("dtJoin").value; // Value in 'hh:mm' 
    const employeeData = {
        EmpName: document.getElementById("EmpName").value,
        comId: parseFloat(document.getElementById("comId4").value),
        shiftId: parseFloat(document.getElementById("shiftId").value),
        deptId: parseFloat(document.getElementById("deptId").value),
        desigId: parseFloat(document.getElementById("desigId").value),
        empCode: parseFloat(document.getElementById("empCode").value),
        gender: document.getElementById("gender").value,
        gross: parseFloat(document.getElementById("gross").value),
        dtJoin: dtJoin
    };

    fetch("http://localhost:5256/api/employee", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(employeeData)
    })
        .then(response => response.json())
        .then(data => {
            console.log("Success:", data);
            alert("employee added successfully!");
        })
        .catch(error => {
            console.error("Error:", error);
            alert("Failed to add employee.");
        });
});



