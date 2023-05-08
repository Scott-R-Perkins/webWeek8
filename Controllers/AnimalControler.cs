using webWeek8.Models;
using Microsoft.AspNetCore.Mvc;
using webWeek8.Data;
using Microsoft.EntityFrameworkCore;

namespace webWeek8.Controllers;

public class AnimalController : ControllerBase
{
    private readonly TestDbContext _db;

    public AnimalController(TestDbContext db){
        _db = db;
    }
    [HttpGet]
    public async Task<List<Animal>> GetAnimals()
    {
        var animals = await _db.Animals!.ToListAsync();
        return animals;
    }
}