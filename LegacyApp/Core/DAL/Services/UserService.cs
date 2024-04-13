using LegacyApp.Core.Interfaces;
using LegacyApp.Models;
using System;

namespace LegacyApp.Core.DAL.Services
{
    public class UserService
    {
        private readonly IInputValidator inputValidator;
        private readonly IClientRepository clientRepository;
        private readonly IUserCreditService userCreditService;
        private readonly IUserDataAccessAdapter userDataAccessAdapter;
        private readonly ICreditValidator creditValidator;

        public UserService(
            IInputValidator inputValidator,
            IClientRepository clientRepository,
            IUserCreditService userCreditService,
            IUserDataAccessAdapter userDataAccessAdapter,
            ICreditValidator creditValidator)
        {
            this.inputValidator = inputValidator;
            this.clientRepository = clientRepository;
            this.userCreditService = userCreditService;
            this.userDataAccessAdapter = userDataAccessAdapter;
            this.creditValidator = creditValidator;
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!ValidateInput(firstName, lastName, email, dateOfBirth))
                return false;

            var client = clientRepository.GetById(clientId);
            var user = CreateUser(firstName, lastName, email, dateOfBirth, client);

            return creditValidator.ValidateCreditLimit(user) && AddUserToDatabase(user);
        }

        private bool ValidateInput(string firstName, string lastName, string email, DateTime dateOfBirth) =>
            inputValidator.ValidateName(firstName, lastName) &&
            inputValidator.ValidateEmail(email) &&
            inputValidator.ValidateAge(dateOfBirth);

        private User CreateUser(string firstName, string lastName, string email, DateTime dateOfBirth, Client client) =>
            IUserFactory.GetInstanceForTypeOrDefaultToNormal(client.Type).CreateUser(firstName, lastName, email, dateOfBirth, client, userCreditService);

        private bool AddUserToDatabase(User user)
        {
            userDataAccessAdapter.AddUser(user);
            return true;
        }
    }
}
