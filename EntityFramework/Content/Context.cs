using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EntityFramework.Content
{

    public class Context: DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Department> Departments { get; set; }

        public Context()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PokemonDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Property(p => p.Name).IsRequired();

            modelBuilder.Entity<Department>().Property(p => p.Name).HasColumnName("Title");
        }
    }
}
