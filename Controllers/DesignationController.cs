using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/[controller]")]
[ApiController]
public class DesignationController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DesignationController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Designation>>> GetDesignations()
    {
        return await _context.Designations
            //.Include(d => d.Company)
            .ToListAsync();
    }
    // 🟡 CREATE a new designation
    [HttpPost]
    public async Task<ActionResult<Designation>> CreateDesignation([FromBody] Designation designation)
    { 
        if (designation == null || string.IsNullOrEmpty(designation.DesigName) || designation.ComId <= 0)
        {
            return BadRequest("Invalid designation data.");
        }
        // Ensure company exists before inserting designation
        var company = await _context.Companies.FindAsync(designation.ComId);
        if (company == null)
            return NotFound("Company not found");
        
        
        _context.Designations.Add(designation);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetDesignations), new { id = designation.DesigId }, designation);
    }
}