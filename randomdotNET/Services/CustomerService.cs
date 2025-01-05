using randomdotNET.Models;
using randomdotNET.Repository;

namespace randomdotNET.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    public Customer GetCustomerById(int id)
    {
        return customerRepository.FetchCustomerById(id);
    }
}