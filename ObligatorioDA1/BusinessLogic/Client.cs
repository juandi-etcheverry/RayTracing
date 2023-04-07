using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Client : IDataEntity
    {
        private string _name;
        private string _password;
        private DateTime _registrationDate;

        public static uint MIN_NAME_LENGTH = 3;
        public static uint MAX_NAME_LENGTH = 20;
        public static uint MIN_PASSWORD_LENGTH = 5;
        public static uint MAX_PASSWORD_LENGTH = 25;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public Client() { }

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
        public void ThrowHasNoSpaces()
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
    }
}
