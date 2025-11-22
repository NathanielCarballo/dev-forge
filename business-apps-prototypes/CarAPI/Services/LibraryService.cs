using Microsoft.EntityFrameworkCore;
using CarApi.Data;
using CarApi.Models;

namespace CarApi.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly AppDbContext _db;

        public LibraryService(AppDbContext db)
        {
            _db = db;
        }
        #region Users

        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                return await _db.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<User> GetUserAsync(Guid id, bool includeCars)
        {
            try
            {
                if (includeCars)
                {
                    return await _db.Users.Include(c => c.Cars)
                        .FirstOrDefaultAsync(i => i.Id == id);
                }

                return await _db.Users.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<User> AddUserAsync(User user)
        {
            try
            {
                await _db.Users.AddAsync(user);
                await _db.SaveChangesAsync();
                return await _db.Users.FindAsync(user.Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            try
            {
                _db.Entry(user).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteUserAsync(User user)
        {
            try
            {
                var dbUser = await _db.Users.FindAsync(user.Id);

                if(dbUser == null)
                {
                    return (false, "User could not be found");
                }

                _db.Users.Remove(user);
                await _db.SaveChangesAsync();

                return (true, "Author got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        #endregion Users

        #region Cars

        public async Task<List<Car>> GetCarsAsync()
        {
            try
            {
                return await _db.Cars.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public async Task<Car> GetCarAsync(Guid id)
        {
            try
            {
                return await _db.Cars.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Car> AddCarAsync(Car car)
        {
            try
            {
                await _db.Cars.AddAsync(car);
                await _db.SaveChangesAsync();
                return await _db.Cars.FindAsync(car.Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Car> UpdateCarAsync(Car car)
        {
            try
            {
                _db.Entry(car).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return car;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteCarAsync(Car car)
        {
            try
            {
                var dbCar = await _db.Cars.FindAsync(car.Id);

                if (dbCar == null)
                {
                    return (false, "Car could not be found.");

                }

                _db.Cars.Remove(car);
                await _db.SaveChangesAsync();

                return (true, "Car got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }
        
        #endregion Cars
    }
}