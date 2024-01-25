using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
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
        public IActionResult GetTest()
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
        public IActionResult Get([FromQuery] int dtoId, [FromQuery] string dtoNumber)
        {
            try
            {
                Account? data = accountService.FindByAccountNumber(dtoId, dtoNumber);
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
        public IActionResult GetAll([FromQuery] CustomerEmailDTO dto) // string email //User.Email();
        {

            //bool isConnected = User != null;
            //string email =  User.Email();     //string? email = User.FindFirstValue(ClaimTypes.Email);
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

        //DONE:  -[Delede] Delete(Account){ .Update()} --> IsActive = false, IsSuspended = true
        [HttpPatch("delete")]
        [Authorize]
        public IActionResult SoftDelete([FromBody] AccountResultDTO dto)
        {
            bool isConnected = User != null;
            if (isConnected)
            {
                //int idUser =int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                int idUser = User.Id();
                try
                {
                    Account? data = accountService.FindBAccountByNumber(dto.AccountNumber);
                    if (data == null)
                    {
                        throw new Exception("The account doesn't exist");
                    }
                    else
                    {
                        if (data.Customers.Count > 0)
                        {
                            List<int> idsCustomers = new List<int>();
                            data.Customers.ForEach(c =>{ idsCustomers.Add(c.Id); });

                            //Is the connected customer the account owner? 
                            if (!idsCustomers.Contains(idUser))
                            {
                                throw new Exception("This is not Your account, you can't change it");
                            }
                            else
                            {
                                data.IsActive = false;
                                accountService.Update(data);
                                return Ok();
                            }
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                }
                catch (UnauthorizedAccessException ex) 
                { 
                    return BadRequest(ex.Message);
                }
                catch (BadHttpRequestException ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        //DONE:  -[Delede] Delete(id){ .Update()} --> IsActive = false, IsSuspended = true
        [HttpPut("id")]
        [Authorize]
        public IActionResult DeleteWithId([FromBody] int AccountId)
        {
            bool isConnected = User != null;
            if(isConnected)
            {
                try
                {
                    int idCustomer = User.Id();
                    Account? data = accountService.FindById(AccountId);
                    if (data == null)
                    {
                        throw new Exception("The account doesn't exist");
                    }
                    else
                    {
                        if(data.Customers.Count > 0)
                        {
                            List<int> idsCustomers = new List<int>();
                            data.Customers.ForEach(c => { idsCustomers.Add(c.Id); });

                            //Is the connected customer the account owner? 
                            if (!idsCustomers.Contains(idCustomer))
                            {
                                throw new Exception("This is not Your account, you can't change it");
                            }
                            else
                            {
                                data.IsActive = false;
                                accountService.Update(data);
                                return Ok();
                            }
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
            else
            {
                //new UnauthorizedAccessException()
                return BadRequest();
            }
        }

        // DELETE api/<AccountController>/5   --> we wont soft delete
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        //DONE:  -[Delede] Delete(Account){ .Update()} --> IsActive = false, IsSuspended = true
        [HttpPatch("suspended")]
        [Authorize]
        public IActionResult Suspended([FromBody] AccountResultDTO dto)
        {
            bool isConnected = User != null;
            if (isConnected)
            {
                //int idUser =int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                int idUser = User.Id();
                try
                {
                    Account? data = accountService.FindBAccountByNumber(dto.AccountNumber);
                    if (data == null)
                    {
                        throw new Exception("The account doesn't exist");
                    }
                    else
                    {
                        if (data.Customers.Count > 0)
                        {
                            List<int> idsCustomers = new List<int>();
                            data.Customers.ForEach(c => { idsCustomers.Add(c.Id); });

                            //Is the connected customer the account owner? 
                            if (!idsCustomers.Contains(idUser))
                            {
                                throw new Exception("This is not Your account, you can't change it");
                            }
                            else
                            {
                                data.IsSuspended = true;
                                accountService.Update(data);
                                return Ok();
                            }
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    return BadRequest(ex.Message);
                }
                catch (BadHttpRequestException ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
