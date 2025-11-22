using CarApp.Interfaces;
using CarApp.Db;
using CarApp.DTOs;
using CarApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarApp.Services
{

public class CarService : ICarService
{
    private readonly AppDbContext _context;

    public CarService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Car>> GetAllCarsWithOwnersAsync()
    {
        return await _context.Cars
            .Include(c => c.Owner)
            .ToListAsync() ?? throw new InvalidOperationException("No cars found");
    }

    public async Task<Car> GetCarAsync(int carId)
    {
        var car = await _context.Cars
            .Include(c => c.Owner)
            .FirstOrDefaultAsync(c => c.Id == carId) ?? throw new InvalidOperationException($"Car With ID {carId} not found");
            return car;
    }

    public async Task<Car> CreateCarAsync(CarDTO carDTO)
    {
        var latestPerson = _context.People
            .OrderByDescending(p => p.CreatedDt)
            .FirstOrDefault() ?? throw new InvalidOperationException("No person found to associate with the car");

            
            var car = new Car
        {
            Make = carDTO.Make!,
            Model = carDTO.Model!,
            Color = carDTO.Color!,
            Year = carDTO.Year!,
            PersonId = latestPerson.Id,
            ModifiedDt = DateTime.Now,
        };

        _context.Cars.Add(car);
        await _context.SaveChangesAsync();

        return car;
    }
}
}