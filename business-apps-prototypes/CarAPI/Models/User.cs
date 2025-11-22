using System.ComponentModel.DataAnnotations;

namespace CarApi.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set;}
        public string? Name { get; set;}
        public string? Email { get; set;}
        public string? Password { get; set;}
        public DateTime? DateOfBirth { get; set;}

        //one to many relationship
        public List<Car>? Cars { get; set;}
    }
}