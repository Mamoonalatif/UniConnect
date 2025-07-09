using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniConnect.Modals;

namespace UniConnect.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

       
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<LostFoundItem> LostFoundItems { get; set; }
        public DbSet<Event> Events { get; set; }

    }
}
