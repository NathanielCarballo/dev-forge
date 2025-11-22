namespace CarApp.DTOs
{
    public class CarWithOwnerDTO
    {
        public string? Make { get; set;}
        public string? Model { get; set;}
        public string? Year { get; set;}
        public string? Color { get; set;}
        public PersonDTO? Owner { get; set;}
    }
}