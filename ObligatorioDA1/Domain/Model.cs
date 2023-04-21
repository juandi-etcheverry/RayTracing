using BusinessLogicExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Model
    {
        private string _name;
        private Shape _shape;
        private Material _material;
        private string _ownerName;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public Shape Shape
        {
            get => _shape;
            set => _shape = value;
        }

        public Material Material
        {
            get => _material;
            set => _material = value;
        }

        public string OwnerName
        {
            get => _ownerName;
            set => _ownerName = value;
        }

        public static void ThrowClientNotLoggedIn()
        {
            throw new SessionException("Client needs to be logged in to create new model");
        }
    }
}
