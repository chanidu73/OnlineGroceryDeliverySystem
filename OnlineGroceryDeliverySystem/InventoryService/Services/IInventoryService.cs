using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.Models;

namespace InventoryService.Services
{
    public interface IInventoryService
    {
        Task<IEnumerable<InventoryItem>> GetAllItemsAsync();
        Task<InventoryItem?> GetItemByIdAsync(int id);
        Task AddItemAsync(InventoryItem item);
        Task UpdateItemAsync(InventoryItem item);
        Task DeleteItemAsync(int id);

        Task<IEnumerable<InventoryAdjustment>> GetAdjustmentsByItemIdAsync(int inventoryItemId);
        Task AddAdjustmentAsync(InventoryAdjustment adjustment);
    }
}