
using System.Numerics;

using System.Security.Cryptography;
using System.Text;

namespace Backend.Helper
{
    public class UrlShorterHelper
    {
        private const string Base62Char = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public static string GenerateShortCode ( string orginalUrl, int length = 8)
        {
            // first hash the value sha256
            using var  sha256 = SHA256.Create ();
            var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(orginalUrl));
            
            // Converting to base62
            var base62 = ConvertToBase62(hashBytes);

            return base62.ToString().Substring(0, length);
         
        }

        private static object ConvertToBase62(byte[] hashBytes)
        {
            var value = new BigInteger(hashBytes.Concat(new byte[] { 0 }).ToArray());//must be postive
            var result = new StringBuilder();

            while(value > 0)
            {
                var remainder = (int)(value % 62);
                result.Insert(0, Base62Char[remainder]);
                value /= 62;
            }

            return result.ToString();
        }
    }
}
