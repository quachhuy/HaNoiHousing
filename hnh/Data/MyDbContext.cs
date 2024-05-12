using hnh.Data;
using hnh.Models;
using Microsoft.EntityFrameworkCore;

namespace hnh.Data
{
    public class MyDbcontext : DbContext
    {
        public MyDbcontext(DbContextOptions<MyDbcontext> options) : base(options)
        {
        }
        public DbSet<Password_Reset> password_resets { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<District> districts { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Property> properties { get; set; }
        public DbSet<Report> reports { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Report_Status> report_statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // tao bang categories
            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable("categories"); 
                category.HasKey(c => c.categoryid); 
                category.Property(c => c.name).IsRequired().HasMaxLength(25); 
                category.Property(c => c.slug).IsRequired().HasMaxLength(25); 

                category.HasMany(c => c.Properties) 
                    .WithOne(p => p.category) 
                    .HasForeignKey(p => p.categoryid)
                    .OnDelete(DeleteBehavior.Restrict);

            });
            // tao bang comments
            modelBuilder.Entity<Comment>(e =>
            {
                e.ToTable("comments");
                e.HasKey(c => c.commentid);
                e.Property(c => c.content).IsRequired();
                e.Property(c => c.createdat).HasDefaultValueSql("getdate()");
                e.Property(c => c.userid).IsRequired();
                e.Property(c => c.propertyid).IsRequired();
                e.HasOne(c => c.User)
                    .WithMany(u => u.Comments)
                    .HasForeignKey(c => c.userid)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(c => c.Property)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(c => c.propertyid)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            // tao bang districts
            modelBuilder.Entity<District>(e =>
            {
                e.ToTable("districts");
                e.HasKey(d => d.districtid);
                e.Property(d => d.name).IsRequired().HasMaxLength(50);
                e.Property(d => d.slug).IsRequired().HasMaxLength(50);
                //----
                e.HasMany(d => d.Properties)
                    .WithOne(p => p.district)
                    .HasForeignKey(p => p.districtid)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            // tao bang properties
            modelBuilder.Entity<Property>(e =>
            {
                e.ToTable("properties");
                e.HasKey(p => p.propertyid);
                e.Property(p => p.title).IsRequired().HasMaxLength(100);
                e.Property(p => p.description).IsRequired().HasMaxLength(100);
                e.Property(p => p.price).IsRequired().HasDefaultValue(0);
                e.Property(p => p.area).IsRequired().HasDefaultValue(0);
                e.Property(p => p.address).IsRequired().HasMaxLength(100);
                e.Property(p => p.countview).IsRequired().HasDefaultValue(0);
                e.Property(p => p.latLng).IsRequired();
                e.Property(p => p.image).IsRequired().HasDefaultValue("no-img.jpg");
                e.Property(p => p.furniture).IsRequired();
                e.Property(p => p.phone).IsRequired().HasMaxLength(15);
                e.Property(p => p.approve).HasDefaultValue(false);
                e.Property(p => p.slug).IsRequired();
                e.Property(p => p.districtid).IsRequired();
                e.Property(p => p.categoryid).IsRequired();

                //----
                e.HasOne(p => p.User)
                    .WithMany(u => u.Properties)
                    .HasForeignKey(p => p.userid)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(p => p.district)
                    .WithMany(d => d.Properties)
                    .HasForeignKey(p => p.districtid)
                     .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(p => p.category)
                    .WithMany(c => c.Properties)
                    .HasForeignKey(p => p.categoryid)
                     .OnDelete(DeleteBehavior.Restrict);
                e.HasMany(p => p.Comments)
                    .WithOne(c => c.Property)
                    .HasForeignKey(c => c.propertyid)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            // tao bang reports
            modelBuilder.Entity<Report>(e =>
            {
                e.ToTable("reports");
                e.HasKey(r => r.reportid);
                e.Property(r => r.content).IsRequired();
                e.Property(r => r.createdat).HasDefaultValueSql("getdate()");
                e.Property(r => r.userid).IsRequired();
                e.Property(r => r.propertyid).IsRequired();
                e.Property(r => r.reportstatusid).IsRequired();
                // ----
                e.HasOne(r => r.User)
                    .WithMany(u => u.Reports)
                    .HasForeignKey(r => r.userid)
                     .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(r => r.Property)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(r => r.propertyid)
                     .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(r => r.Report_Status)
                    .WithMany(rs => rs.Reports)
                    .HasForeignKey(r => r.reportstatusid)
                     .OnDelete(DeleteBehavior.Restrict);
            });
            // tao bang report_statuses
            modelBuilder.Entity<Report_Status>(e =>
            {
                e.ToTable("report_statuses");
                e.HasKey(rs => rs.reportstatusid);
                e.Property(rs => rs.statusname).IsRequired();
                //----
                e.HasMany(rs => rs.Reports)
                    .WithOne(r => r.Report_Status)
                    .HasForeignKey(r => r.reportstatusid)
                     .OnDelete(DeleteBehavior.Restrict);
            });
            // tao bang users
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("users");
                e.HasKey(u => u.userid);
                e.Property(u => u.name).IsRequired().HasMaxLength(50);
                e.Property(u => u.email).IsRequired().HasMaxLength(50);
                e.Property(u => u.password).IsRequired();
                e.Property(u => u.role).IsRequired().HasDefaultValue(0);
                e.Property(u => u.phone).HasMaxLength(15).IsRequired();
                e.Property(u => u.avatar).IsRequired().HasDefaultValue("no-avatar.jpg");
                e.Property(u => u.remembertoken);
                e.Property(u => u.createdat).HasDefaultValueSql("getdate()");
                e.Property(u => u.updatedat).HasDefaultValueSql("getdate()");
                e.Property(u => u.status).IsRequired().HasDefaultValue("1");

                //----
                e.HasMany(u => u.Properties)
                    .WithOne(p => p.User)
                    .HasForeignKey(p => p.userid)
                     .OnDelete(DeleteBehavior.Restrict);
                e.HasMany(u => u.Comments)
                    .WithOne(c => c.User)
                    .HasForeignKey(c => c.userid).OnDelete(DeleteBehavior.Restrict);
                e.HasMany(u => u.Reports)
                    .WithOne(r => r.User)
                    .HasForeignKey(r => r.userid)
                     .OnDelete(DeleteBehavior.Restrict);
            });
            // tao bang password_resets
            modelBuilder.Entity<Password_Reset>(e =>
            {
                e.ToTable("password_resets");
                e.HasKey(pr => pr.password_resetid);
                e.Property(pr => pr.email).IsRequired().HasMaxLength(50);
                e.Property(pr => pr.token).IsRequired();
                e.Property(pr => pr.createdat).HasDefaultValueSql("getdate()");
                e.Property(pr => pr.userid).IsRequired();
                //----
                e.HasOne(pr => pr.User)
                    .WithMany(u => u.Password_Resets)
                    .HasForeignKey(pr => pr.userid)
                     .OnDelete(DeleteBehavior.Restrict);
            });


        }

    }
}
