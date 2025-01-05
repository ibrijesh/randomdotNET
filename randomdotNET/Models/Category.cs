namespace randomdotNET.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    static int count = 1;

    public Category()
    {
        CategoryId = count++;
    }
}