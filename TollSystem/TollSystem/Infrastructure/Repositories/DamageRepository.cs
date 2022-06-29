using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Infrastructure.Repositories
{
    class DamageRepository : Repository<Damage>, IDamageRepository
    {
        public DamageRepository(ModelContext m) : base(m, m.Damage)
        { }

        public Damage FindByDeviceId(int id)
        {
            Damage damage = _table.Where(t => id == t.Deviceid).ToList()[0];
            return damage;
        }

    }
}
