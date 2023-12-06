using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NzWalksApi.Data;
using NzWalksApi.Models;

namespace NzWalksApi.Controllers;

//Ex: http://localhost:1234/api/Employee/
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeDbContext employeeDbContext;

    public EmployeeController(EmployeeDbContext employeeDbContext) {
        this.employeeDbContext = employeeDbContext;
    }
    [HttpGet]
    public IActionResult GetAllEmployees()
    {
        var Employees = new List<EmployeeDetails>
        {
            new EmployeeDetails
            {
                FirstName = "Uday",
                LastName = "Mathur",
                DepartmentID = 3,
                BirthDay = new DateTime(2002, 12, 2),
                Salary = 100
            },
             new EmployeeDetails
            {
                FirstName = "Atul",
                LastName = "yadav",
                DepartmentID = 2,
                BirthDay = new DateTime(2002, 12, 2),
                Salary = 120
            }
        };
        var employees = employeeDbContext.Employee.ToList();
        return Ok(employees);
    }
};


