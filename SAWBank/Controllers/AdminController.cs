using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAWBank.API.DTO.Customer;
using SAWBank.BLL.Services;
using SAWBank.DOMAIN.Entities;

namespace SAWBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(CustomerService _customerService) : ControllerBase
    {
        [HttpGet("GetAllCustomers")]
        public IActionResult GetAllCustomers()
        {
            List<Customer> customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("GetAllCompanies")]
        public IActionResult GetAllCompanies()
        {
            List<Company> companies = _customerService.GetAllCompanies();
            return Ok(companies);
        }

        [HttpGet("GetAllPeople")]
        public IActionResult GetAllPeople()
        {
            List<Person> people = _customerService.GetAllPeople();
            return Ok(people);
        }
    }
}
