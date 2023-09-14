using CustomerSearch.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace PTEI.Backend.Exercise2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        public ICustomerService _customerService { get; }

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var customer = await _customerService.GetAll();
            return Ok(customer);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetById(id);
            return Ok(customer);
        }

        [HttpGet("GetByFirstNameRange")]
        public async Task<IActionResult> GetByFirstNameRange([FromQuery] List<string> firstNames)
        {
            var customers = await _customerService.GetByFirstNameRange(firstNames);
            return Ok(customers);
        }

        [HttpGet("GetByLastNameRange")]
        public async Task<IActionResult> GetByLastNameRange([FromQuery] List<string> lastNames)
        {
            var customers = await _customerService.GetByLastNameRange(lastNames);
            return Ok(customers);
        }

        [HttpGet("GetByEmailRange")]
        public async Task<IActionResult> GetByEmailRange([FromQuery] List<string> emails)
        {
            var customers = await _customerService.GetByEmailRange(emails);
            return Ok(customers);
        }

        [HttpGet("GetByPhoneNumberRange")]
        public async Task<IActionResult> GetByPhoneNumberRange([FromQuery] List<string> phoneNumbers)
        {
            var customers = await _customerService.GetByPhoneNumberRange(phoneNumbers);
            return Ok(customers);
        }

        [HttpGet("GetByAddressRange")]
        public async Task<IActionResult> GetByAddressRange([FromQuery] List<string> addresses)
        {
            var customers = await _customerService.GetByAddressRange(addresses);
            return Ok(customers);
        }

        [HttpGet("GetByCityRange")]
        public async Task<IActionResult> GetByCityRange([FromQuery] List<string> cities)
        {
            var customers = await _customerService.GetByCityRange(cities);
            return Ok(customers);
        }

        [HttpGet("GetCustomersByFieldsPartial")]
        [SwaggerOperation(Summary = "Obtener un listado de clientes segun uno o más campo y un termino de busqueda",
            Description = "Este endpoint es ideal para los campos de busqueda en el frontend.")]

        public async Task<IActionResult> GetCustomersByFieldsPartial([FromQuery] List<string> fieldNames, [FromQuery] string searchTerm)
        {
            var customers = await _customerService.GetCustomersByFieldsPartial(fieldNames, searchTerm);
            return Ok(customers);
        }

    }
}