public class Employee{
   public int EmpId; //primary key

   public int EmpCode;

   public int EmpName;

   public string Gender;

   public int Gross;

   public int basic;

   public int HRent;

   public int Medical;

   public int Others;

   public string dtJoin;




   // Foreign key to Company
    public int ComId { get; set; }
    public Company Company { get; set; }


   // Foreign key to Shift
    public int ShiftId { get; set; }
    public Shift Shift { get; set; }

    // Foreign key to Department
    public int DeptId  { get; set;}
    public Department Department { get; set; }

// Foreign key to Designation
    public int DesigId  { get; set;}
    public Designation Designation { get; set; }

    



}