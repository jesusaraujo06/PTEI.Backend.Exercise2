using CustomerSearch.Domain.Entities;
using CustomerSearch.Domain.Services;
using Dapper;

namespace CustomerSearch.Data.Implementation;

public class CustomerService : ICustomerService
{
    public DapperDbContext Context { get; }

    public CustomerService(DapperDbContext context)
    {
        Context = context;
    }

    public async Task<List<CustomerEntity>> GetAll()
    {
        string query = $"select * from [dbo].[customers]";
        using var connection = Context.CreateConnection();
        var data = await connection.QueryAsync<CustomerEntity>(query);
        return data.ToList();
    }

    public async Task<CustomerEntity> GetById(int id)
    {
        string query = $"select * from [dbo].[customers] where CustomerId = @id";
        using var connection = Context.CreateConnection();
        var data = await connection.QueryFirstOrDefaultAsync<CustomerEntity>(query, new { id });
        return data;
    }

    public async Task<List<CustomerEntity>> GetByFirstNameRange(List<string> firstNames)
    {
        string query = $"select * from [dbo].[customers] where FirstName IN @firstNames";
        using var connection = Context.CreateConnection();
        var data = await connection.QueryAsync<CustomerEntity>(query, new { firstNames });
        return data.ToList();
    }

    public async Task<List<CustomerEntity>> GetByLastNameRange(List<string> lastNames)
    {
        string query = $"select * from [dbo].[customers] where LastName IN @lastNames";
        using var connection = Context.CreateConnection();
        var data = await connection.QueryAsync<CustomerEntity>(query, new { lastNames });
        return data.ToList();
    }

    public async Task<List<CustomerEntity>> GetByEmailRange(List<string> emails)
    {
        string query = $"select * from [dbo].[customers] where Email IN @emails";
        using var connection = Context.CreateConnection();
        var data = await connection.QueryAsync<CustomerEntity>(query, new { emails });
        return data.ToList();
    }

    public async Task<List<CustomerEntity>> GetByPhoneNumberRange(List<string> phoneNumbers)
    {
        string query = $"select * from [dbo].[customers] where PhoneNumber IN @phoneNumbers";
        using var connection = Context.CreateConnection();
        var data = await connection.QueryAsync<CustomerEntity>(query, new { phoneNumbers });
        return data.ToList();
    }

    public async Task<List<CustomerEntity>> GetByAddressRange(List<string> addresses)
    {
        string query = $"select * from [dbo].[customers] where Address IN @addresses";
        using var connection = Context.CreateConnection();
        var data = await connection.QueryAsync<CustomerEntity>(query, new { addresses });
        return data.ToList();
    }

    public async Task<List<CustomerEntity>> GetByCityRange(List<string> cities)
    {
        string query = $"select * from [dbo].[customers] where City IN @cities";
        using var connection = Context.CreateConnection();
        var data = await connection.QueryAsync<CustomerEntity>(query, new { cities });
        return data.ToList();
    }

    public async Task<List<CustomerEntity>> GetCustomersByFieldsPartial(List<string> fieldNames, string searchTerm)
    {
        if (fieldNames == null || fieldNames.Count == 0 || string.IsNullOrEmpty(searchTerm))
        {
            return new List<CustomerEntity>();
        }

        var validFieldNames = new[] { "FirstName", "LastName", "Email", "PhoneNumber", "Address", "City" };

        // Verifica que todos los nombres de campo proporcionados sean válidos.
        if (fieldNames.Any(fieldName => !validFieldNames.Contains(fieldName)))
        {
            throw new ArgumentException("Uno o más campos de búsqueda no son válidos.", nameof(fieldNames));
        }

        // Crear query dinamico
        var fieldConditions = string.Join(" OR ", fieldNames.Select(fieldName => $"{fieldName} LIKE '%' + @searchTerm + '%'"));
        string query = $"SELECT * FROM [dbo].[customers] WHERE {fieldConditions}";

        using var connection = Context.CreateConnection();
        var data = await connection.QueryAsync<CustomerEntity>(query, new { searchTerm });
        return data.ToList();
    }



}
