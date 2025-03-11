public class Designation{

   public int DesigId {get; set;} //Primary key
   public string DesigName {get; set;}

     // Foreign key to Company
    public int ComId { get; set; }
    public Company Company { get; set;}

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    
}