using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Dal
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Slider> sliders { get; set; }
        public DbSet<Catagory> catagories { get; set; }
    }
}
