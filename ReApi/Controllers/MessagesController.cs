using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ReApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IRepo<Messages , MessageDto>_messages;
        public MessagesController(IRepo<Messages , MessageDto> messages)
        {
            _messages = messages;
        }

    

        [HttpGet("GetMessages")]
        public async Task<IActionResult> GetMessages()
        {
            if (await _messages.Count() > 0)
                return Ok(await _messages.GetAll());
            
            return Ok("No Messages Found");
        }

        [HttpPost("CreteMessage")]
        public async Task<IActionResult> CreateMessage(MessageDto message)
        {
            if(ModelState.IsValid) 
                return Ok(await _messages.Add(message));

            return BadRequest("Model state is not valid");
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMessage(int id)
        //{
        //    bool b = await _messages.Delete(id);

        //    if (b)
        //        return Ok("Sucessed");

        //    return BadRequest("Id is not Valid !");
        //}
    }
}
