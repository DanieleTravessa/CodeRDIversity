using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GeladeiraSOLID.Services;
using GeladeiraSOLID.Models;

namespace GeladeiraSOLID.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeladeiraSOLIDController : ControllerBase
    {
        private readonly IItemService _itemService;

        public GeladeiraSOLIDController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("listar-itens")]
        public async Task<ActionResult<IEnumerable<Item>>> GetAllItems()
        {
            try
            {
                var items = await _itemService.GetAllItemsAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("acessar-item-especifico")]
        public async Task<ActionResult<Item>> GetItemById(int id)
        {
            try
            {
                var item = await _itemService.GetItemByIdAsync(id);
                if (item == null)
                    return NotFound();
                return Ok(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("acessar-item-pelo-nome")]
        public async Task<ActionResult<Item>> GetItemByName(string name)
        {
            try
            {
                var item = await _itemService.GetItemByNameAsync(name);
                if(item == null)
                    return NotFound();
                return Ok(item);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("listar-vencidos")]
        public async Task<ActionResult<Item>> GetExpiredItems()
        {
            try
            {
                var expired = await _itemService.GetExpiredItems();
                if (expired is null)
                    return Ok("Parabéns!! Ausência de itens expirados!");
                return Ok(expired);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("incluir-item")]
        public async Task<ActionResult> AddItem([FromBody] Item item)
        {
            try
            {                
                await _itemService.AddItemAsync(item);
                //return CreatedAtAction(nameof(GetItemById), new { id = item.Id }, item);
                return Ok("Item adicionado com sucesso.");
            }                
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);                
            }
        }
    
        [HttpPut("substituir-item-vencido")]
        public async Task<ActionResult> UpdateItem(int id, Item item)
        {
            try
            {
                if (id != item.Id)
                    return BadRequest();

                var existingItem = await _itemService.GetItemByIdAsync(id);
                if (existingItem == null)
                    return NotFound();

                await _itemService.UpdateItemAsync(item);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("retirar-item-especifico")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            try
            {
                var existingItem = await _itemService.GetItemByIdAsync(id);
                if (existingItem == null)
                    return NotFound();

                await _itemService.DeleteItemAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}