using CarApp.Db;
using CarApp.DTOs;
using CarApp.Interfaces;
using CarApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarApp.Services
{

public class PeopleService : IPeopleService
{
    private readonly AppDbContext _context;

    public PeopleService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Person> CreatePersonAsync(PersonDTO personDTO)
    {
        var person = new Person
        {
            FirstName = personDTO.FirstName!,
            LastName = personDTO.LastName!,
            Email = personDTO.Email!,
            Active = true,
            ModifiedDt = DateTime.Now
        };

        _context.People.Add(person);
        await _context.SaveChangesAsync();

        return person;
    }

    public async Task<PersonWithCarDTO> GetPersonWithCarAsync(Guid personId)
    {
        var personWithCar = await _context.People
            .Where(p => p.Id == personId)
            .Select(p => new PersonWithCarDTO
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                Cars = p.Cars!.Select(c => new CarDTO
                {
                    Make = c.Make,
                    Model = c.Model,
                    Color = c.Color,
                    Year = c.Year
                }).ToList() ?? new List<CarDTO>()
            })
            .FirstOrDefaultAsync() ?? throw new Exception("Person Not Found");
        return personWithCar;
    }

    public async Task<IEnumerable<PersonWithCarDTO>> GetAllPeopleWithCarsAsync()
    {
        var people = await _context.People
            .Include(p => p.Cars)
            .ToListAsync() ?? throw new Exception("No people found");

        var personWithCarDTO = people.Select(person => new PersonWithCarDTO
        {
            FirstName = person.FirstName,
            LastName = person.LastName,
            Email = person.Email,
            Cars = person.Cars!.Select(car => new CarDTO
            {
                Make = car.Make,
                Model = car.Model,
                Color = car.Color,
                Year = car.Year
            }).ToList()
        }).ToList();

        return personWithCarDTO;
    }
}
}