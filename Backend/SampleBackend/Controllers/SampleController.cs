using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SampleBackend.Controllers
{
    [Route("api/[controller]")]
    public class SampleController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await Task.FromResult("hello world");
            return Ok(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create()
        {
            await Task.Delay(1000);
            return Ok();
        }
    }
}
