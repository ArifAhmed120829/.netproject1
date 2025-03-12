using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DepartmentController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
    {
        return await _context.Departments
            //.Include(d => d.Company)
            .ToListAsync();
    }
    // 🟡 CREATE a new department
    [HttpPost]
    public async Task<ActionResult<Department>> CreateDepartment([FromBody] Department department)
    { 
        if (department == null || string.IsNullOrEmpty(department.DeptName) || department.ComId <= 0)
        {
            return BadRequest("Invalid department data.");
        }
        // Ensure company exists before inserting department
        var company = await _context.Companies.FindAsync(department.ComId);
        if (company == null)
            return NotFound("Company not found");
        
        
        _context.Departments.Add(department);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetDepartments), new { id = department.DeptId }, department);
    }
}
