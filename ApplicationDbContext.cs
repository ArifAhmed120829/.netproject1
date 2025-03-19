using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using sql_training.Models;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Department> Departments { get; set; }

    public DbSet<Designation> Designations { get; set; }
    public DbSet<Employee> Employees { get; set; }

    public DbSet<Shift> Shifts { get; set; }
    public DbSet<Attendance> Attendances { get; set; }  
    public DbSet<AttendanceSummary> AttendanceSummaries { get; set; }
    
    public DbSet<Salary> Salaries { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder){
        
      //set comId as primary key
      modelBuilder.Entity<Company>().HasKey(c => c.ComId);
      modelBuilder.Entity<Department>().HasKey(d => d.DeptId);
      modelBuilder.Entity<Designation>().HasKey(d => d.DesigId);
       modelBuilder.Entity<Employee>().HasKey(e => e.EmpId);
       modelBuilder.Entity<Shift>().HasKey(s => s.ShiftId);
       modelBuilder.Entity<Attendance>()
           .HasKey(a => new { a.EmpId, a.Date, a.ComId }); // Composite Primary Key
       modelBuilder.Entity<AttendanceSummary>() .HasKey(a => new { a.EmpId, a.Year, a.Month }); // Composite Primary Key
       modelBuilder.Entity<AttendanceSummary>()
           .HasIndex(a => new {a.Year, a.Month, a.EmpId}) .IsUnique(); // unique attendance summary
       modelBuilder.Entity<Salary>().HasKey(s => new { s.EmpId, s.Year, s.Month }); // composite primary key (salary)
       
       
       //this section belongs to those tables who have foreign keys
       
       modelBuilder.Entity<Attendance>()
           .HasOne(a => a.Company)  // Define Foreign Key Relationship
           .WithMany(c => c.Attendances)          
           .HasForeignKey(a => a.ComId) // Foreign key on Attendance
           .OnDelete(DeleteBehavior.Cascade); // Optional: Cascade delete if Employee is deleted
       
       modelBuilder.Entity<Attendance>()
           .HasOne(a => a.Employee)  // Define Foreign Key Relationship
           .WithMany()               // Employee can have multiple Attendance records
           .HasForeignKey(a => a.EmpId)
           .OnDelete(DeleteBehavior.Cascade); // Optional: Cascade delete if Employee is deleted
     
       modelBuilder.Entity<AttendanceSummary>()
           .HasOne(c => c.Company)  // Define Foreign Key Relationship
           .WithMany()               // Employee can have multiple Attendance records
           .HasForeignKey(c => c.ComId)
           .OnDelete(DeleteBehavior.Cascade); // Optional: Cascade delete if Employee is deleted
       
       modelBuilder.Entity<AttendanceSummary>()
           .HasOne(a => a.Employee)  // Define Foreign Key Relationship
           .WithMany()               // Employee can have multiple Attendance records
           .HasForeignKey(a => a.EmpId)
           .OnDelete(DeleteBehavior.Cascade); // Optional: Cascade delete if Employee is deleted
       


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
    //empployee -> attendance
    modelBuilder.Entity<Employee>()
        .HasMany(e => e.Attendances)  // One employee can have many attendance records
        .WithOne(a => a.Employee)     // Each attendance record is related to one employee
        .HasForeignKey(a => a.EmpId)  // Foreign key is EmpId in the Attendance table
        .OnDelete(DeleteBehavior.Cascade);  // Optional: Cascade delete if Employee is deleted

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

base.OnModelCreating(modelBuilder);

}
               

   }
