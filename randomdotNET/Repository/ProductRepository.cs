using randomdotNET.Models;

namespace randomdotNET.Repository;

public class ProductRepository : IProductRepository
{
    private static List<Product> _productsList;

    static ProductRepository()
    {
        _productsList = new List<Product>()
        {
            new Product { ProductName = "Tennis Racket", CategoryId = 1, Price = 499.99, QuantityAvailable = 50 },
            new Product { ProductName = "Tennis Ball", CategoryId = 1, Price = 100.00, QuantityAvailable = 100 },
            new Product { ProductName = "Dining Table", CategoryId = 2, Price = 15000, QuantityAvailable = 10 },
            new Product { ProductName = "Laptop Table", CategoryId = 2, Price = 7000.00, QuantityAvailable = 15 },
            new Product { ProductName = "Levis Jeans", CategoryId = 3, Price = 2000, QuantityAvailable = 100 },
            new Product { ProductName = "Louis Phillipe Shirt", CategoryId = 3, Price = 2500, QuantityAvailable = 100 }
        };
    }

    public List<Product> FetchAllProducts()
    {
        return _productsList;
    }
}