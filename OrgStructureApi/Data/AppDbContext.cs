using OrgStructureApi.Models;

namespace OrgStructureApi.Data;

using Microsoft.EntityFrameworkCore;

public class AppDbContext :DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<Division> Divisions => Set<Division>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Department> Departments => Set<Department>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Company>()
            .HasOne(c => c.Director)
            .WithMany()
            .HasForeignKey(c => c.DirectorId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Division>()
            .HasOne(d => d.Manager)
            .WithMany()
            .HasForeignKey(d => d.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Project>()
            .HasOne(p => p.Manager)
            .WithMany()
            .HasForeignKey(p => p.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Department>()
            .HasOne(dep => dep.Manager)
            .WithMany()
            .HasForeignKey(dep => dep.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
    
    
    
    
}