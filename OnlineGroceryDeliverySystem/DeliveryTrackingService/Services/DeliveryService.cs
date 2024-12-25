using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryTrackingService.Models;
using DeliveryTrackingService.Repositories;

namespace DeliveryTrackingService.Services
{
    public class DeliveryService:IDeliveryService
    {
        private readonly IDeliveryRepository _repository;
        public DeliveryService(IDeliveryRepository repository)
        {
            _repository =repository;
        }


        public async Task CreateDeliveryAsync(DeliveryModel delivery)
        {
            await _repository.AddAsync(delivery);
            await _repository.SaveChangesAsync();
        }

        public  async void Delete(DeliveryModel entity)
        {



        }

        public async Task DeleteDeliveryAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
        }



        public async Task<IEnumerable<DeliveryModel>> GetAllDeliveriesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<DeliveryModel?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<DeliveryModel>> GetDeliveriesByStatusAsync(string status)
        {
            return await _repository.GetDeliveriesByStatusAsync(status);
        }

        public async Task<DeliveryModel?> GetDeliveryByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<DeliveryModel?> GetDeliveryWithDetailsAsync(int id)
        {
            return await _repository.GetDeliveryWithDetailsAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }

        // public async void Update(DeliveryModel entity)
        // {
        //     _repository.Update(entity);
        //     await _repository.SaveChangesAsync();

        // }

        public async Task UpdateDeliveryAsync(DeliveryModel delivery)
        {
            _repository.Update(delivery);
            await _repository.SaveChangesAsync();
        }
    }
}