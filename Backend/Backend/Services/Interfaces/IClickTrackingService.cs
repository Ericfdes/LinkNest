using Backend.Models.Entities;

namespace Backend.Services.Interfaces
{
    public interface IClickTrackingService
    {
        Task ClickTrackAsync(ShortUrl shortUrl, HttpContext httpContext);
    }
}
