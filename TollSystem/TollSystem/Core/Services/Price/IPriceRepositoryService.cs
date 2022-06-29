using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public interface IPriceRepositoryService
    {
        public List<Price> FindByPricelistId(int id);
        public List<Price> FindByPricelistAndSectionId(int pricelistId, int sectionId);
    }
}
