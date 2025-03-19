using sql_training.Models;

namespace sql_training.Controllers;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


[Route("api/[controller]")]
[ApiController]
public class AttendanceController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AttendanceController(ApplicationDbContext context)
    {
        _context = context;
    }

    // ✅ Get all attendance records
    [HttpGet]
    public async Task<IActionResult> GetAllAttendance()
    {
        var attendanceList = await _context.Attendances.ToListAsync();
        return Ok(attendanceList);
    }

    // ✅ Get attendance by Employee ID
    [HttpGet("byEmployee")]
    public async Task<IActionResult> GetAttendanceByEmployee(int employeeId)
    {
        var attendanceRecords = await _context.Attendances
            .Where(a => a.EmpId == employeeId)
            .ToListAsync();

        if (!attendanceRecords.Any())
            return NotFound("No attendance records found.");

        return Ok(attendanceRecords);
    }

    // ✅ Add new attendance entry
    [HttpPost]
    public IActionResult CreateAttendance([FromBody] Attendance attendance)
    {
        // Ensure the related Company entity is being tracked
        var companyExists = _context.Companies.Any(c => c.ComId == attendance.ComId);
        if (!companyExists)
        {
            return BadRequest("Invalid Company ID. The specified company does not exist.");
        }
        
        if (attendance.Intime == null && attendance.Outtime == null)
        {
            attendance.Status = "Absent";
        }
        else if (attendance.Intime > TimeSpan.Parse("09:00:00") || attendance.Outtime < TimeSpan.Parse("17:00:00"))
        {
            attendance.Status = "Late";
        }
        else
        {
            attendance.Status = "Present";
        }
        // Convert Date and Intime/Outtime to UTC
        attendance.Date = attendance.Date.ToUniversalTime();
        _context.Attendances.Add(attendance);
        _context.SaveChanges();
    
        return CreatedAtAction(nameof(GetAttendanceByEmployee), new { id = attendance.EmpId }, attendance);
    }

    

}
