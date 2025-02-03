using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using randomdotNET.Services;

namespace randomdotNET.Controller
{
    [Route("api/productcategory")]
    [ApiController]
    [Authorize]
    public class ProductCategoryController(IProductService productService, ICategoryService categoryService)
        : ControllerBase
    {
        [HttpGet]
        public ActionResult GetProductCategories()
        {
            var products = productService.GetAllProducts();
            var categories = categoryService.GetAllCategories();

            var query = from produt in products
                join category in categories
                    on produt.CategoryId equals category.CategoryId
                select new { produt, category };

            return Ok(query);    // query is executed here, Ok() serialize the data in json.
        }
    }
}