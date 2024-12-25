using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryTrackingService.Models;

namespace DeliveryTrackingService.Repositories
{
    public interface IDeliveryRepository : IRepositoryBase<DeliveryModel>
    {

        Task<IEnumerable<DeliveryModel>> GetDeliveriesByStatusAsync(string status);
        Task<DeliveryModel?> GetDeliveryWithDetailsAsync(int id);
    }
}