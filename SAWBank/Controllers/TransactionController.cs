using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult GetAll([FromBody]int accountId)
        {
            bool IsConnected = User != null;
            if (IsConnected)
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
                                    Id = d.Id ?? 0 ,
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
            else
            {
                return Unauthorized();
            }
        }

        //TODO -[Post] AddMoney(INT){}  --> money *100 , so no rounding errors
        //Respons --> only ok (200)
        // POST api/<TransactionController>
        [HttpPost]
        [Authorize]
        public IActionResult AddMoney([FromBody] int money, [FromBody]int accountId)
        {
            bool isConnected = User != null;
            if (isConnected)
            {
                Account? account = _accountServices.FindById(accountId);
                if(account != null && account.IsActive == true && account.IsSuspended == false)
                {
                    account.CurrentBalance = account.CurrentBalance + (money * 100);
                    _accountServices.Update(account);
                    Transaction newTransaction = new Transaction()
                    {
                        TransactionDate = DateTime.Now,
                        TransactionType = TransactionTypeEnum.BankTransfer, 
                        Amount = money,
                        DepositAccount = account,
                        WithdrawAccount = account
                    };

                    _transactionServices.AddMoney(newTransaction, accountId,accountId);

                    return Ok();
                }
                else
                {
                    throw new Exception("No account found");
                }

            }
            else 
            { 
                return Unauthorized();
            }


        }

    }
}
