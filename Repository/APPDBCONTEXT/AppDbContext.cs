
using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MiddleLayer.APPDBCONTEXT
{
    public class AppDbContext : DbContext
    {
        public DbSet<Genere> generes { get; set; }
        public DbSet<Movie> movies { get; set; }


        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
