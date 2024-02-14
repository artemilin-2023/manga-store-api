using Microsoft.EntityFrameworkCore;
using Store.Infrastructure.Data.Configurations;
using Store.Infrastructure.Data.Entities;

namespace Store.Infrastructure.Data;

public class DataContext : DbContext
{ 
    internal virtual DbSet<UserEntity> Users { get; }
    
    // empty constructor needs for mock
    public DataContext() { }
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsersConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}