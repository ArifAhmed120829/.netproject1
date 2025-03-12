document.addEventListener("DOMContentLoaded", function () {
   fetch("http://localhost:5256/api/company") // Adjust the URL if needed
       .then(response => response.json())
       .then(data => {
           const tableBody = document.getElementById("company-table");
           tableBody.innerHTML = ""; // Clear table before inserting new data

           data.forEach(company => {
               let row = `<tr>
                    <td>${company.comId}</td>
        <td>${company.comName}</td>
        <td>${company.basic}</td>
        <td>${company.hrent}</td>
        <td>${company.medical}</td>
        <td>${company.isInactive}</td>
               </tr>`;
               tableBody.innerHTML += row;
           });
       })
       .catch(error => console.error("Error fetching data:", error));
});