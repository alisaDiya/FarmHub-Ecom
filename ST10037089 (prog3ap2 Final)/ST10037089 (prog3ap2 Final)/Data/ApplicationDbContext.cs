using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ST10037089__prog3ap2_Final_.Models;

namespace ST10037089__prog3ap2_Final_.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<farmers> farmers { get; set; }
        public DbSet<products> products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
