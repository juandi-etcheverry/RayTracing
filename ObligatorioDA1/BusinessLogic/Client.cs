using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicExceptions;

namespace BusinessLogic
{
    public class Client : IDataEntity
    {
        private string _name;
        private string _password;
        private DateTime _registrationDate;

        private static uint MIN_NAME_LENGTH = 3;
        private static uint MAX_NAME_LENGTH = 20;
        private static uint MIN_PASSWORD_LENGTH = 5;
        private static uint MAX_PASSWORD_LENGTH = 25;
        public string Name
        {
            get => _name;
            set
            {
                if (!value.IsBetween(MIN_NAME_LENGTH, MAX_NAME_LENGTH)) ThrowNameNotInRange();
                if (value.HasSpaces()) ThrowHasSpaces();
                if (!value.IsAlphaNumeric()) ThrowNotAlphanumeric();
                _name = value;
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (!value.IsBetween(MIN_PASSWORD_LENGTH, MAX_PASSWORD_LENGTH)) ThrowPasswordNotInRange();
                if (!value.HasUpper()) ThrowPasswordNoCapitalLetter();
                if (!value.HasNumber()) ThrowNoNumberPassword();
                _password = value;
            }
        }

        public Client()
        {
            _registrationDate = DateTime.Now;
        }

        public bool AreNamesEqual(IDataEntity other)
        {
            Client otherClient = other as Client;
            return this.Name == otherClient.Name;
        }

        public void ThrowNameExists()
        {
            throw new UniqueNameException("Client name already exists");
        }
        public void ThrowNotAlphanumeric()
        {
            throw new AlphanumericNameException("Client name can't have non-alphanumeric characters");
        }
        public void ThrowHasSpaces()
        {
            throw new NoSpacesException("Client name can't have spaces");
        }

        public void ThrowNameNotInRange()
        {
            throw new NotInRangeException("Client name must be between 3 and 20 characters");
        }

        public void ThrowPasswordNotInRange()
        {
            throw new NotInRangeException("Client password must be between 5 and 25 characters");
        }

        public void ThrowPasswordNoCapitalLetter()
        {
            throw new NoCapitalLetterException("Client password must have at least one capital letter");
        }

        public void ThrowNoNumberPassword()
        {
            throw new NoNumberException("Client password must have at least one number");
        }
    }
}
