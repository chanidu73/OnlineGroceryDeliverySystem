using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.Data;
using InventoryService.Models;
using InventoryService.Repositories;

namespace InventoryService.Services
{
    public class InventoryService:IInventoryService
    {
        private readonly IInventoryRepository _repository ; 
        public InventoryService(IInventoryRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAdjustmentAsync(InventoryAdjustment adjustment)
        {
            await _repository.AddAdjustmentAsync(adjustment);
        }

        public async Task AddItemAsync(InventoryItem item)
        {
            await _repository.AddItemAsync(item);
        }

        public async Task DeleteItemAsync(int id)
        {
            await _repository.DeleteItemAsync(id);
        }

        public async Task<IEnumerable<InventoryAdjustment>> GetAdjustmentsByItemIdAsync(int inventoryItemId)
        {
            return await _repository.GetAdjustmentsByItemIdAsync(inventoryItemId);
        }

        public async Task<IEnumerable<InventoryItem>> GetAllItemsAsync()
        {
            return await _repository.GetAllItemsAsync();
        }

        public async Task<InventoryItem?> GetItemByIdAsync(int id)
        {
            return await _repository.GetItemByIdAsync(id);
        }

        public async Task UpdateItemAsync(InventoryItem item)
        { 
            await _repository.UpdateItemAsync(item);
        }
    }
}