using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EmployeeController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
    {
        return await _context.Employees
            //.Include(d => d.Company)
            .ToListAsync();
    }
    // 🟡 CREATE a new employees
    [HttpPost]
    public async Task<ActionResult<Employee>> CreateEmployee([FromBody] Employee employee)
    { 
        if (employee == null || string.IsNullOrEmpty(employee.EmpName) || employee.ComId <= 0)
        {
            return BadRequest("Invalid employee data.");
        }
        // Ensure company exists before inserting employee
        var company = await _context.Companies.FindAsync(employee.ComId);
        if (company == null)
            return NotFound("Company not found");
        var shift = await _context.Shifts.FindAsync(employee.ShiftId);
        if (shift == null)
            return NotFound("Shift not found");
        var department = await _context.Departments.FindAsync(employee.DeptId);
        if (department == null)
            return NotFound("Department not found");
        var designation = await _context.Designations.FindAsync(employee.DesigId);
        if (designation == null)
            return NotFound("Designation not found");
        
        
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetEmployees), new { id = employee.EmpId}, employee);
    }

}