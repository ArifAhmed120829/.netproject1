public class Company{
   public int ComId {get; set;} //primary key

   public string ComName {get; set;}

   public int Basic {get; set;}

   public int Hrent {get; set;}

   public int Medical {get; set;}

   public bool IsInactive {get; set;}

       // Navigation property for related Departments, Employees, 
        public ICollection<Department> Departments { get; set; } = new List<Department>();

         public ICollection<Employee> Employees { get; set; } = new List<Employee>();
         public ICollection<Designation> Designations { get; set; } = new List<Designation>();
         public ICollection<Shift> Shifts { get; set; } = new List<Shift>(); 


}