using randomdotNET.Models;

namespace randomdotNET.Repository;

public interface ICustomerRepository
{
    public Customer FetchCustomerById(int customerId);
}