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
                await inventoryService.StockEntry(command);
                return Ok($"Added {command.Quantity} unit of item {command.Barcode} in stock.");
            }
            catch (ProductNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
