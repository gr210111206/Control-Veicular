using ControlVeicular.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlVeicular.API.Data
{
    public class SicvContext : DbContext
    {
        public SicvContext(DbContextOptions<SicvContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Vehiculo> Vehiculos { get; set; } = null!;
        public DbSet<Bitacora> Bitacoras { get; set; } = null!;
        public DbSet<Mantenimiento> Mantenimientos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Unique constraints
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.NumeroEmpleado)
                .IsUnique();

            modelBuilder.Entity<Vehiculo>()
                .HasIndex(v => v.NumeroUnidad)
                .IsUnique();

            modelBuilder.Entity<Vehiculo>()
                .HasIndex(v => v.Placas)
                .IsUnique();
        }
    }
}
