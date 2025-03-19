using System.Text.Json.Serialization;
using sql_training.Models;

public class Employee{
   public int EmpId { get; set;} //primary key
   public int ComId { get; set; }//foreign key
   public int ShiftId { get; set; }//foreign key
   public int DeptId  { get; set;}//foreign key
   public int DesigId  { get; set;}//foreign key
   
   
   public int EmpCode {get; set;} 
   public string EmpName {get; set;}

   public string Gender {get; set;}

   public int Gross {get; set;}

   public int basic {get; set;}

   public int HRent {get; set;}

   public int Medical {get; set;}

   public int Others {get; set;}

   public DateTime? dtJoin {get; set;}

   
   [JsonIgnore] // 👈 Prevents serialization loops
    public Company? Company { get; set; }
    [JsonIgnore] // 👈 Prevents serialization loops
    public Shift? Shift { get; set; }
    [JsonIgnore] // 👈 Prevents serialization loops
    public Department? Department { get; set; }
    [JsonIgnore] // 👈 Prevents serialization loops
    public Designation? Designation { get; set; }
    
    [JsonIgnore] // � Prevents serialization loops
    public ICollection<Attendance>? Attendances { get; set; }
    
    [JsonIgnore] // � Prevents serialization loops
    public ICollection<Salary>? Salaries { get; set; }

    
    
}