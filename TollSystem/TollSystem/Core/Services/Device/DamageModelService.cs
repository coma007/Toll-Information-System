using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public class DamageModelService : IDamageModelService
    {
        public DamageEntity ModelToEntity(Damage damage)
        {
            DamageEntity damageEntity = new DamageEntity(damage);
            return damageEntity;
        }
    }
}
