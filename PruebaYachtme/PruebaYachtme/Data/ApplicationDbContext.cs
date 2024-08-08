using Microsoft.EntityFrameworkCore;
using PruebaAxen_CasaBolsa.Models;
using PruebaYachtme.Models;

namespace PruebaAxen_CasaBolsa.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        //Se agrega Fluent API
        protected override void OnModelCreating(ModelBuilder builder)
        {
          base.OnModelCreating(builder);
        }
      

        //Agregar los modelos
        public DbSet<Items> Items { get; set; }

    }
}
