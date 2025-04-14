using Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Jobs
{
    public class UrlCleanUpJob
    {

        private readonly AppDbContext _context;

        public UrlCleanUpJob(AppDbContext context)
        {
            _context = context;
        }

        public async Task CleanExpiredUrlAsync()
        {
            var now = DateTime.UtcNow;
            var expired = await _context.ShortUrls
                .Where(url => (url.ExpiresAt.HasValue && url.ExpiresAt < now) ||
                                ( url.LastAccessedAt.HasValue && url.LastAccessedAt < now.AddDays(-30)) )
                .ToListAsync();

            if (expired.Any())
            {
                // Remove all expired/inactive URLs from the database in one go
                // (efficient batch deletion).
                _context.ShortUrls.RemoveRange(expired);

                // Save the changes to apply the deletion in the database.
                await _context.SaveChangesAsync();
            }
        }
    }
}
