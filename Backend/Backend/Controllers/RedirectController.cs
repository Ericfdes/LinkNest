using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{

    [ApiController]
    [Route("u")]
    public class RedirectController : Controller
    {

        private readonly IUrlService _urlService;
        private readonly IClickTrackingService _clickTrackingService;
  

        public RedirectController(IUrlService urlService, IClickTrackingService clickTrackingService)
        {
            _urlService = urlService;  
            _clickTrackingService = clickTrackingService;
        }

        [HttpGet("{shortCode}")]
        public async Task<IActionResult> RedirectToOriginal(string shortCode)
        {
            var UrlObj = await _urlService.GetOrginalUrlAsync(shortCode);

            if (UrlObj == null)
            {
                return NotFound("The Link Maybe Invalid or Expired");
            }

            //added the below in click tracking service
            //UrlObj.ClickCount += 1;
            //UrlObj.LastAccessedAt = DateTime.UtcNow;
            // await _urlService.UpdateAsync(UrlObj);

            await _clickTrackingService.ClickTrackAsync(UrlObj, HttpContext);

            return Redirect(UrlObj.OriginalUrl);
        }
    }
}
