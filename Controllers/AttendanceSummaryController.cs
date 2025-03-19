namespace sql_training.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sql_training.Models;

[Route("api/[controller]")]
[ApiController]
public class AttendanceSummaryController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AttendanceSummaryController(ApplicationDbContext context)
    {
        _context = context;
    }

    // ✅ Get attendance summary for a specific employee
    [HttpGet]
    public async Task<IActionResult> GetAttendanceSummary(int employeeId)
    {
        var summary = await _context.AttendanceSummaries
            .Where(a => a.EmpId == employeeId)
            .ToListAsync();

        if (!summary.Any())
            return NotFound("No summary records found.");

        return Ok(summary);
    }
    
    [HttpGet]
    [Route("api/AttendanceSummary")]
    public IActionResult GetTotalAbsents(int EmpId, int Year, int Month)
    {
        var summary = _context.AttendanceSummaries
            .FirstOrDefault(a => a.EmpId == EmpId && a.Year == Year && a.Month == Month);

        if (summary == null)
            return NotFound(new { TotalAbsents = 0 });

        return Ok(new { TotalAbsents = summary.TotalAbsents });
    }

}
