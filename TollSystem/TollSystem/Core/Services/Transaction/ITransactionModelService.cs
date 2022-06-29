using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using TollSystem.Core.Entities;

namespace TollSystem.Core.Services
{
    public interface ITransactionModelService
    {
        public TransactionEntity ModelToEntity(Transaction transaction);

        public Transaction EntityToModel(TransactionEntity transactionEntity);
    }
}
