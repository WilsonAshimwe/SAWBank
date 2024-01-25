using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAWBank.API.DTO.Customer;
using SAWBank.API.DTO.CustomerDTO;
using SAWBank.BLL.Services;
using SAWBank.DOMAIN.Entities;

namespace SAWBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(CustomerService _CustomerService) : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RegisterCustomerDTO customerDTO)
        {
            try
            {
                Customer customer = _CustomerService
                    .Register
                    (
                     customerDTO.Username, customerDTO.Password, customerDTO.Email, customerDTO.PhoneNumber,
                     customerDTO.Street, customerDTO.City, customerDTO.StreetNumber, customerDTO.Zipcode, customerDTO.AdditionnalInfo,
                     customerDTO.Name, customerDTO.BusinesNumber, customerDTO.FirstName, customerDTO.LastName, customerDTO.BirthDate
                    );
                if (customer is Person)
                {
                    Person person = customer as Person;
                    return Created("", new CustomerDTO(customer, person));
                }
                else
                {
                    Company company = customer as Company;
                    return Created("", new CustomerDTO(customer, company));
                }

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut]
        public IActionResult Update()
        {
            throw new NotImplementedException();
        }

        [HttpPatch("remove")]
        public IActionResult SoftDelete()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }


    }
}
