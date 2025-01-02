using randomdotNET.Models;
using randomdotNET.Repository;

namespace randomdotNET.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Customer GetCustomerById(int id)
    {
        return _customerRepository.FetchCustomerById(id);
    }
}