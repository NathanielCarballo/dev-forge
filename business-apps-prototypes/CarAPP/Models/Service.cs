using System.ComponentModel.DataAnnotations;

namespace CarApp.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(40)]
        public required string Name { get; set; }
        public required decimal Price { get; set; }

        public required List<ServiceWorkItem> ServiceWorkItems { get; set; }      
    }
}