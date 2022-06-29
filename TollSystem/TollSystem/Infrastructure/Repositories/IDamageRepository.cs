using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Infrastructure.Repositories
{
    public interface IDamageRepository : IRepository<Damage>
    {
        public Damage FindByDeviceId(int id);
    }
}
