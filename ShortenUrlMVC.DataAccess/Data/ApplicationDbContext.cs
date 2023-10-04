using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShortenUrlMVC.DataAccess.Data.Entities;

namespace ShortenUrlMVC.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ShortUrl> ShortenUrls { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}