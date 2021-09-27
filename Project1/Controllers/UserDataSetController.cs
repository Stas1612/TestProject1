using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserDataSetController : ControllerBase
    {
        public UserDataSetController()
        {
            
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var files = formCollection.Files;

                if (files.Count == 0)
                    return BadRequest();

                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
