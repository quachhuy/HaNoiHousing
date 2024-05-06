using hnh.Data;
using Microsoft.EntityFrameworkCore;
namespace hnh.Data
{
    public class MyDbcontext : DbContext
    {
        public MyDbcontext(DbContextOptions<MyDbcontext> options) : base(options)
        {
        }
        public DbSet<password_reset> password_resets { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<District> districts { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Property> properties { get; set; }
        public DbSet<Report> reports { get; set; }
        public DbSet<Users> users { get; set; }
    }
}
