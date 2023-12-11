using Microsoft.AspNetCore.Mvc;

namespace nzWalksUI.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            //To consume this web api , get the information nd then pss the information view 
            //in asp.ne core there is  framework known s http client which comes from system dot net http 
            //namespace

            //It provides us a way to consume the web api or different types of api , 
            return View();
        }
    }
}
