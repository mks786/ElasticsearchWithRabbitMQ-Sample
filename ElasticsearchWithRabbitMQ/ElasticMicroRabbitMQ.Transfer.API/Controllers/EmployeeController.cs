using Microsoft.AspNetCore.Mvc;

namespace ElasticMicroRabbitMQ.Transfer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        public ValueController()
        {
            
        }

        // GET: api/Employee
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Value");
        }

    }
}
