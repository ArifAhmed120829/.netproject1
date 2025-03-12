using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/[controller]")]
[ApiController]
public class ShiftController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ShiftController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Shift>>> GetShifts()
    {
        return await _context.Shifts
            //.Include(d => d.Company)
            .ToListAsync();
    }
    // 🟡 CREATE a new shifts
    [HttpPost]
    public async Task<ActionResult<Shift>> CreateShift([FromBody] Shift shift)
    { 
        if (shift == null || string.IsNullOrEmpty(shift.ShiftName) || shift.ComId <= 0)
        {
            return BadRequest("Invalid shift data.");
        }
        // Ensure company exists before inserting shift
        var company = await _context.Companies.FindAsync(shift.ComId);
        if (company == null)
            return NotFound("Company not found");
        
        
        _context.Shifts.Add(shift);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetShifts), new { id = shift.ShiftId }, shift);
    }
}