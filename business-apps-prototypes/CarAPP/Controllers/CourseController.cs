using Microsoft.AspNetCore.Mvc;
using CarApp.Interfaces;
using CarApp.DTOs;


namespace CarApp.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly IPeopleService _peopleService;
    private readonly ICarService _carService;

    public CourseController(IPeopleService peopleService, ICarService carService)
    {
        _peopleService = peopleService;
        _carService = carService;
    }

    [HttpGet("people")]
    public async Task<ActionResult> GetAllPeopleWithCars()
    {
        try
        {
            var people = await _peopleService.GetAllPeopleWithCarsAsync();
            return Ok(people);
        }
        catch (Exception ex)
        {
            return BadRequest("Error retieving people with cars: " + ex.Message);
        }
    }


    [HttpGet("cars")]
    public async Task<IActionResult> GetAllCarsWithOwners()
    {
        try
        {
            var cars = await _carService.GetAllCarsWithOwnersAsync();
            return Ok(cars);
        }
        catch (Exception ex)
        {
            return BadRequest("Error retrieving cars with owners: " + ex.Message);
        }
    }

    [HttpGet("cars/{carId}")]
    public async Task<IActionResult> GetCar(int carId)
    {
        try
        {
            var car = await _carService.GetCarAsync(carId);
            return Ok (car);
        }
        catch(Exception ex)
        {
            return BadRequest($"Error retrieving car with id-{carId} and its owner: " + ex.Message);
        }
    }
    

    [HttpPost]
    public async Task<IActionResult> CreatePersonAndCar([FromBody] PersonAndCarDTO request)
    {
        try
        {
            var person = await _peopleService.CreatePersonAsync(request.Person!);

            var carDTO = request.Car;
            var car = await _carService.CreateCarAsync(carDTO!);

            return Ok(new { Person = person, Car = car});
        }

        catch (Exception ex)
        {
            return BadRequest("Error creating person and car: " + ex.Message);
        }
    }
}
}