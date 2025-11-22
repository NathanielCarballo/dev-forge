using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CarApp.Models 
{
    [Table("ServiceWorkItems")/*, PrimaryKey(nameof(ServiceId), nameof(WorkOrderId))*/]
    public class ServiceWorkItem
    {
        
        public int ServiceId { get; set; }
        public required Service Service { get; set;}
        public int WorkOrderId { get; set; }
        public required WorkOrder WorkOrder { get; set;}

        [MaxLength(20)]
        public string Status { get; set; } = "not completed";
    }
}