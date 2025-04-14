using System.ComponentModel.DataAnnotations;

namespace Backend.Dto
{
    public class UrlShortenRequestDto
    {
        [Required]
        public string OriginalUrl { get; set; }
    }
}
