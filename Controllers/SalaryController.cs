namespace sql_training.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sql_training.Models;

[Route("api/[controller]")]
[ApiController]
public class SalaryController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SalaryController(ApplicationDbContext context)
    {
        _context = context;
    }

    // ✅ Get attendance summary for a specific employee
  
    [HttpGet("GetSalary")]
    public IActionResult GetSalary(int employeeId, int year, int month)
    {
        var salary = _context.Salaries
            .Where(s => s.EmpId == employeeId && s.Year == year && s.Month == month)
            .Select(s => new
            {
                s.basic,
                s.AbsentAmount,
                s.PayableAmount
            })
            .FirstOrDefault();

        if (salary == null)
        {
            return NotFound(new { message = "Salary data not found" });
        }

        return Ok(salary);
    }

    
    [HttpGet]
    [Route("api/Salary")]
    public IActionResult GetTotalAbsents(int EmpId, int Year, int Month)
    {
        var summary = _context.AttendanceSummaries
            .FirstOrDefault(a => a.EmpId == EmpId && a.Year == Year && a.Month == Month);

        if (summary == null)
            return NotFound(new { TotalAbsents = 0 });

        return Ok(new { TotalAbsents = summary.TotalAbsents });
    }

}