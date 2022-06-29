using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Services
{
    class StaffModelService : IStaffModelService
    {

        public StaffEntity ModelToEntity(Staff s)
        {
            StaffEntity staff = null;
            switch (s.Role)
            {
                case "REFERENT":
                    staff = new ReferentEntity(s, "l");
                    break;
                case "STATIONMASTER":
                    staff = new StationMasterEntity(s, "l");
                    break;
                case "MANAGER":
                    staff = new ManagerEntity(s);
                    break;
                case "ADMINISTRATOR":
                    staff = new AdministratorEntity(s);
                    break;
            }

            return staff;
        }
    }
}
