using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace BusinessLogic
{
    internal static class Session
    {
        private static Client _loggedClient;

        internal static Client LoggedClient
        {
            get => _loggedClient;
            set => _loggedClient = value;
        }
    }
}
