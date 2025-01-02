using randomdotNET.Models;

namespace randomdotNET.Services;

public interface ICustomerService
{
    public Customer GetCustomerById(int id);
}