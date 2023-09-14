using CustomerSearch.Domain.Entities;

namespace CustomerSearch.Domain.Services;

public interface ICustomerService
{
    Task<List<CustomerEntity>> GetAll();
}
