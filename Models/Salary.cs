namespace sql_training.Models;
using System.Text.Json.Serialization;

public class Salary
{
    public int EmpId { get; set; }
    public int ComId {get; set;} 
    
    public int Year { get; set; }
    public int Month { get; set; }
    
    public int? Gross {get; set;}

    public int basic {get; set;}

    public int HRent {get; set;}

    public int Medical {get; set;}
    
    public int AbsentAmount {get; set;}
    
    public int PayableAmount {get; set;}
    
    public int isPaid {get; set;}
    
    public int PaidAmount {get; set;}
    
       
    [JsonIgnore] // 👈 Prevents serialization loops
    public Employee? Employee { get; set; }  // Navigation
    
    [JsonIgnore] // 👈 Prevents serialization loops
    public Company? Company { get; set; } // 👈 Nullable to avoid model binding issues
    
    
    
}