using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    public class  TransactionRepositoryService : RepositoryService<Transaction>, ITransactionRepositoryService
    {
        private ITransactionRepository _repository;
        public TransactionRepositoryService(ITransactionRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Transaction FindByTransitId(int id)
        {
            return _repository.FindByTransitId(id);
        }
    }
}
