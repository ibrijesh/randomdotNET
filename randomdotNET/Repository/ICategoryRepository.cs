using randomdotNET.Models;

namespace randomdotNET.Repository;

public interface ICategoryRepository
{
    public List<Category> FetchAllCategories();
}