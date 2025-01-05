using randomdotNET.Models;
using randomdotNET.Repository;

namespace randomdotNET.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public List<Product> GetAllProducts()
    {
        return productRepository.FetchAllProducts();
    }
}