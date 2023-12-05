using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NzWalksApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    [HttpGet]
    public IActionResult getAllStudents()
    {
        string[] students = new string[] { "uday", "meenu", "sarthak" };
        return Ok(students);
    }
};


