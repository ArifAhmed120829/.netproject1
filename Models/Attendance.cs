namespace sql_training.Models;
using System.Text.Json.Serialization;

public class Attendance
{
    public int EmpId { get; set; }
    public int ComId {get; set;} 
    public DateTime Date { get; set; }
    //public string Status { get; set; }  // e.g., "Present", "Absent
    public string? Status { get; set; }  // e.g., "Present", "Absent"
    public TimeSpan? Intime {get; set;} // 6 hpurs
    public TimeSpan? Outtime {get; set;} // 16 hours
    
    
    [JsonIgnore] // 👈 Prevents serialization loops
    public Employee? Employee { get; set; }  // Navigation
    
    [JsonIgnore] // 👈 Prevents serialization loops
    public Company? Company { get; set; } // 👈 Nullable to avoid model binding issues
   
}
