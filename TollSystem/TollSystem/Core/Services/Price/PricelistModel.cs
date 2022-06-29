using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public class PricelistModel : IPricelistModel
    {
        public PricelistEntity ModelToEntity(Pricelist pricelist)
        {
            return new PricelistEntity(pricelist);
        }
    }
}
