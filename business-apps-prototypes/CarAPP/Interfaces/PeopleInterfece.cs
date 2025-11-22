
using CarApp.Models;
using CarApp.DTOs;

namespace CarApp.Interfaces
{

public interface IPeopleService
{
    Task<IEnumerable<PersonWithCarDTO>> GetAllPeopleWithCarsAsync();
    Task<IEnumerable<PersonDTO>> GetAllPeople();
    Task<Person> CreatePersonAsync(PersonDTO personDTO);
    Task<PersonWithCarDTO> GetPersonWithCarAsync(Guid personId);
}
}