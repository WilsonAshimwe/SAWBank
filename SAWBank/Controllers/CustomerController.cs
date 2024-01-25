using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SAWBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] )
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IActionResult Update()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IActionResult SoftDelete() 
        {  
            throw new NotImplementedException(); 
        }

        [HttpGet] public IActionResult Get()
        {
            throw new NotImplementedException();
        }


    }
}
