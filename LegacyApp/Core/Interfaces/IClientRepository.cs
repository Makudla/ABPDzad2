using LegacyApp.Models;

namespace LegacyApp.Core.Interfaces
{
    public interface IClientRepository
    {
        Client GetById(int clientId);
    }
}
