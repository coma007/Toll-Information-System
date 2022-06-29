using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    public class  TransactionRepositoryService : RepositoryService<Transaction>, ITransactionRepositoryService
    {
        public TransactionRepositoryService(IRepository<Transaction> repository) : base(repository)
        {

        }
    }
}
