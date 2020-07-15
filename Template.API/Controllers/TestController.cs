using MediatR;
using Microsoft.AspNetCore.Mvc;
using Template.Application.Commands;

namespace Template.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IMediator _bus;

        public TestController(IMediator bus)
        {
            _bus = bus;
        }

        [HttpPost("test")]
        public async void Get(CreateOrderCommand command)
        {
            //await _bus.Send(new CancelOrderCommand());
        }
    }
}