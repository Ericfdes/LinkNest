using System.Text.RegularExpressions;

namespace Backend.Helper
{
    public class UserAgentHelpers
    {
        public static string GetBrowser(string userAgent)
        {
            if (userAgent.Contains("Edg")) return "Edge";
            if (userAgent.Contains("Chrome")) return "Chrome";
            if (userAgent.Contains("Firefox")) return "Firefox";
            if (userAgent.Contains("Safari") && !userAgent.Contains("Chrome")) return "Safari";
            if (userAgent.Contains("OPR") || userAgent.Contains("Opera")) return "Opera";
            return "Unknown";
        }

        public static string GetOperatingSystem(string userAgent)
        {
            if (userAgent.Contains("Windows NT")) return "Windows";
            if (userAgent.Contains("Mac OS")) return "Mac OS";
            if (userAgent.Contains("Linux")) return "Linux";
            if (userAgent.Contains("Android")) return "Android";
            if (userAgent.Contains("iPhone")) return "iOS";
            return "Unknown";
        }

        public static string GetDeviceType(string userAgent)
        {
            if (Regex.IsMatch(userAgent, "Mobile|Android|iPhone", RegexOptions.IgnoreCase))
                return "Mobile";
            if (Regex.IsMatch(userAgent, "Tablet|iPad", RegexOptions.IgnoreCase))
                return "Tablet";
            return "Desktop";
        }

        public static bool IsBot(string userAgent)
        {
            var botKeywords = new[] { "bot", "crawl", "slurp", "spider", "mediapartners" };
            return botKeywords.Any(keyword => userAgent.ToLower().Contains(keyword));
        }


        public static async Task<(string country, string city)> GetGeoLocation(String ip)
        {
            try
            {
                using var http = new HttpClient();
                var response = await http.GetFromJsonAsync<dynamic>($"https://ipapi.co/{ip}/json/");
                string country = response?.country_name ?? "Unkown";
                string city = response?.city ?? "Unkown";
                return (country, city);
            }
            catch (Exception ex) {
                return ("Unknown", "Unkown");
            }

            
        }
    }
}
