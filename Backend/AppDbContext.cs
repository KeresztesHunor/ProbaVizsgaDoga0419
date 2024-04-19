using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class AppDbContext(IConfiguration config) : DbContext
    {
        IConfiguration config { get; } = config;

        public DbSet<Kategoria> Kategoriak { get; set; }
        public DbSet<Teszt> Tesztek { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("DbConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategoria>()
                .HasMany(kategoria => kategoria._Tesztek)
                .WithOne(teszt => teszt._Kategoria)
                .HasForeignKey(teszt => teszt.KategoriaId)
                .OnDelete(DeleteBehavior.Restrict)
            ;
            modelBuilder.Entity<Teszt>()
                .Property(teszt => teszt.Helyes)
                .HasDefaultValue("V1")
            ;
        }
    }
}
