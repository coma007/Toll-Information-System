using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public interface ITransactionRepositoryService
    {
        public Transaction FindByTransitId(int id);
    }
}
