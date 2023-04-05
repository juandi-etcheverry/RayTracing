using System;

namespace BusinessLogic
{
    public class Client
    {
        private string _name;
        private string _password;
        private DateTime _registrationDate;

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

        public Client(){}
    }
}