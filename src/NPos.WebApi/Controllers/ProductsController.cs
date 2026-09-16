using Microsoft.AspNetCore.Mvc;
using NPos.Application.Abstraction.Service;
using NPos.Application.Commands;
using NPos.Application.Dtos;
using NPos.Inventory.Exceptions;

namespace NPos.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IInventoryService inventoryService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ProductDto>> Create(CreateProductCommand command)
        {
            try
            {
                var result = await inventoryService.CreateNewProduct(command);
                return Ok(result);
            }
            catch (InvalidCategoryException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
