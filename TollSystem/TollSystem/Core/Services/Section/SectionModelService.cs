using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    class SectionModelService : ISectionModelService
    {
        public SectionEntity ModelToEntity(Section section, IRepositoryService<TollStationEntity> repository)
        {
            TollStationEntity station1 = repository.GetById(section.Tollstation1id);
            TollStationEntity station2 = repository.GetById(section.Tollstation2id);
            return new SectionEntity(section, station1, station2);
        }

        public Section EntityToModel(SectionEntity sectionEntity)
        {
            Section section = new Section();
            section.Id = sectionEntity.Id;
            section.Length = (decimal)sectionEntity.Length;
            section.Tollstation1id = sectionEntity.EntranceTollStation.Id;
            section.Tollstation2id = sectionEntity.ExitTollStation.Id;
            section.Isdeleted = 0;

            return section;
        }

        public SectionEntity ModelToEntity(Section section)
        {
            throw new NotImplementedException();
        }
    }
}
