using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryTrackingService.Models;

namespace DeliveryTrackingService.Services
{
    public interface IDeliveryService
    {
        Task<IEnumerable<DeliveryModel>> GetAllDeliveriesAsync();
        Task<DeliveryModel?> GetDeliveryByIdAsync(int id);
        Task<IEnumerable<DeliveryModel>> GetDeliveriesByStatusAsync(string status);
        Task<DeliveryModel?> GetDeliveryWithDetailsAsync(int id);
        Task CreateDeliveryAsync(DeliveryModel delivery);
        Task UpdateDeliveryAsync(DeliveryModel delivery);
        Task DeleteDeliveryAsync(int id);
    }
}