using randomdotNET.Models;

namespace randomdotNET.Repository;

public interface IProductRepository
{
    public List<Product> FetchAllProducts();
}