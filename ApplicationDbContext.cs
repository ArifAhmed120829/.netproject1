using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;  


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Department> Departments { get; set; }

    public DbSet<Designation> Designations { get; set; }
    public DbSet<Employee> Employees { get; set; }

    public DbSet<Shift> Shifts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder){
      //set comId as primary key
      modelBuilder.Entity<Company>().HasKey(c => c.ComId);
      modelBuilder.Entity<Department>().HasKey(d => d.DeptId);
      modelBuilder.Entity<Designation>().HasKey(d => d.DesigId);
       modelBuilder.Entity<Employee>().HasKey(e => e.EmpId);
       modelBuilder.Entity<Shift>().HasKey(s => s.ShiftId);
       //this section belongs to those tables who have foreign keys

       // Department -> Company (One-to-Many) 
    modelBuilder.Entity<Department>()
        .HasOne(d => d.Company)
        .WithMany(c => c.Departments)
        .HasForeignKey(d => d.ComId)// here ComId is the foreign key
        .OnDelete(DeleteBehavior.Cascade);

        // Employee -> Company (One-to-Many)
    modelBuilder.Entity<Employee>()
        .HasOne(e => e.Company)
        .WithMany(c => c.Employees)  // Ensure Company model has ICollection<Employee>
        .HasForeignKey(e => e.ComId) // here ComId is the foreign key
        .OnDelete(DeleteBehavior.Cascade);

    // Employee -> Department (One-to-Many)
    modelBuilder.Entity<Employee>()
        .HasOne(e => e.Department)
        .WithMany(d => d.Employees)  // Ensure Department model has ICollection<Employee>
        .HasForeignKey(e => e.DeptId) // here deptId is the foreign key
        .OnDelete(DeleteBehavior.Cascade);

    // Employee -> Designation (One-to-Many)
    modelBuilder.Entity<Employee>()
        .HasOne(e => e.Designation)
        .WithMany(d => d.Employees)  // Ensure Designation model has ICollection<Employee>
        .HasForeignKey(e => e.DesigId) // here desigId is the foreign key
        .OnDelete(DeleteBehavior.Cascade);

    // Employee -> Shift (One-to-Many)
    modelBuilder.Entity<Employee>()
        .HasOne(e => e.Shift)
        .WithMany(s => s.Employees)  // Ensure Shift model has ICollection<Employee>
        .HasForeignKey(e => e.ShiftId) // here shiftId is the foreign key
        .OnDelete(DeleteBehavior.Cascade);

   // Designation  -> company (one to many)
        modelBuilder.Entity<Designation>()
    .HasOne(d => d.Company)
    .WithMany(c => c.Designations)  // Add ICollection<Designation> in Company model
    .HasForeignKey(d => d.ComId) // here comId is the foreign key
    .OnDelete(DeleteBehavior.Cascade);

    // Shift -> company (one to many)
modelBuilder.Entity<Shift>()
    .HasOne(s => s.Company)
    .WithMany(c => c.Shifts)  // Add ICollection<Shift> in Company model
    .HasForeignKey(s => s.ComId) // here comId the foreign key
    .OnDelete(DeleteBehavior.Cascade);

}
               

   }
