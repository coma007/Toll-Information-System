using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    class PriceModelService : IPriceModelService
    {
        public PriceEntity ModelToEntity(Price price, IRepositoryService<SectionEntity> repository)
        {
            if (price.Isdeleted == 1) return null;
            SectionEntity section = repository.GetById(price.Sectionid);
            return new PriceEntity(price, section);
        }
    }
}
