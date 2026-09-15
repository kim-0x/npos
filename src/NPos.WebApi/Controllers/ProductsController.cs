using Microsoft.AspNetCore.Mvc;
using NPos.Inventory.Abstraction.Service;

namespace NPos.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IInventoryService inventoryService) : ControllerBase
    {
        [HttpPost]
        public async Task<IResult> Create(ProductRecord product)
        {
            if (product is null)
            {
                return Results.BadRequest("Product cannot be null.");
            }

            await inventoryService.CreateNewProduct(product.barcode, product.name, product.category);
            return Results.Ok("Product is created");
        }
    }
}
