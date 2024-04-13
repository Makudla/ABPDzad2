using LegacyApp.Models;
using System;
namespace LegacyApp.Core.Interfaces
{
    public interface IUserCreditService
    {
        int GetCreditLimit(string lastName);
    }
}
