using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [Authorize]
        [HttpPut]
        public IActionResult Update([FromBody] CustomerUpdateDTO updateDTO)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier);

                Customer? c;
                c = _customerService.GetById(int.Parse(userId.Value));

                Customer updatedCustomer = _customerService.Update
                    (
                        int.Parse(userId.Value), updateDTO.Username, updateDTO.Password,updateDTO.Email,
                        updateDTO.PhoneNumber, updateDTO.Street, updateDTO.City, updateDTO.StreetNumber,updateDTO.AdditionnalInfo,updateDTO.Zipcode,
                        updateDTO.FirstName,updateDTO.LastName,updateDTO.BirthDate,updateDTO.Name
                    );

                if (updatedCustomer is Person)
                {
                    Person person = updatedCustomer as Person;
                    return Ok(new CustomerDTO(updatedCustomer, person));
                }
                else
                {
                    Company company = updatedCustomer as Company;
                    return Ok(new CustomerDTO(updatedCustomer, company));
                }
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPatch]
        public IActionResult SoftDelete()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier);

                Customer? c;
                c = _customerService.GetById(int.Parse(userId.Value));

                _customerService.SoftDelete(int.Parse(userId.Value));

                return Ok("customer disabled!");
            }
            catch(KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize]
        [HttpPatch("activate")]
        public IActionResult ReActivate()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier);

                Customer? c;
                c = _customerService.GetById(int.Parse(userId.Value));

                _customerService.ReActivate(int.Parse(userId.Value));

                return Ok("customer active!");
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier);

                Customer? c;
                c = _customerService.GetById(int.Parse(userId.Value));
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
