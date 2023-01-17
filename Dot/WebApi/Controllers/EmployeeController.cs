namespace EmployeeController;
using DAL;
using BOL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(ILogger<EmployeeController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    [EnableCors]
    public IEnumerable<Employee> GetAllEmp(){
        List<Employee> emp=DBManager.GetAllEmp();
        return emp;
    }
[HttpPost]
[EnableCors]
    public IActionResult InsertEmp(Employee emp){
        DBManager.SaveEmp(emp);
        return Ok(new {message="Employee inserted"});

    }

}