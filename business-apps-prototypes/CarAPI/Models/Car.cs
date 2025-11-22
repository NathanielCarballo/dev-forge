using System.ComponentModel.DataAnnotations;

namespace CarApi.Models
{
    public class Car
    {
        [Key]
        public Guid Id { get; set;}
        public string? Make { get; set;}
        public string? Model { get; set;}
        public string? Color { get; set;}
        public int? Year { get; set;}
        public float? Price { get; set;}
        
        //one to one relationship
        public Guid? UserId { get; set;}
        public User? User { get; set;}
    }
}