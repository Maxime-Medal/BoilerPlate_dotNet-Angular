using Microsoft.AspNetCore.Mvc;

namespace BoilerPlate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet(Name = "HelloWorld")]
        public string Get()
        {
            return "Hello World!";
        }

    }
}
