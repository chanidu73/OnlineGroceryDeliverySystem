using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Models
{
    public class InventoryItem
    {
        [Key]
        public int Id  {get;set ;}
        public string ProductName {get;set; }
        public string SKU { get;set; }
        public int Quantity { get;set; }
        public decimal Price { get;set; }
        public DateTime CreatedAt { get;set; }
        
    }
}