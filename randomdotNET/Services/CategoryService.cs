using randomdotNET.Models;
using randomdotNET.Repository;

namespace randomdotNET.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public List<Category> GetAllCategories()
    {
        return categoryRepository.FetchAllCategories();
    }
}