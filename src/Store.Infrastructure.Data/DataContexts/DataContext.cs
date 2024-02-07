using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Domain;
using Store.Infrastructure.Data.Configurations;
using Store.Infrastructure.Data.Entities;

namespace Store.Infrastructure.Data.DataContexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    internal DbSet<UserEntity>? Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsersConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}