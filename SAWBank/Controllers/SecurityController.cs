using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAWBank.API.DTO;
using SAWBank.BLL.Services;
using SAWBank.DOMAIN.Entities;
using SAWBank.Security;
using System.ComponentModel.DataAnnotations;

namespace SAWBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController(SecurityServices _securityService, JwtManager _jwtManager) : ControllerBase
    {
        [HttpPost]
        public IActionResult MyLogin([FromBody] LoginDTO dto)
        {
            try
            {
                Customer l = _securityService.Login(dto.Email, dto.Password);
                string token = _jwtManager.CreateToken(l.Email, l.Id.ToString(), l.Email);
                return Ok(new { Token = token });
            }
            catch (ValidationException)
            {
                return BadRequest("Invalid Credentials");
            }

        }

    }
}
