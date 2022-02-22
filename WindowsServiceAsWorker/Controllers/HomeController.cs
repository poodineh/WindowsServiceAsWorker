using Microsoft.AspNetCore.Mvc;

namespace WindowsServiceAsWorker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            var c = new List<string>(); 
            c.Select(x => x.ToString());
            return "Hello world";
        }
    }
}
