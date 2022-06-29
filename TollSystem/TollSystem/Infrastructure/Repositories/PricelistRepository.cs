using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Infrastructure.Repositories
{
    public class PricelistRepository : Repository<Pricelist>, IPricelistRepository
    {
        public PricelistRepository(ModelContext context) : base(context, context.Pricelist)
        {
        }

        public Pricelist FindActive()
        {
            return _table.Where(t => t.Isactive == 1).ToList()[0];
        }
    }
}
