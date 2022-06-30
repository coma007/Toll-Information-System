using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public interface ISectionModelService
    {
        public SectionEntity ModelToEntity(Section section);
        public Section EntityToModel(SectionEntity entitiy);

    }
}
