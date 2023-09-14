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
}
