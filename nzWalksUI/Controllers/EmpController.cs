using Microsoft.AspNetCore.Mvc;

namespace nzWalksUI.Controllers
{
    public class EmpController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public EmpController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            //To consume this web api , get the information nd then pss the information view 
            //in asp.ne core there is  framework known s http client which comes from system dot net http 
            //namespace

            //It provides us a way to consume the web api or different types of api , 

            try
            {
                var client = httpClientFactory.CreateClient();
                var response = await client.GetAsync("https://localhost:7253/api/Employee");
                response.EnsureSuccessStatusCode();

               var stringbody = await response.Content.ReadAsStringAsync();
                ViewBag.Response = stringbody;
            }
            catch(Exception ex) 
            {
                
            }

            return View();
        }
    }
}
