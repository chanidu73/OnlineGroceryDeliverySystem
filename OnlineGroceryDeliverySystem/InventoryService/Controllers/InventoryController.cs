using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.Models;
using InventoryService.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController:ControllerBase
    {
        private readonly IInventoryService _service;
        public InventoryController(IInventoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await _service.GetAllItemsAsync();
            if (items == null)return NotFound();
            return Ok(items);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetItemById(int id)
        {
            var item = await _service.GetItemByIdAsync(id);
            if(item ==null) return NotFound();
            return Ok(item);
        }
        [HttpPost]
        public async Task<IActionResult>AddItem(InventoryItem item)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
                await _service.AddItemAsync(item);
                return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateItem (int id , InventoryItem item )
        {
            if(id != item.Id)
            {
                return BadRequest();
            }
            if(!ModelState.IsValid) return BadRequest();
            await _service.UpdateItemAsync(item);
            return Ok(item);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteTask(int id)
        {
            var item = await _service.GetItemByIdAsync(id);
            if(item == null)return NotFound();
            await _service.DeleteItemAsync(id);
            return NoContent();
        }

        [HttpGet("adjustment")]
        public async Task<IActionResult>GetAdjustmentById(int id)
        {
            var item= await _service.GetAdjustmentsByItemIdAsync(id);
            if(item == null)return NotFound();
            return Ok(item);
        }


        [HttpPost("adjustment")]
        public async Task<IActionResult>AddAdjustmentById(InventoryAdjustment model)
        {
            if(!ModelState.IsValid)return BadRequest();
            await _service.AddAdjustmentAsync(model);
            return Ok(model);

        }
    }
}