using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class CounterpartyDbContext : IEntityTypeConfiguration<Counterparty>
{
    public void Configure(EntityTypeBuilder<Counterparty> builder)
    {
        builder.ToTable("counterparty");
        builder
            .HasKey(k => k.Id);

        builder.Property(c => c.CreationDate)
            .HasDefaultValueSql("now()");

        builder.Property(c => c.UpdatedDate)
            .HasDefaultValueSql("now()");

        builder.Property(c => c.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .HasIndex(c => c.Name)
            .IsUnique();

        builder
            .HasMany(c => c.Contacts)
            .WithOne(c => c.Counterparty);
    }
}