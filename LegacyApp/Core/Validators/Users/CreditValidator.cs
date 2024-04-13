using LegacyApp.Models;
using LegacyApp.Core.Interfaces;

namespace LegacyApp.Core.Validators.Users
{
    public class CreditValidator : ICreditValidator
    {
        public bool ValidateCreditLimit(User user)
        {
            return user.CreditLimit >= 500 || !user.HasCreditLimit;
        }
    }
}
