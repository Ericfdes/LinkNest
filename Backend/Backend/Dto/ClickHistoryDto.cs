namespace Backend.Dto
{
    public class ClickHistoryDto
    {
        public DateTime ClickedAt { get; set; }
        public string Referrer { get; set; }
        public string? IpAddress { get; set; }
        public string UserAgent { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? DeviceType { get; set; }
        public string? BrowserName { get; set; }
        public string? OperatingSystem { get; set; }
        public bool? IsBot { get; set; }
    }
}
