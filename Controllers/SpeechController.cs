using Microsoft.AspNetCore.Mvc;
using speechRestfulApi.Services;
using System.Threading.Tasks;

namespace speechRestfulApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpeechController : ControllerBase
    {
        private readonly IEiraSpeechService _speechService;

        public SpeechController(IEiraSpeechService speechService)
        {
            _speechService = speechService;
        }

        [HttpPost("synthesize")]
        public async Task<IActionResult> Synthesize([FromBody] string text)
        {
            var result = await _speechService.SynthesizeSpeechAsync(text);
            return Ok(result);
        }
    }
}
