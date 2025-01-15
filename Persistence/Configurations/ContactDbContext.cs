using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ContactDbContext : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("contact");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.CreationDate)
            .HasDefaultValueSql("now()");

        builder.Property(c => c.UpdatedDate)
            .HasDefaultValueSql("now()");

        builder.Property(c => c.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.Patronymic)
            .HasMaxLength(50);

        builder.Property(c => c.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .HasIndex(c => c.Email)
            .IsUnique();
    }
}