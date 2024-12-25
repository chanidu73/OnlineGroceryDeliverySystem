using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.Data;
using InventoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Repositories
{
    public class InventoryRepository:IInventoryRepository
    {
        private readonly ApplicationDbContext _context;

        public InventoryRepository(ApplicationDbContext context)
        {
            _context=context;
        }

        public async Task AddAdjustmentAsync(InventoryAdjustment adjustment)
        {
            await _context.InventoryAdjustments.AddAsync(adjustment);
            await _context.SaveChangesAsync();
        }

        public async Task AddItemAsync(InventoryItem item)
        {
            await _context.InventoryItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int id)
        {
            var item = await _context.InventoryItems.FindAsync(id);
            if (item != null)
            {
                _context.InventoryItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<InventoryAdjustment>> GetAdjustmentsByItemIdAsync(int inventoryItemId)
        {
                return await _context.InventoryAdjustments
                                 .Where(adj => adj.Id == inventoryItemId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<InventoryItem>> GetAllItemsAsync()
        {
            return await _context.InventoryItems.ToListAsync();
        }

        public async Task<InventoryItem?> GetItemByIdAsync(int id)
        {
            return await _context.InventoryItems.FindAsync(id);
        }

        public async Task UpdateItemAsync(InventoryItem item)
        {
            _context.InventoryItems.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}