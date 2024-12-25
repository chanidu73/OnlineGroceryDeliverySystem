using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryTrackingService.Models
{
    public class Location
    {
        [Key]
        public double Latitude { get;set; }
        public double Longitude { get;set; }
        public DateTime Timestamp { get;set ;}
    }
}