using Backend.Data;
using Backend.Helper;
using Backend.Models.Entities;
using Backend.Services.Interfaces;

namespace Backend.Services.Implementation
{
    public class ClickTrackingService : IClickTrackingService
    {
        private readonly AppDbContext _context;
        
        public ClickTrackingService(AppDbContext context)
        {
            _context = context;
        }
        public async Task ClickTrackAsync(ShortUrl shortUrl, HttpContext httpContext)
        {
            var referer = httpContext.Request.Headers["Referer"].ToString();
            var userAgent = httpContext.Request.Headers["User-Agent"].ToString();
            var ipAddress = httpContext.Connection.RemoteIpAddress?.ToString();
            var (country, city) = await UserAgentHelpers.GetGeoLocation(ipAddress);
            var Click = new ClickHistory
            {
               ShortUrlId = shortUrl.Id,//fk
                Referrer = referer,
                UserAgent = userAgent,
                IpAddress = ipAddress,
                ClickedAt = DateTime.UtcNow,
                Country = country,
                City = city,
                BrowserName = UserAgentHelpers.GetBrowser(userAgent),
                OperatingSystem = UserAgentHelpers.GetOperatingSystem(userAgent),
                DeviceType = UserAgentHelpers.GetDeviceType(userAgent),
                IsBot = UserAgentHelpers.IsBot(userAgent),
            };
            _context.ClickHistories.Add(Click);

            //Updating ShortURL table
            shortUrl.LastAccessedAt = DateTime.UtcNow;
            shortUrl.ClickCount++;

            await _context.SaveChangesAsync();
        }
    }
}
