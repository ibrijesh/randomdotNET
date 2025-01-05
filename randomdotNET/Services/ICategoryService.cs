using randomdotNET.Models;

namespace randomdotNET.Services;

public interface ICategoryService
{
    public List<Category> GetAllCategories();
}