using Backend.Dto;
using Backend.Models.Entities;

namespace Backend.Services.Interfaces
{
    public interface IUrlService
    {
        Task<UrlShortenResponseDto> ShortenUrlAsync(UrlShortenRequestDto request);
        Task<ShortUrl?> GetOrginalUrlAsync(string shortCode);
        Task UpdateAsync(ShortUrl urlObj);

        public  Task<UrlAnalyticsDto?> GetAnalyticsAysnc(string shortCode);

    }
}
