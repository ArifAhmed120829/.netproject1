public class Department{
   public int DeptId {get; set;} //Primary key
   public string DeptName {get; set;}

     // Foreign key to Company
    public int ComId { get; set; }
    public Company Company { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}