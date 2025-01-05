using randomdotNET.Models;

namespace randomdotNET.Services;

public interface IProductService
{
    public List<Product> GetAllProducts();
}