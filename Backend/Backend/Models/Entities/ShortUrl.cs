using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Entities
{
    public class ShortUrl
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string OriginalUrl { get; set; }

        [Required] public string ShortenedUrl { get; set; }  // e.g., "abc123"

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiresAt { get; set; }
        public DateTime? LastAccessedAt { get; set; }

        public int ClickCount { get; set; } = 0;



        public bool IsActive => (!ExpiresAt.HasValue || ExpiresAt > DateTime.UtcNow)
                             && (!LastAccessedAt.HasValue || LastAccessedAt > DateTime.UtcNow.AddDays(-30));

        public ICollection<ClickHistory> ClickHistories { get; set; }//ONe to many rel for CLick hitory
    }
}
