using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public class PricelistModelService : IPricelistModelService
    {
        public PricelistEntity ModelToEntity(Pricelist pricelist)
        {
            if (pricelist.Isdeleted == 1) return null;
            return new PricelistEntity(pricelist);
        }
    }
}
