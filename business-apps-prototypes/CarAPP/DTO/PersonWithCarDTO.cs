namespace CarApp.DTOs
{
    public class PersonWithCarDTO
    {
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }

        public string? Email { get; set;}

        public List<CarDTO>? Cars {get; set; }
        }  
}
