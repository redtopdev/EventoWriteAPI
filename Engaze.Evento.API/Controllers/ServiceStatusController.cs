using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Engaze.Evento.API.Controllers
{
    [ApiController]
    public class ServiceStatusController : ControllerBase
    {
        IConfiguration config;

        public ServiceStatusController(IConfiguration config)
        {
            this.config = config;
        }
        [HttpGet(Routes.ServiceStatus)]
        public IActionResult ServiceStatus()
        {

            return new ObjectResult(config.GetValue<string>("EVENTSTORE_CONNSTRING"))
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}