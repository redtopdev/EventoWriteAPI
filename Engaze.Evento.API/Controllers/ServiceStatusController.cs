using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Engaze.Evento.API.Controllers
{
    [ApiController]
    public class ServiceStatusController : ControllerBase
    {
        [HttpGet(Routes.ServiceStatus)]
        public IActionResult ServiceStatus()
        {

            return new ObjectResult("running")
            {
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}