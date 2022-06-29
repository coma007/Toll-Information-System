using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public class TicketModelService : ITicketModelService
    {
        public TicketEntity ModelToEntity(Ticket ticket)
        {
            TicketEntity ticketEntity = null;
            if (ticket.Isdeleted == 0)
                ticketEntity = new TicketEntity(ticket);
            return ticketEntity;
        }
    }
}
