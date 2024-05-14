using CapitalShip.Models;
using Microsoft.EntityFrameworkCore;



public class CapitalShipContext : DbContext
{
    public CapitalShipContext(DbContextOptions<CapitalShipContext> options) : base(options)
    {
    }

    public DbSet<Question> Questions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.HasDefaultContainer("YourContainerName");
        modelBuilder.Entity<Question>().ToContainer("questions");
    }
}
