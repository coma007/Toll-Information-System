using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public interface IDamageModelService
    {
        public DamageEntity ModelToEntity(Damage damage);
    }
}
