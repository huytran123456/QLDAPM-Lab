using Microsoft.EntityFrameworkCore;
using myProject.Entities;

namespace myProject.Context;

public class SQLServerDBContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Books> Books { get; set; }
    public DbSet<Borrow> Borrows { get; set; }
    
    public SQLServerDBContext(DbContextOptions<SQLServerDBContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new DbInitializer(modelBuilder).Seed();
    }
}