using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webWeek8.Models;

namespace webWeek8.Data;

public class TestDbContext : DbContext
{

    public TestDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Student>().HasData(
            new Student(){
                studentId = 1,
                name = "Scott"
            },
            new Student(){
                studentId = 2,
                name = "Bob"
            },
            new Student(){
                studentId = 3,
                name = "James"
            }
        );
        builder.Entity<Course>().HasData(
            new Course(){
                courseId = 710,
                name = "Web applications"
            },
            new Course(){
                courseId = 721,
                name = "Software engineering"
            },
            new Course(){
                courseId = 701,
                name = "Project"
            }
        );
        builder.Entity<Tutor>().HasData(
            new Tutor(){
                tutorId = 1,
                name = "Josh"
            },
            new Tutor(){
                tutorId = 2,
                name = "Oliver"
            },
            new Tutor(){
                tutorId = 3,
                name = "Abdul"
            }

        );
    }

    public object? Student { get; set; }
    public object? Course {get; set;}
    public object? Tutor{get; set;}
    public DbSet<webWeek8.Models.Student> Student_1 { get; set; } = default!;
    public DbSet<webWeek8.Models.Course> Course_1 { get; set; } = default!;
    public DbSet<webWeek8.Models.Tutor> Tutor_1 { get; set; } = default!;
}