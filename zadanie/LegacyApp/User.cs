using System;

namespace LegacyApp
{
    public class User
    {
        public object Client { get; internal set; }

        public DateTime DateOfBirth { get; internal set; }

        public string EmailAddress { get; internal set; }

        public string FirstName { get; internal set; }

        public string LastName { get; internal set; }

        public bool HasCreditLimit { get; internal set; }

        public int CreditLimit { get; internal set; }

        
        public void EstablishCreditLimit(Client client)
        {
            switch (client.Type)
            {
                case "VeryImportantClient":
                    HasCreditLimit = false;
                    break;
                case "ImportantClient":
                {
                    using (var userCreditService = new UserCreditService())
                    {
                        var creditLimit = userCreditService.GetCreditLimit(LastName);
                        creditLimit *= 2;
                        CreditLimit = creditLimit;
                    }

                    break;
                }
                default:
                {
                    HasCreditLimit = true;
                    using (var userCreditService = new UserCreditService())
                    {
                        var creditLimit = userCreditService.GetCreditLimit(LastName);
                        CreditLimit = creditLimit;
                    }

                    break;
                }
            }
        }
    }
}