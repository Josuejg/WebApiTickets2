using Microsoft.EntityFrameworkCore;
using WebApiTikects.Models;

namespace WebApiTikects.DataBase
{

    public class ContextoBD : DbContext
    {
        public ContextoBD(DbContextOptions<ContextoBD> options) : base(options) { }
        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Roles>().HasKey(x => x.ro_identificador);

        }

    }
}

