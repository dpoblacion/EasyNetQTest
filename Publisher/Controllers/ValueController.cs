using System.Threading.Tasks;
using Messages;
using EasyNetQ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Publisher.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValueController : ControllerBase
    {
        private readonly IBus _bus;

        private readonly ILogger<ValueController> _logger;

        public ValueController(IBus bus, ILogger<ValueController> logger)
        {
            _bus = bus;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Post(string text)
        {
            await _bus.PubSub.PublishAsync(new TextMessage()
            {
                Text = text
            });

            return Ok();
        }
    }
}
