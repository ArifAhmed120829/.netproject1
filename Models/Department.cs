using System.Text.Json.Serialization;

public class Department{
   public int DeptId {get; set;} //Primary key
   public string DeptName {get; set;}

     // Foreign key to Company
    public int ComId { get; set; }
    
    
    [JsonIgnore] // 👈 Prevents serialization loops
    public Company? Company { get; set; } // 👈 Nullable to avoid model binding issues

    public ICollection<Employee> Employees { get; set; } = new List<Employee>(); // 
}