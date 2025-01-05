using randomdotNET.Models;

namespace randomdotNET.Repository;

public class CategoryRepository : ICategoryRepository
{
    private static List<Category> _categoriesList;

    static CategoryRepository()
    {
        _categoriesList = new List<Category>()
        {
            new Category { CategoryName = "Sports" },
            new Category { CategoryName = "Furniture" },
            new Category { CategoryName = "Apparels" }
        };
    }

    public List<Category> FetchAllCategories()
    {
        return _categoriesList;
    }
}