using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain;
using Store.Infrastructure.Data.Entities;

namespace Store.Infrastructure.Data.Configurations;

internal class UsersConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(u => u.Id);
        
        builder
            .Property(u => u.Name)
            .HasMaxLength(User.MaxNameLength)
            .IsRequired();

        builder
            .Property(u => u.Email)
            .IsRequired();

        builder
            .Property(u => u.Role)
            .IsRequired();

        builder
            .Property(u => u.PasswordHash)
            .IsRequired();
    }
}