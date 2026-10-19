using LabDay9TuLam.Models;
using Microsoft.EntityFrameworkCore;

namespace LabDay9TuLam.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Category - Name unique
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<Category>()
                .Property(c => c.Status)
                .HasDefaultValue((byte)1);

            modelBuilder.Entity<Category>()
                .Property(c => c.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            // Product - Name unique
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .Property(p => p.SalePrice)
                .HasDefaultValue(0);

            modelBuilder.Entity<Product>()
                .Property(p => p.Status)
                .HasDefaultValue((byte)1);

            modelBuilder.Entity<Product>()
                .Property(p => p.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Banner - Name unique
            modelBuilder.Entity<Banner>()
                .HasIndex(b => b.Name)
                .IsUnique();

            modelBuilder.Entity<Banner>()
                .Property(b => b.Status)
                .HasDefaultValue((byte)1);

            modelBuilder.Entity<Banner>()
                .Property(b => b.Prioty)
                .HasDefaultValue(0);

            // Blog - Name unique
            modelBuilder.Entity<Blog>()
                .HasIndex(b => b.Name)
                .IsUnique();

            modelBuilder.Entity<Blog>()
                .Property(b => b.Status)
                .HasDefaultValue((byte)1);

            modelBuilder.Entity<Blog>()
                .Property(b => b.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
