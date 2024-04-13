using System;

namespace LegacyApp.Core.Interfaces
{
    public interface IInputValidator
    {
        bool ValidateAge(DateTime dateOfBirth);
        bool ValidateEmail(string email);
        bool ValidateName(string firstName, string lastName);
    }
}
