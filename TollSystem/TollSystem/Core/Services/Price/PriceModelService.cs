using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    class PriceModelService : IPriceModelService
    {
        private IRepository<Section> _sections;
        private ITollStationRepositoryService _tollStation;

        public PriceModelService(IRepository<Section> sections, ITollStationRepositoryService tollStation)
        {
            _sections = sections;
            _tollStation = tollStation;
        }

        public PriceEntity ModelToEntity(Price price)
        {
            if (price.Isdeleted == 1) return null;
            SectionEntity section = null;
            if (!(price.Sectionid is null))
            {
                Section s = _sections.GetById(price.Sectionid);
                Tollstation st1 = _tollStation.FindById((int)s.Tollstation1id);
                Tollstation st2 = _tollStation.FindById((int)s.Tollstation2id);
                section = new SectionEntity()
                {
                    EntranceTollStation = new TollStationEntity((int)st1.Id, st1.Name),
                    ExitTollStation = new TollStationEntity((int)st2.Id, st2.Name)
                };
            }
            
            return new PriceEntity(price, section);
        }
    }
}
