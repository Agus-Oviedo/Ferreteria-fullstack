using Microsoft.EntityFrameworkCore;
using FerreteriaAPI.Models;

namespace FerreteriaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<Usuario> Usuarios => Set<Usuario>(); // 👈 Agregado
    }
}
