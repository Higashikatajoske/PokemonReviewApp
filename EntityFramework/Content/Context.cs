using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Content
{

    public class Context: DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Hobby> Hobby { get; set; }

        public Context()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
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

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Department)
                .WithMany(d => d.Persons)
                .HasForeignKey(p => p.DepartmentId);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Address)
                .WithOne(a => a.Person)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Hobbies)
                .WithMany(h => h.Persons)
                .UsingEntity(j => j.ToTable("PersonHobbies"));
        }
    }
}
