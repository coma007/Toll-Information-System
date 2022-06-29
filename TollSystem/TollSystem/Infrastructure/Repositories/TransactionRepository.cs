using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Infrastructure.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ModelContext context) : base(context, context.Transaction)
        {
        }

        public Transaction FindByTransitId(int id)
        {
            Transaction transaction = _table.Where(t => t.Transitid == id).ToList()[0];

            return transaction;
        }
    }
}
