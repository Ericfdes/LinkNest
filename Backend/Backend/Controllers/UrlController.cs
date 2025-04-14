using Backend.Dto;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UrlController : Controller
    {
        private readonly IUrlService _urlService;
        public UrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpPost("shorten")]//api/url/shorten
        public async Task<IActionResult> ShortenUrl([FromBody] UrlShortenRequestDto request)
        {
            //if orginal url passed is not null
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);//http 400
            }

            var response = await _urlService.ShortenUrlAsync(request);

            return Ok(response);    
        }

        [HttpGet("{shortCode}/details")]
        public async Task<IActionResult> GetUrlDetails(string shortCode)
        {
            var result = await _urlService.GetAnalyticsAysnc(shortCode);
            if (result == null)
                return NotFound("URL not found.");

            return Ok(result);
        }
    }
}
