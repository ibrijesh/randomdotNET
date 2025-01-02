using randomdotNET.Models;
using randomdotNET.Repository;

namespace randomdotNET.Services;

public class CustomerService
{
    private CustomerRepository customerRepository;

    public CustomerService()
    {
        customerRepository = new CustomerRepository();
    }

    public Customer GetCustomerById(int id)
    {
        return customerRepository.FetchCustomerById(id);
    }
}