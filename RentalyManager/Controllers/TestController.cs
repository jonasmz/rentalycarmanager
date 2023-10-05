using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RentalyManager.Controllers
{
    [ApiController]
    [Route("api/testing")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<string> Get()
        {
            return Ok("Recibido");
        }
    }
}
