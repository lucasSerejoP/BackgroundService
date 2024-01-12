using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiBackgroundService.Domain;
using WebApiBackgroundService.Repository;

namespace WebApiBackgroundService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExecuteController : ControllerBase
    {
        private ICommandRepository _commandRepository;
        public ExecuteController(ICommandRepository commandRepository)
        {
            _commandRepository = commandRepository;
        }
        /// <summary>
        /// Post Message
        /// </summary>
        [HttpPost]
        public IActionResult SetCommand([FromBody] Message message)
        {
            if (message.Continue == true) {
                _commandRepository.SetMessage(message);
                return Ok(_commandRepository.GetMessage());
            }
            else

                return BadRequest();
        }
    }
}
