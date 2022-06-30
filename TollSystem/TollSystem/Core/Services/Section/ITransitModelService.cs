using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public interface ITransitModelService
    {
        public TransitEntity ModelToEntity(Transit transit, ITollBoothRepositoryService service, TollBoothModelService tollBoothModel,
            IDeviceRepositoryService repository);
    }
}
