using Microsoft.EntityFrameworkCore;
using myProject.Entities;
using myProject.Entities.Location;

namespace myProject.Context;

public class MySQLDBContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Books> Books { get; set; }
    public DbSet<Categories> Categories { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<City> Cities { get; set; }
    
    public MySQLDBContext(DbContextOptions<MySQLDBContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new DbInitializer(modelBuilder).Seed();
    }
}