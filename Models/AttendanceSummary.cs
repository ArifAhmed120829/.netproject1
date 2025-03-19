using System.Text.Json.Serialization;

namespace sql_training.Models;


public class AttendanceSummary
{
    public int ComId { get; set; }
    public int EmpId { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public int TotalAbsents { get; set; }
    
    [JsonIgnore] // 👈 Prevents serialization loops
    public Employee? Employee { get; set; }  // Navigation
    
    [JsonIgnore] // 👈 Prevents serialization loops
    public Company? Company { get; set; } // 👈 Nullable to avoid model bindi
}