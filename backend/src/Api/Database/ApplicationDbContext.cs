using Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.Database;

public class ApplicationDbContext : DbContext
{
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<HistoricalRecord> HistoricalRecords { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipment>().HasData(
            new Equipment
            {
                Id = "1",
                Name = "Injection Molding Machine",
                State = State.Red,
                LastUpdated = new DateTime(2025, 4, 3, 12, 30, 0, DateTimeKind.Utc)
            },
            new Equipment
            {
                Id = "2",
                Name = "Conveyor Belt",
                State = State.Red,
                LastUpdated = new DateTime(2025, 4, 3, 12, 30, 0, DateTimeKind.Utc)
            },
            new Equipment
            {
                Id = "3",
                Name = "Quality Control Station",
                State = State.Red,
                LastUpdated = new DateTime(2025, 4, 3, 12, 30, 0, DateTimeKind.Utc)
            },
            new Equipment
            {
                Id = "4",
                Name = "Packaging Machine",
                State = State.Red,
                LastUpdated = new DateTime(2025, 4, 3, 12, 30, 0, DateTimeKind.Utc)
            }
        );
    }
}
