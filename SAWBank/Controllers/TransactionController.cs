using Microsoft.AspNetCore.Mvc;
using SAWBank.API.DTO.Account;
using SAWBank.API.DTO.Transaction;
using SAWBank.BLL.Services;
using SAWBank.DOMAIN.Entities;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAWBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController(TransactionServices _transactionServices, AccountServices _accountServices) : ControllerBase
    {
        // GET: api/<TransactionController>
        [HttpGet("test")]
        public IActionResult GetTest()
        {
            try
            {
                List<Transaction>? result = _transactionServices.GetAllTest();
                if(result.Count == 0) {
                    return Ok("No List");
                }
                else
                {
                    return Ok(result);
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        //DONE -[get] GetAll(Account.id){}
        [HttpGet]  //--> FromBody: because it isn't safe to show a Account ID in the url
        public IActionResult GetAll([FromBody]int accountId)
        {
            try
            {
                //1- Is the account with Id == accountId active? --> Control added in case of bypass  of front-end (e.g. request made to the API with PostGress)
                Account? account = _accountServices.FindById(accountId);
                if(account != null && account.IsActive == true) 
                {
                    //2- 
                    List<TransactionResultDTO> result = new List<TransactionResultDTO>();
                    List<Transaction>? data = _transactionServices.GetAllWithAccounts();
                    if (data.Count > 0)
                    {
                        data.ForEach(d =>
                        {
                            #region CreationLists

                            AccountTypeDTO typeAccountDepo = new AccountTypeDTO() { Id = d.DepositAccount.Type.Id, Type= d.DepositAccount.Type.Type };
                            AccountTypeDTO typeAccountWithDr = new AccountTypeDTO() { Id = d.WithdrawAccount.Type.Id, Type = d.WithdrawAccount.Type.Type };
                            AccountDTO accountDepo = new AccountDTO() {
                                Id = d.DepositAccount.Id,
                                CurrentBalance = d.DepositAccount.CurrentBalance,
                                IsActive = d.DepositAccount.IsActive,
                                IsSuspended = d.DepositAccount.IsSuspended,
                                AccountNumber = d.DepositAccount.AccountNumber,
                                Type = typeAccountDepo,
                            };

                            AccountDTO accountWithDr = new AccountDTO()
                            {
                                Id = d.WithdrawAccount.Id,
                                CurrentBalance = d.WithdrawAccount.CurrentBalance,
                                IsActive = d.WithdrawAccount.IsActive,
                                IsSuspended = d.WithdrawAccount.IsSuspended,
                                AccountNumber = d.WithdrawAccount.AccountNumber,
                                Type = typeAccountWithDr,
                            };
                            #endregion

                            TransactionResultDTO tr = new TransactionResultDTO()
                            {
                                Id = d.Id,
                                TransactionDate = d.TransactionDate,
                                TransactionType = d.TransactionType,
                                Amount = d.Amount,
                                DepositAccount = accountDepo,
                                WithdrawAccount = accountWithDr,

                            };

                            result.Add(tr);
                        });
                    }
                    return Ok(result);
                }
                else { throw new Exception("You cannot search for transactions of an inactive account"); };
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/<TransactionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TransactionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TransactionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TransactionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
