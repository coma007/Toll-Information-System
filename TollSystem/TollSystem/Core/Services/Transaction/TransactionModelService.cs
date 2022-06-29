using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public class TransactionModelService
    {
        public TransactionEntity ModelToEntity(Transaction transaction)
        {
            if (transaction.Isdeleted == 1) return null;
            TransactionEntity transactionEntity = new TransactionEntity(transaction);
            return transactionEntity;
        }

        public Transaction EntityToModel(TransactionEntity transactionEntity)
        {
            Transaction transaction = new Transaction();
            transaction.Id = transactionEntity.Id;
            transaction.Price = transactionEntity.Price;
            transaction.Currency = transactionEntity.Currency.ToString();
            transaction.Isdeleted = 0;
            transaction.Transitid = transactionEntity.Transit.Id;

            return transaction;
        }
    }
}
