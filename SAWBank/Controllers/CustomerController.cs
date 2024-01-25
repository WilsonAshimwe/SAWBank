using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAWBank.API.DTO.Customer;
using SAWBank.API.DTO.CustomerDTO;
using SAWBank.BLL.Services;
using SAWBank.DOMAIN.Entities;
using System.Security.Claims;

namespace SAWBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(CustomerService _customerService) : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RegisterCustomerDTO customerDTO)
        {
            try
            {
                Customer customer = _customerService
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

        //[Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            //var userId = User.FindFirst(ClaimTypes.NameIdentifier);

            //Customer? c;

            //if (userId != null)
            //{
            //    c = _customerService.GetById(int.Parse(userId.Value));
            //}

            Customer? c = _customerService.GetById(1);

            if (c is Person)
            {
                Person person = c as Person;
                return Ok(new CustomerDTO(c, person));
            }
            else
            {
                Company company = c as Company;
                return Ok(new CustomerDTO(c, company));
            }
        }
    }
}
