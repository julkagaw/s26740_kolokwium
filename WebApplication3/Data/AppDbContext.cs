using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data;

public class AppDbContext : DbContext
{
    public DbSet<Nursery> Nurseries { get; set; }
    public DbSet<SeedlingBatch> SeedlingBatches { get; set; }
    public DbSet<TreeSpecies> TreeSpecies { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Responsible> Responsibles { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Responsible>().HasKey(r => new { r.BatchId, r.EmployeeId });
        modelBuilder.Entity<SeedlingBatch>().HasKey(b => b.BatchId);


        modelBuilder.Entity<TreeSpecies>().HasData(
            new TreeSpecies { SpeciesId = 1, LatinName = "Quercus robur", GrowthTimeInYears = 5 }
        );

        modelBuilder.Entity<Nursery>().HasData(
            new Nursery { NurseryId = 1, Name = "Green Forest Nursery", EstablishedDate = new DateTime(2005, 5, 10) }
        );

        modelBuilder.Entity<Employee>().HasData(
            new Employee { EmployeeId = 1, FirstName = "Anna", LastName = "Kowalska", HireDate = new DateTime(2020, 1, 10) },
            new Employee { EmployeeId = 2, FirstName = "Jan", LastName = "Nowak", HireDate = new DateTime(2019, 6, 1) },
            new Employee { EmployeeId = 3, FirstName = "Janek", LastName = "Nowakowski", HireDate = new DateTime(2018, 6, 1) }
        );

        modelBuilder.Entity<SeedlingBatch>().HasData(
            new SeedlingBatch
            {
                BatchId = 1,
                NurseryId = 1,
                SpeciesId = 1,
                Quantity = 500,
                SownDate = new DateTime(2024, 3, 15),
                ReadyDate = new DateTime(2029, 3, 15)
            }
        );

        modelBuilder.Entity<Responsible>().HasData(
            new Responsible { BatchId = 1, EmployeeId = 1, Role = "Supervisor" },
            new Responsible { BatchId = 1, EmployeeId = 2, Role = "Planter" }
        );
    }
}
