
using Backend.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data;

public class AppDbContext : IdentityDbContext
{
    public DbSet<Student>? Students {get; set;}
    public DbSet<Teacher>? Teachers {get; set;}
    public DbSet<StudentTeacher>? StudentTeachers {get; set;}
    public DbSet<Question>? Questions {get; set;}

    public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options)
    {
        
    }

    // protected override void OnModelCreating(ModelBuilder builder)
    // {
    //     builder.Entity<StudentTeacher>()
    //      .HasKey(x => x.Id);

    //     builder.Entity<StudentTeacher>()
    //     .HasOne(x => x.Student)
    //     .WithMany(x => x.StudentTeachers)
    //     .HasForeignKey(x => x.TeacherId);

    //     builder.Entity<StudentTeacher>()
    //     .HasOne(x => x.Teacher)
    //     .WithMany(x => x.StudentTeachers)
    //     .HasForeignKey(x => x.StudentId);
    // }

}