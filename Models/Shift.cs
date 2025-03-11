public class Shift{

   public int ShiftId {get; set;} //primary key
   public string ShiftName {get; set;}

   public TimeSpan ShiftIn {get; set;} // 6 hpurs

   public TimeSpan ShiftOut {get; set;} // 16 hours

   public bool ShiftLate {get; set;}


        // Foreign key to Company
    public int ComId { get; set; }
    public Company Company { get; set; }


    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    
}