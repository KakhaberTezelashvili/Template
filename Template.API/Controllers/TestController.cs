using Microsoft.AspNetCore.Mvc;

namespace Template.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public void Get()
        {

        }
    }
}