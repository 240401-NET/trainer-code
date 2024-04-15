using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controllers : ControllerBase
    {

        [HttpGet]
        public string Greet() {
            return "Hello!";
        }
    }
}
