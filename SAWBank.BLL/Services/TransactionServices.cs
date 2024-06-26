﻿using SAWBank.BLL.Interfaces;
using SAWBank.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAWBank.BLL.Services
{
    public class TransactionServices(ITransactionRepository transactionRepository)
    {
        public void AddMoney(Transaction newTransaction, int accountDepo, int accountWithDraw)
        {
            transactionRepository.AddMoney(newTransaction, accountDepo, accountWithDraw);
        }

        //return All transaction without joins
        public List<Transaction>? GetAllTest()
        {
            return transactionRepository.FindAll();
        }

        public List<Transaction>? GetAllWithAccounts() 
        {
            return transactionRepository.GetAllWithAccounts();
        }
    }
}
