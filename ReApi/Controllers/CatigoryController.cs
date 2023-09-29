
namespace ReApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatigoryController : ControllerBase
    {
        private readonly IRepo<Catigory , CatigoryDto> _catigory;
        public CatigoryController(IRepo<Catigory , CatigoryDto> catigory)
        { 
            _catigory = catigory;
        }
   
        
        [HttpGet("GetCatigories")]
        public async Task<ActionResult> GetCtigories()
        {
            return Ok(await _catigory.GetAll());
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult> GetCtigories(int id)
        //{
        //    if (!await _catigory.IsExist(id))
        //        return BadRequest("This Catigory is not Exist");

        //    return Ok(await _catigory.GetById(id));
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateCatigory(CatigoryDto catigoryDto)
        //{
        //    if (catigoryDto is null)
        //        return BadRequest("Invalid Catigory");

        //    return Ok(await _catigory.Add(catigoryDto)); 
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateCatigory(int id , CatigoryDto catigoryDto)
        //{
        //    if (catigoryDto is null)
        //        return BadRequest();
        //    if (!await _catigory.IsExist(id))
        //        return BadRequest();
            
        //    return Ok(await _catigory.Update(catigoryDto , id));
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCatigory(int id)
        //{
        //    if(! await _catigory.IsExist(id))
        //        return NotFound();
            
        //    return Ok(await _catigory.Delete(id));
        //}
    }
}
