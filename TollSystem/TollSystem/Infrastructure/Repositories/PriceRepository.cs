using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Infrastructure.Repositories
{
    public class PriceRepository : Repository<Price>, IPriceRepository
    {
        public PriceRepository(ModelContext context) : base(context, context.Price)
        {
        }

        public List<Price> FindByPricelistId(int id)
        {
            return _table.Where(p => p.Pricelistid == id).ToList();
        }

        public List<Price> FindByPricelistAndSectionId(int pricelistId, int sectionId)
        {
            return _table.Where(p => p.Pricelistid == pricelistId && p.Sectionid == sectionId).ToList();
        }
    }
}
