using Microsoft.AspNetCore.Mvc;
using NPos.Application.Abstraction.Service;
using NPos.Application.Commands;
using NPos.Inventory.Exceptions;

namespace NPos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController(IInventoryService inventoryService) : ControllerBase
    {
        [HttpPost("in")]
        public async Task<ActionResult> Create(EntryStockCommand command)
        {
            try
            {
                var result = await inventoryService.StockEntry(command);
                return Ok(result);
            }
            catch (ProductNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
