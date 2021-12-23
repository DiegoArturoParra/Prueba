using Microsoft.EntityFrameworkCore;
using Prueba.Gatos.Models;

namespace Prueba.Gatos.Repositorio
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
