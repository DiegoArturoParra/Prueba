using Microsoft.EntityFrameworkCore;
using Prueba.Models;

namespace Prueba.Api.Repositorio
{
    public class Mapeo : DbContext
    {
        public Mapeo(DbContextOptions<Mapeo> options)
         : base(options)
        {

        }
        public DbSet<Gato> TablaGatos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gato>().ToTable("gato", "public");
            base.OnModelCreating(modelBuilder);
        }
    }
}
