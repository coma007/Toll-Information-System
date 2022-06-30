using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    public interface IDamageRepositoryService : IRepositoryService<Damage>
    {
        public Damage FindByDeviceId(int id);
    }
}
