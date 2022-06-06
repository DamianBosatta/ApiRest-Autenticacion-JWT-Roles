
using Api_Core_Business.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreBusiness
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Cliente>? Cliente { get; set; }
        public DbSet<Vehiculo>? Vehiculo { get; set; }
        public DbSet<Venta>? Ventas { get; set; }
        public DbSet<Users>? Usuario { get; set; }
    }
}
