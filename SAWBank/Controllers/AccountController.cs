﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAWBank.API.DTO.Account;
using SAWBank.API.Extensions;
using SAWBank.BLL.Services;
using SAWBank.DOMAIN.Entities;
using System.Data;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAWBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(AccountServices accountService) : ControllerBase
    {
        // GET: api/<AccountController>
        [HttpGet("test")]
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

        // GET api/Account?CustomerId=1&AccountNumber=BE-22-1111-333-4444 --> DONE -[Get] Get(Customer.Id, Account.AccountNumber){}
        [HttpGet]
        public IActionResult Get([FromQuery] CustomerIdDTO dtoId, [FromQuery] AccountNumberDTO dtoNumber)
        {
            try
            {
                Account? data = accountService.FindByAccountNumber(dtoId.CustomerId, dtoNumber.AccountNumber);
                AccountResultDTO result = new AccountResultDTO();
                if (data != null && data.IsActive)
                {
                    #region CreationLists

                    List<CardDTO> cards = new List<CardDTO>();
                    if (data.Cards.Count > 0)
                    {
                        data.Cards.ForEach(dC =>
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
                    if (data.DepositAccountTransactions.Count > 0)
                    {
                        data.DepositAccountTransactions.ForEach(dD =>
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
                    if (data.WithdrawAccountTransactions.Count > 0)
                    {
                        data.WithdrawAccountTransactions.ForEach(dD =>
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

                    result.Id = data.Id;
                    result.AccountNumber = data.AccountNumber;
                    result.IsActive = data.IsActive;
                    result.IsSuspended = data.IsSuspended;
                    result.Type = new AccountTypeDTO() { Id = data.Type.Id, Type = data.Type.Type };
                    result.Cards = cards;
                    result.DepositAccountTransactions = depos;
                    result.WithdrawAccountTransactions = withDraw;

                }

                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/Account/email="test@test.com"    --> DONE : -[Get] GetAll(Customer.Id) {}
        [HttpGet("email")]
        //[Authorize]   //--> in another case:  [Authorize(Roles = "PERSON,COMPANY")] (but here this is all)
        public IActionResult GetAll([FromQuery] CustomerEmailDTO dto) //User.Email();
        {

            //bool isConnected = User != null;
            //string email =  User.Email();
            try
            {
                List<Account>? data = accountService.GettAllAccountForCusomer(dto.Email);

                List<AccountResultDTO> result = new List<AccountResultDTO>();

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

                            AccountResultDTO resultAccount = new AccountResultDTO()
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
