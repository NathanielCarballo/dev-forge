using CarApi.Models;

namespace CarApi.Services
{
    public interface ILibraryService
    {

        Task<List<User>> GetUsersAsync();
        Task<User> GetUserAsync(Guid id, bool includeCars = false);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<(bool, string)> DeleteUserAsync(User user);

        Task<List<Car>> GetCarsAsync();
        Task<Car> GetCarAsync(Guid id);
        Task<Car> AddCarAsync(Car car);
        Task<Car> UpdateCarAsync(Car car);
        Task<(bool, string)> DeleteCarAsync(Car car);
    }
}