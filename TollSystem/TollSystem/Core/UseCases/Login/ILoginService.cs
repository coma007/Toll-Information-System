using TollSystem.Core.Entities;

namespace TollSystem.Core.UseCases.Login
{
    public interface ILoginService
    {
        public StaffEntity Login(string username, string password);
    }
}