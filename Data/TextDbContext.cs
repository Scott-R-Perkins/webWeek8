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
        builder.Entity<Animal>().HasData(
            new Animal(){
                Id = 1,
                name = "Dog"
            },
            new Animal(){
                Id = 2,
                name = "Cat"
            },
            new Animal(){
                Id = 3,
                name = "Bird"
            }
        );
    }

    public object Animals { get; internal set; }
}