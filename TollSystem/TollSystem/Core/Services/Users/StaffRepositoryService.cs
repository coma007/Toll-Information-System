using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Core.Services.Users;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    class StaffRepositoryService : IStaffRepositoryService
    {
        private IStaffModelService _modelService;
        private IStaffRepository _repository;
        private IStationRepositoryService _stations;

        public StaffRepositoryService(IStaffRepository repository, IStaffModelService modelService, IStationRepositoryService stations)
        {
            _repository = repository;
            _modelService = modelService;
            _stations = stations;
        }

        public List<StaffEntity> GetAll()
        {
            List<StaffEntity> staff = new List<StaffEntity>();
            
            foreach (Staff s in _repository.GetAll())
            {
                staff.Add(_modelService.ModelToEntity(s));
            }

            return staff;
        }

        public StaffEntity FindByCredentials(string username, string password)
        {
            Staff user = _repository.FindByCredentials(username, password);

            Tollstation station = _stations.FindById((int)user.Stationid);
            return _modelService.ModelToEntity(user);
        }
    }
}
