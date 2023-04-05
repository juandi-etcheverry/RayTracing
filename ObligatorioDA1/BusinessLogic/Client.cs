using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Client: DataEntity
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

            public Client() { }

            public bool AreNamesEqual(Client other)
            {
                return this.Name == other.Name;
            }

            public override void ThrowNameExists()
            {
                throw new UniqueNameException("Client name already exists");
            }
    }
    }
