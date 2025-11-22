using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarApp.Models
{
    [Table("WorkOrders")]
        public class WorkOrder
    {
        [Key]
        public int Id { get; set; }
        public required int CarId { get; set; }
        public required Car Car { get; set; }
        public Guid PersonId { get; set; }
        public  required Person Person { get; set; }
        public required decimal Total {get; set;}
        public DateTime CreatedDt { get; set; }
        public DateTime ModifiedDt { get; set; }

        [MaxLength(20)]
        public string Status { get; set; } = "Checked in";
        public required List<ServiceWorkItem> ServiceWorkItems {get; set;}
    }
}