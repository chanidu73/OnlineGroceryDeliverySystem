using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryTrackingService.Models
{
    public class DeliveryModel
    {
        [Key]
        public int DeliveryId { get;set; }
        public string OrderId { get;set; }
        public string CustomerId { get;set; }
        public DateTime CreatedDate { get;set; }
        public DeliveryStatus Status { get;set ; }
        public string CurrentLocation { get;set; }
    }
}