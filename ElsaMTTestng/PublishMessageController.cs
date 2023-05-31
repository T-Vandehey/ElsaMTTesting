using ElsaMTTestng.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace ElsaMTTestng
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishMessageController : ControllerBase
    {
        private readonly IPublishEndpoint _publisher;
        public PublishMessageController(IPublishEndpoint publiser)
        {
            _publisher = publiser;
        }

        [HttpPost("One/{correlationId}")]
        public async Task<ActionResult<One>> One(Guid correlationId)
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("Publishing One Message");
            Console.WriteLine("****************************************");
            var one = new One() { CorrelationId = correlationId };
            await _publisher.Publish(one);
            return one;
        }
        [HttpPost("Two/{correlationId}")]
        public async Task<ActionResult<Two>> Two(Guid correlationId)
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("Publishing Two Message");
            Console.WriteLine("****************************************");
            var two = new Two() { CorrelationId = correlationId };
            await _publisher.Publish(two);
            return two;
        }
        [HttpPost("Three/{correlationId}")]
        public async Task<ActionResult<Three>> Three(Guid correlationId)
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("Publishing Three Message");
            Console.WriteLine("****************************************");
            var three = new Three() { CorrelationId = correlationId };
            await _publisher.Publish(three);
            return three;
        }
        [HttpPost("Four/{correlationId}")]
        public async Task<ActionResult<Four>> Four(Guid correlationId)
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("Publishing Four Message");
            Console.WriteLine("****************************************");
            var four = new Four() { CorrelationId = correlationId };
            await _publisher.Publish(four);
            return four;
        }
        [HttpPost("Five/{correlationId}")]
        public async Task<ActionResult<Five>> Five(Guid correlationId)
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("Publishing Five Message");
            Console.WriteLine("****************************************");
            var five = new Five() { CorrelationId = correlationId };
            await _publisher.Publish(five);
            return five;
        }
    }
}
