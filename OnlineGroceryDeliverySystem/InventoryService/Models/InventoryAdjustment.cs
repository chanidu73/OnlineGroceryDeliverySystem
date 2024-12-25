using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Models
{
    public class InventoryAdjustment
    {
        [Key]
        public int Id { get;set ;}
        [ForeignKey("Inventory")]
        public int InventoryId { get;set; }
        public InventoryItem Inventory { get;set; }
        public int QuantityChanged { get;set; }
        public string Reason { get;set; }
        public DateTime AdjustmentDate { get;set; }
        public InventoryItem inventoryItem { get;set; }
    }
}