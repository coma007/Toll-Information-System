using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Infrastructure.Repositories
{
    public interface IPricelistRepository : IRepository<Pricelist>
    {
        public Pricelist FindActive();
    }
}
