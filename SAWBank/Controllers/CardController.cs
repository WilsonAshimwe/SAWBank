using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAWBank.API.DTO.Card;
using SAWBank.BLL.Services;
using SAWBank.DOMAIN.Entities;
using System.Security.Claims;

namespace SAWBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController(CustomerService _customerService, CardService _cardService) : ControllerBase
    {
        [HttpGet("GetAllCards")]
        [Authorize]
        public IActionResult GetAllCustomerCards()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier);
                Customer? c = _customerService.GetById(int.Parse(userId.Value));

                List<Card> cards = _cardService.GetAllCustomerCards(int.Parse(userId.Value));
                List<CardDTO> cardsDTO = cards.Select(card => new CardDTO(card)).ToList();

                return Ok(cardsDTO);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{cardId}")]
        [Authorize]
        public IActionResult GetById([FromRoute] int cardId)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier);

                Card card = _cardService.GetById(int.Parse(userId.Value), cardId);

                return Ok(new CardDTO(card));
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPatch("{cardId}")]
        [Authorize]
        public IActionResult BlockCard([FromRoute] int cardId)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier);

                Customer? c;
                c = _customerService.GetById(int.Parse(userId.Value));

                _cardService.Blockcard(int.Parse(userId.Value), cardId);

                return Ok("card Blocked!");
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

        [HttpPatch("UnBlock/{cardId}")]
        [Authorize]
        public IActionResult UnBlockCard([FromRoute] int cardId)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier);

                Customer? c;
                c = _customerService.GetById(int.Parse(userId.Value));

                _cardService.UnBlockcard(int.Parse(userId.Value), cardId);

                return Ok("card UnBlocked!");
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

    }
}
