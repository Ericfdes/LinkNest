using Backend.Models.Entities;

namespace Backend.Dto
{
    public class UrlAnalyticsDto
    {
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }//complete url _base + code

        public string ShortenedCode {  get; set; }//ur code
        public int ClickCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }

        //public List<ClickHistory> Clicks { get; set; } okay this is why it creates a cycle
        public List<ClickHistoryDto> Clicks { get; set; }
    }
}
