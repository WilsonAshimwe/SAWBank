using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAWBank.API.DTO.Account;
using SAWBank.BLL.Services;
using SAWBank.DOMAIN.Entities;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAWBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(AccountServices accountService) : ControllerBase
    {
        // GET: api/<AccountController>
        [HttpGet]
        //[Authorize(Roles = "PERSON,COMPANY")]
        public IActionResult Get()
        {
            try
            {
                List<Account>? result = accountService.GetAllTest();
                return Ok(result);

            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/Account ?email="test@test.com&role=admin"
        [HttpGet("email")]
        public IActionResult GetAll([FromQuery] CustomerEmailDTO dto)
        {
            try
            {
                List<Account>? data = accountService.GettAllAccountForCusomer(dto.Email);

                List<AccountListResultDTO> result = new List<AccountListResultDTO>();

                if (data != null)
                {

                    data.ForEach(d =>
                    {
                        if (d.IsActive)
                        {
                            #region CreationLists

                            List<CardDTO> cards = new List<CardDTO>();
                            if (d.Cards.Count > 0)
                            {
                                d.Cards.ForEach(dC =>
                                {
                                    CardDTO c = new CardDTO()
                                    {
                                        Id = dC.Id,
                                        NumberCard = dC.NumberCard,
                                        Pin = dC.Pin,
                                        IsBlocked = dC.IsBlocked,
                                    };
                                    cards.Add(c);
                                });
                            }

                            List<TransactionDTO>? depos = new List<TransactionDTO>();
                            if (d.DepositAccountTransactions.Count > 0)
                            {
                                d.DepositAccountTransactions.ForEach(dD =>
                                {
                                    TransactionDTO Ddepo = new TransactionDTO()
                                    {
                                        Id = dD.Id,
                                        TransactionDate = dD.TransactionDate,
                                        Amount = dD.Amount,
                                    };
                                    depos.Add(Ddepo);
                                });
                            }

                            List<TransactionDTO> withDraw = new List<TransactionDTO>();
                            if (d.WithdrawAccountTransactions.Count > 0)
                            {
                                d.WithdrawAccountTransactions.ForEach(dD =>
                                {
                                    TransactionDTO dwd = new TransactionDTO()
                                    {
                                        Id = dD.Id,
                                        TransactionDate = dD.TransactionDate,
                                        Amount = dD.Amount,
                                    };
                                    withDraw.Add(dwd);
                                });
                            }

                            #endregion

                            AccountListResultDTO resultAccount = new AccountListResultDTO()
                            {
                                Id = d.Id,
                                CurrentBalance = d.CurrentBalance,
                                IsActive = d.IsActive,
                                Type = new AccountTypeDTO() { Id = d.Type.Id, Type = d.Type.Type },
                                Cards = cards,
                                DepositAccountTransactions = depos,
                                WithdrawAccountTransactions = withDraw,

                            };
                            result.Add(resultAccount);
                        }

                    });
                }
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }

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
