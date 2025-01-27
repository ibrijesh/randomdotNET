using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace randomdotNET.FactoryPattern
{
    [Route("api/notify/")]
    [ApiController]
    public class NotifyController(INotifierFactory notifierFactory) : ControllerBase
    {
        [HttpGet("")]
        public string SendNotification([FromQuery] string type, [FromQuery] string message)
        {
            return notifierFactory.CreateNotifier(type).Notify(message);
        }
    }
}