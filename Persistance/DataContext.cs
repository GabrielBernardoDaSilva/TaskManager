using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class DataContext : DbContext
    {
        public DbSet<Taskes> Taskes { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Taskes>(e => {
                e.HasKey(e => e.Id);

                e.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsRequired();
                
                e.Property(e => e.SLA)
                    .IsRequired();
                
                e.Property(e => e.Filename)
                    .HasMaxLength(200)
                    .IsRequired();

                e.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsRequired();
            });
        }


    }
}