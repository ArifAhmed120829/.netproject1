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
        var employees = await _context.Employees
            .Select(e => new 
            {
                e.EmpId,
                e.EmpName,
                e.Gross,
                e.basic,
                e.HRent,
                e.Medical,
                e.Others
            })
            .ToListAsync();

        return Ok(employees);
    }
    
    [HttpGet ("bycompany")]
    public IActionResult GetEmployeesByCompany([FromQuery] int companyId)
    {
        var employees = _context.Employees.Where(e => e.ComId == companyId).ToList();
        return Ok(employees);
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
        // ✅ Convert dtJoin to UTC if it's not null
        if (employee.dtJoin.HasValue)
        {
            employee.dtJoin = DateTime.SpecifyKind(employee.dtJoin.Value, DateTimeKind.Utc);
        }

        
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetEmployees), new { id = employee.EmpId}, employee);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetEmployeeDetails(int id)
    {
        var employeeDetails = await _context.Employees
            .Where(e => e.EmpId == id)
            .Select(e => new 
            {
                e.EmpId,
                e.EmpName,
                e.EmpCode,
                e.Others,
                Department = e.Department.DeptName,
                Designation = e.Designation.DesigName,
                ShiftIn = e.Shift.ShiftIn,
                ShiftOut = e.Shift.ShiftOut,
                Company =  e.Company.ComName
            })
            .FirstOrDefaultAsync();

        if (employeeDetails == null)
        {
            return NotFound("Employee not found");
        }

        return Ok(employeeDetails);
    }


}