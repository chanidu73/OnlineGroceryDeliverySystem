using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryTrackingService.Models;
using DeliveryTrackingService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryTrackingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryController:ControllerBase
    {
        private readonly IDeliveryService _service;
        public DeliveryController(IDeliveryService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult>GetAllDeliveries()
        {
            var deliveries = await _service.GetAllDeliveriesAsync();
            if (deliveries == null) return NotFound();
            return Ok(deliveries);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetDeliveryById(int id )
        {
            var delivery = await _service.GetDeliveryByIdAsync(id);
            if(delivery == null)return NotFound();
            return Ok(delivery);
        }

        [HttpPost]
        public async Task<IActionResult>CreateDelivery(DeliveryModel model)
        {
            if(ModelState.IsValid)
            {
                await _service.CreateDeliveryAsync(model);
                return Ok(model);
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateDelivery(int id , DeliveryModel model)
        {
            if(id != model.DeliveryId || !ModelState.IsValid) return BadRequest();
            await _service.UpdateDeliveryAsync(model);
            return Ok(model);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteDelivery(int id)
        {
            var delivery = await _service.GetDeliveryByIdAsync(id);
            if(delivery == null) return NotFound();
            await _service.DeleteDeliveryAsync(id);
            return NoContent();
            
        }

    }
}