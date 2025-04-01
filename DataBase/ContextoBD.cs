using Microsoft.EntityFrameworkCore;
using WebApiTikects.Models;

namespace WebApiTikects.DataBase
{

    public class ContextoBD : DbContext
    {
        public ContextoBD(DbContextOptions<ContextoBD> options) : base(options) { }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Tiquetes> Tiquetes { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Importancias> Importancias { get; set; }
        public DbSet<Urgencias> Urgencias { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Roles>().HasKey(x => x.ro_identificador);
            modelBuilder.Entity<Tiquetes>().HasKey(t => t.ti_identificador);
            modelBuilder.Entity<Usuarios>().HasKey(u => u.us_identificador);
            modelBuilder.Entity<Categorias>().HasKey(c => c.ca_identificador);
            modelBuilder.Entity<Importancias>().HasKey(i => i.im_identificador);
            modelBuilder.Entity<Urgencias>().HasKey(ur => ur.ur_identificador);
        }

    }
}

