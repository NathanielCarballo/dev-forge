using Microsoft.AspNetCore.Mvc;
using CarApi.Models;
using CarApi.Services;

namespace CarApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public CarController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCars()
        {
            var cars = await _libraryService.GetCarsAsync();
            if (cars == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No cars in database.");
            }

            return StatusCode(StatusCodes.Status200OK, cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCars(Guid id)
        {
            Car car = await _libraryService.GetCarAsync(id);

            if (car == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No car found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, car);
        }

        [HttpPost]
        public async Task<ActionResult<Car>> AddCar(Car car)
        {
            var dbCar = await _libraryService.AddCarAsync(car);

            if (dbCar == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{car.Year}{car.Color}{car.Make}{car.Model} could not be added.");
            }
            return CreatedAtAction("GetCar", new { id = car.Id}, car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(Guid id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            Car dbCar = await _libraryService.UpdateCarAsync(car);

            if (dbCar == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,$"{car.Year}{car.Color}{car.Make}{car.Model} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(Guid id)
        {
            var car = await _libraryService.GetCarAsync(id);
            (bool status, string message) = await _libraryService.DeleteCarAsync(car);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, car);
        }
    }
}