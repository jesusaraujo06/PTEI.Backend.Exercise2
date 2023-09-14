using CustomerSearch.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace PTEI.Backend.Exercise2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        public ICustomerService CustomerService { get; }

        public CustomerController(ICustomerService customerService)
        {
            CustomerService = customerService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var customer = await CustomerService.GetAll();
            return Ok(customer);
        }

    }
}