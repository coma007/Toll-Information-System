using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Enumerations;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Infrastructure.Repositories
{
    public interface IPriceRepository : IRepository<Price>
    {
        public List<Price> FindByPricelistId(int id);
        public List<Price> FindByPricelistAndSectionId(int pricelistId, int sectionId);
        public Price FindBiggestPrice(int pricelistId, VehicleCategory category);
    }
}
