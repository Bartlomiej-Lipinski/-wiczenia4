using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (IsNameValid(firstName) || IsLastNameValid(lastName))
            {
                return false;
            }
            if (IsEmailValid(email))
            {
                return false;
            }
            var age = CalculateAge(dateOfBirth);
            if (age < 21)
            {
                return false;
            }
            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);
            var user = new User()
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };
            user.EstablishCreditLimit(client);
            if (IsClientWorthAdding(user))
            {
                return false;
            }
            UserDataAccess.AddUser(user);
            return true;
        }
        private static bool IsClientWorthAdding(User user)
        {
            return user.HasCreditLimit && user.CreditLimit < 500;
        }
        private static int CalculateAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
            return age;
        }
        private static bool IsEmailValid(string email)
        {
            return !email.Contains('@') && !email.Contains('.');
        }
        private static bool IsNameValid(string firstName)
        {
            return string.IsNullOrEmpty(firstName);
        }
        private static bool IsLastNameValid(string firstName)
        {
            return string.IsNullOrEmpty(firstName);
        }
    }
}
