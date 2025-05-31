using Microsoft.EntityFrameworkCore;
using Noe.Models.Entities;

namespace Noe.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Almacen> Almacenes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configuración Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.GoogleId).IsUnique();
            });
            
            // Configuración Producto
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Precio).HasPrecision(18, 2);
            });
            
            // Configuración Almacen
            modelBuilder.Entity<Almacen>(entity =>
            {
                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Almacenes)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}