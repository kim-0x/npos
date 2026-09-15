using Microsoft.AspNetCore.Mvc;
using NPos.Inventory.Abstraction.Service;
using NPos.Inventory.Exceptions;
using NPos.WebApi.Models;

namespace NPos.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IInventoryService inventoryService) : ControllerBase
    {
        [HttpPost]
        public async Task<IResult> Create(ProductModel productModel)
        {
            try
            {
                if (productModel is null)
                {
                    return Results.BadRequest("Product cannot be null.");
                }

                await inventoryService.CreateNewProduct(productModel.Barcode, productModel.Name, productModel.Category);
                return Results.Ok("Product is created");
            }
            catch (InvalidCategoryException ex)
            {
                return Results.BadRequest(ex.Message);
            }
        }
    }
}
