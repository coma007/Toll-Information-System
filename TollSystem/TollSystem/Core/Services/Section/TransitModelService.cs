using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    class TransitModelService : ITransitModelService
    {
        public TransitEntity ModelToEntity(Transit transit)
        {
            if (transit.Isdeleted == 1) return null;
            TransitEntity transitEntity = new TransitEntity(transit);
            return transitEntity;
        }

    }
}
