using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using SAWBank.API.DTO.Account;
using SAWBank.API.Extensions;
using SAWBank.BLL.Services;
using SAWBank.DOMAIN.Entities;
using System.Data;
using System.Security.Claims;



namespace SAWBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(AccountServices accountService) : ControllerBase
    {
        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
