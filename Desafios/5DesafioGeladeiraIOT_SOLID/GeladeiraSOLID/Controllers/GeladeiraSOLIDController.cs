using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);                
            }
        }   
    }
}