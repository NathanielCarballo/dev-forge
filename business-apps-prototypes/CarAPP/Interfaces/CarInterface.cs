using System.Threading.Tasks;
using CarApp.DTOs;
using CarApp.Models;

namespace CarApp.Interfaces
{
public interface ICarService
{
    Task<Car> CreateCarAsync(CarDTO carDTO);
    Task<Car> GetCarAsync(int carID);
    Task<IEnumerable<Car>> GetAllCarsWithOwnersAsync();
}
}