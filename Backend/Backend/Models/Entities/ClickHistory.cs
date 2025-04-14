using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Entities
{
    public class ClickHistory
    {
        // Primary key for the ClickHistory record
        public int Id { get; set; }

        // Foreign key linking to the associated ShortUrl record
        public int ShortUrlId { get; set; }

        // Navigation property to access the related ShortUrl details
        public ShortUrl ShortUrl { get; set; }

        // Timestamp marking when the click event occurred; defaults to current UTC time
        public DateTime ClickedAt { get; set; } = DateTime.UtcNow;

        // The HTTP referrer header value indicating the source URL of the click (if available)
        public string Referrer { get; set; }

        // The IP address of the client who clicked the link, useful for tracking and analytics
        public string? IpAddress { get; set; }

        // The User-Agent string from the client's browser, providing details about the device and browser used
        public string UserAgent { get; set; }

        // Optional additions
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? DeviceType { get; set; }
        public string? BrowserName { get; set; }
        public string? OperatingSystem { get; set; }
        public bool? IsBot { get; set; }
     
    }
}
