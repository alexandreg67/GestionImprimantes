using GestionImprimantes.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;


namespace GestionImprimantes.Data
{
    public class DataBaseContext : DbContext
    {

        private readonly DataBaseContext _context;

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<Printer> Printers { get; set; }


        public DbSet<Location> Locations { get; set; }


        public DbSet<User> Users { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Common && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                DateTime dt = DateTime.Now;
                

                if (entityEntry.State == EntityState.Added)
                {
                    ((Common)entityEntry.Entity).DateDeCreation = dt;
                }else
                {
                    ((Common)entityEntry.Entity).DateDeModification = dt;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasQueryFilter(x => x.DateDeSuppression == null);
            modelBuilder.Entity<Printer>().HasQueryFilter(x => x.DateDeSuppression == null);
        }


    }
}
