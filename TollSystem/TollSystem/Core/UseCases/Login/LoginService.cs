using System.Collections.Generic;
using TollSystem.Core.Entities;
using TollSystem.Core.Services.Users;

namespace TollSystem.Core.UseCases
{
    public class LoginService
    {
        private IStaffRepositoryService _repository;

        public LoginService(IStaffRepositoryService repository)
        {
            _repository = repository;
        }

        private StaffEntity findUser(string username, string password)
        {
            StaffEntity user = _repository.FindByCredentials(username, password);

            return user;
        }

        public StaffEntity Login(string username, string password)
        {
            StaffEntity user = findUser(username, password);
            return user;
        }
    }
}