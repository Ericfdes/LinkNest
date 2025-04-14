using Backend.Data;
using Backend.Dto;
using Backend.Helper;
using Backend.Models.Entities;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

    namespace Backend.Services.Implementation
    {
        public class UrlService: IUrlService    
        {
            private readonly AppDbContext _context;

            //private readonly string _baseUrl = "https://localhost:7005/u/"; 
            private readonly string _baseUrl = "https://localhost:3001/u/"; //for docker link


            //Contructor Injection
            public UrlService(AppDbContext context)
            {
                _context = context;
            }

        public async Task<UrlAnalyticsDto?> GetAnalyticsAysnc(string shortCode)
        {
            

            var shortUrl = await _context.ShortUrls.FirstOrDefaultAsync(
                    x => x.ShortenedUrl == shortCode
                );
            if (shortUrl == null) { return null; }

            var click = await _context.ClickHistories
                .Where(x => x.ShortUrlId == shortUrl.Id)
                .ToArrayAsync();

            return new UrlAnalyticsDto
            {
                ShortenedCode = shortUrl.ShortenedUrl,
                OriginalUrl = shortUrl.OriginalUrl,
                ShortenedUrl = _baseUrl +  shortUrl.ShortenedUrl,
                ClickCount = shortUrl.ClickCount,
                CreatedAt = shortUrl.CreatedAt,
                ExpiresAt = shortUrl.ExpiresAt,
                //Clicks = click.ToList(), creates a fugging cycle idk why
                Clicks = click.Select(c => new ClickHistoryDto
                {
                    ClickedAt = c.ClickedAt,
                    Referrer = c.Referrer,
                    IpAddress = c.IpAddress,
                    UserAgent = c.UserAgent,
                    Country = c.Country,
                    City = c.City,
                    DeviceType = c.DeviceType,
                    BrowserName = c.BrowserName,
                    OperatingSystem = c.OperatingSystem,
                    IsBot = c.IsBot
                }).ToList()//this is a better option as it is lightweight
            };


        }

        public async Task<ShortUrl?> GetOrginalUrlAsync(string shortCode)
        {
            var urlEntity = await _context.ShortUrls.FirstOrDefaultAsync(
                    x => x.ShortenedUrl == shortCode
                );
        
            return urlEntity;
        }

        public async Task<UrlShortenResponseDto> ShortenUrlAsync(UrlShortenRequestDto request )
            {

                //Generate
                var shortCode = UrlShorterHelper.GenerateShortCode(request.OriginalUrl);

                // check if it already exsits

                var existing = await _context.ShortUrls.FirstOrDefaultAsync(x => x.ShortenedUrl == shortCode);

                if (existing != null)
                {
                    return new UrlShortenResponseDto
                    {
                        ShortCode = existing.ShortenedUrl,
                        ShortUrl = _baseUrl + shortCode
                    };
                }

            // new url Entity

            var entity = new ShortUrl
            {
                OriginalUrl = request.OriginalUrl,
                ShortenedUrl = shortCode,
                ExpiresAt = DateTime.UtcNow.AddDays(30),
                CreatedAt = DateTime.Now,
            };

                _context.ShortUrls.Add(entity);
                await _context.SaveChangesAsync();

                // return data obj (dto)
                return new UrlShortenResponseDto
                {
                    ShortUrl = _baseUrl + shortCode,
                    ShortCode = shortCode,
                };

            }

        public async Task UpdateAsync(ShortUrl urlObj)
        {
            _context.ShortUrls.Update(urlObj); // Track changes
            await _context.SaveChangesAsync(); // Apply changes to the DB
        }
    }
    }
