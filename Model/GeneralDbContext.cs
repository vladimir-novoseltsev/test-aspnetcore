using Microsoft.EntityFrameworkCore;

namespace TestApp.Model
{
    public class GeneralDbContext : DbContext
    {
        public GeneralDbContext(DbContextOptions<GeneralDbContext> options) : base(options)
        {
        }

        public DbSet<Currency> Currencies { get; set; }

        protected override void OnModelCreating(ModelBuilder bulder)
        {
            bulder.Entity<Currency>()
                .ToTable("currency")
                .HasKey(c => c.Id);
        }
    }
}