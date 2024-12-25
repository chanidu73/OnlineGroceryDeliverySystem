using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryTrackingService.Data;
using DeliveryTrackingService.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryTrackingService.Repositories
{
    public class DeliveryRepository:RepositoryBase<DeliveryModel>, IDeliveryRepository
    {
        private readonly ApplicationDbContext _context;
        public DeliveryRepository(ApplicationDbContext context) : base(context) {
            _context =context;
         }


        public async Task<IEnumerable<DeliveryModel>> GetDeliveriesByStatusAsync(string status)
        {

            return await _context.Deliveries
                // .Where(d => d.Status == status)
                .ToListAsync();
        }

        public async Task<DeliveryModel?> GetDeliveryWithDetailsAsync(int id)
        {
            return await _context.Deliveries
                .FirstOrDefaultAsync(d => d.DeliveryId == id);
        }
    }
}