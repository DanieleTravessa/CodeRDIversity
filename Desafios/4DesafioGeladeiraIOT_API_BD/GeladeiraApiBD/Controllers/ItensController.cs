using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GeladeiraApiBD.Models;
using GeladeiraApiBD.Services;

namespace GeladeiraApiBD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItensController : ControllerBase
    {
        private readonly IItemService _itemService;
        
        public ItensController(IItemService itemService)
        {
            _itemService = itemService;
        }
        
        [HttpGet("listar-itens")]
        public async Task<ActionResult<IEnumerable<Item>>> GetAllItems()
        {
            var items = await _itemService.GetAllItemsAsync();
            return Ok(items);
        }
        
        [HttpGet("acessar-item-especifico")]
        public async Task<ActionResult<Item>> GetItemById(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }
        
        [HttpPost("incluir-item")]
        public async Task<ActionResult> AddItem(Item item)
        {
            await _itemService.AddItemAsync(item);
            return CreatedAtAction(nameof(GetItemById), new { id = item.Id }, item);
        }
        
        [HttpPut("substituir-item-vencido")]
        public async Task<ActionResult> UpdateItem(int id, Item item)
        {
            if (id != item.Id)
                return BadRequest();
            
            var existingItem = await _itemService.GetItemByIdAsync(id);
            if (existingItem == null)
                return NotFound();
            
            await _itemService.UpdateItemAsync(item);
            return NoContent();
        }
        
        [HttpDelete("retirar-item-especifico")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var existingItem = await _itemService.GetItemByIdAsync(id);
            if (existingItem == null)
                return NotFound();
            
            await _itemService.DeleteItemAsync(id);
            return NoContent();
        }
    }
}
