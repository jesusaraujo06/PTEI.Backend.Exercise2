using CustomerSearch.Domain.Entities;

namespace CustomerSearch.Domain.Services;

public interface ICustomerService
{
    Task<List<CustomerEntity>> GetAll();
    Task<CustomerEntity> GetById(int id);
    Task<List<CustomerEntity>> GetByFirstNameRange(List<string> firstNames);
    Task<List<CustomerEntity>> GetByLastNameRange(List<string> lastNames);
    Task<List<CustomerEntity>> GetByEmailRange(List<string> emails);
    Task<List<CustomerEntity>> GetByPhoneNumberRange(List<string> phoneNumbers);
    Task<List<CustomerEntity>> GetByAddressRange(List<string> addresses);
    Task<List<CustomerEntity>> GetByCityRange(List<string> cities);
    Task<List<CustomerEntity>> GetCustomersByFieldsPartial(List<string> fieldNames, string searchTerm);
}
