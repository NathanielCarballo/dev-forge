using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CarApp.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(40)]
        public required string Color { get; set; }
        
        [MaxLength(4)]
        public required string Year { get; set; }
        
        [MaxLength(20)]
        public required string Make { get; set; }
        
        [MaxLength(20)]
        public required string Model { get; set; }
        
        public DateTime CreatedDt { get; set; }

        public DateTime ModifiedDt { get; set; }


        public Guid PersonId { get; set;}
        
        [JsonIgnore]
        [ForeignKey("PersonId")]
        public Person? Owner { get; set;}
    }
}