using System.Text.Json.Serialization;
public class Designation{

   public int DesigId {get; set;} //Primary key
   public string DesigName {get; set;}

     // Foreign key to Company
    public int ComId { get; set; }
    
    [JsonIgnore] // 👈 Prevents serialization loops
    public Company? Company { get; set; } // 👈 Nullable to avoid model binding issues

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    
}