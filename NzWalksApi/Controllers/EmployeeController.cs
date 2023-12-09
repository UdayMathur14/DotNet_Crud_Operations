using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NzWalksApi.Data;
using NzWalksApi.Models;
using NzWalksApi.ModelValidation;

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
    [HttpGet]
    [Route("{id:int}")]
    [ValidateModel] //use this istead of model.isvalid
    public IActionResult GetEmployeeById([FromRoute] int id)
    {
        //Normal method 
        //Find method will only take the primary key not other key 
        var employee = employeeDbContext.Employee.Find(id);

        //linq method 
       // var employee = employeeDbContext.Employee.FirstOrDefault(x=>x.EmployeeID == id );
        
        if(employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpPost]

    public IActionResult Create([FromBody] EmployeeDetails employeeDetails)
    {
        employeeDbContext.Employee.Add(employeeDetails);
        employeeDbContext.SaveChanges();
        return CreatedAtAction(nameof(GetEmployeeById), new { id = employeeDetails.EmployeeID }, employeeDetails);
        //return Ok();

    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> UpdateEmployeeDetails([FromRoute] int id, [FromBody] EmployeeDetails updateEmployeeDetails)
    {

        // Map DTO to Domain Model
        var employeExists = employeeDbContext.Employee.Find(id);
        if (employeExists == null)
        {
            return NotFound();
        }
        employeExists.FirstName = updateEmployeeDetails.FirstName;
        // Check if region exists
        //updateEmployeeDetails = await employeeDbContext.UpdateAsync(id, employeExists);
        employeeDbContext.SaveChanges();return Ok();


    }

    [HttpDelete]
    [Route("{id:int}")]
    public IActionResult DeleteEmployee([FromRoute]int id) { 

        var employeeexist = employeeDbContext.Employee.Find(id);
        if(employeeexist == null)
        {
            return NotFound();
        }
        employeeDbContext.Employee.Remove(employeeexist);
        employeeDbContext.SaveChanges();    
        return Ok();
    }
};


