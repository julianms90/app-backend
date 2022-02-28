using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence.Context
{
    public class AplicationDbContext: DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<DatosAdicionales> DatosAdicionales { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options)
        {
            
        }
    }
}
