using LegacyApp.Models;
using LegacyApp.Core.Interfaces;

namespace LegacyApp.Core.DAL.Services
{
    internal class UserDataAccessAdapter : IUserDataAccessAdapter
    {
        public void AddUser(User user)
        {
            UserDataAccess.AddUser(user);
        }
    }
}
