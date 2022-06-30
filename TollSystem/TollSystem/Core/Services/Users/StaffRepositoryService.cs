using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Entities;
using TollSystem.Core.Services;
using TollSystem.Infrastructure.Models;
using TollSystem.Infrastructure.Repositories;

namespace TollSystem.Core.Services
{
    class StaffRepositoryService : IStaffRepositoryService
    {
        private IStaffModelService _modelService;
        private IStaffRepository _repository;
        //ovo promeni
        private ITollStationRepositoryService _stations;

        public StaffRepositoryService(IStaffRepository repository, IStaffModelService modelService, ITollStationRepositoryService stations)
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
            if (user is null)
            {
                return null;
            }

            if (user.Role.Equals("REFERENT") || user.Role.Equals("STATIONMASTER"))
            {
                Tollstation station = _stations.FindById((int)user.Stationid);
                user.Station = station;
            }

            return _modelService.ModelToEntity(user);
        }

        public Staff FindMasterByStation(int id)
        {
            return _repository.FindMasterByStation(id);
        }
    }
}
