using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    public class TicketRepositoryService : ITicketRepositoryService
    {
        private IRepository<Ticket> _repository;

        public TicketRepositoryService(IRepository<Ticket> repository)
        {
            _repository = repository;
        }
    }
}
