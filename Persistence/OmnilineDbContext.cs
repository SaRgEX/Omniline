using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence;

public class OmnilineDbContext(IConfiguration configuration)
    : DbContext
{
    public DbSet<Contact> Contacts { get; set;  }
    public DbSet<Counterparty> Counterparty { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OmnilineDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(configuration.GetConnectionString("Database"))
            .EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }

}