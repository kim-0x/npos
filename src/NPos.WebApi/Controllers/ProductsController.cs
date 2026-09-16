using Microsoft.AspNetCore.Mvc;
using NPos.Application.Abstraction;
using NPos.Inventory.Exceptions;
using NPos.WebApi.Dtos;

namespace NPos.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IInventoryService inventoryService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto request)
        {
            try
            {
                await inventoryService.CreateNewProduct(request.Barcode, request.Name, request.Category);
                return Ok("Product is created");
            }
            catch (InvalidCategoryException ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
