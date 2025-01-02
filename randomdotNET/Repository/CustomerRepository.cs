using randomdotNET.Models;

namespace randomdotNET.Repository;

public class CustomerRepository : ICustomerRepository
{
    public Customer FetchCustomerById(int customerId)
    {
        return new Customer
        {
            Id = customerId,
            Name = "Brijesh Yadav",
            Email = "brijeshyadav@gmail.com"
        };
    }
}