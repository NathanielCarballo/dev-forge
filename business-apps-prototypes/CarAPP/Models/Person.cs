using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarApp.DTOs;

namespace CarApp.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [MaxLength(20)]
        public required string FirstName { get; set; }
        
        [MaxLength(20)]
        public required string LastName { get; set; }

        [MaxLength(40)]
        public required string Email { get; set;}

        public bool Active {get; set; } = true;

        public DateTime CreatedDt { get; set;}
        public DateTime ModifiedDt { get; set; }

        
        public List<Car>? Cars { get; set;}        
        public List<WorkOrder>? WorkOrders {get; set; }

    }
}