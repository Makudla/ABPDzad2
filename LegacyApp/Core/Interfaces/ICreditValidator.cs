using LegacyApp.Models;

namespace LegacyApp.Core.Interfaces
{
    public interface ICreditValidator
    {
        bool ValidateCreditLimit(User user);
    }
}
