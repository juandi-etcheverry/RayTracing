using BusinessLogicExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationService;

namespace Domain
{
    public class Scene
    {
        private string _name;
        private string _ownerName;
        private DateTime _registrationDate;
        private IList<PositionedModel> _models = new List<PositionedModel>();
        private DateTime _lastModificationDate;
        private DateTime _lastRenderDate;
        private ValueTuple<decimal, decimal, decimal> _lookfrom;
        private ValueTuple<decimal, decimal, decimal> _lookat;
        private uint _fov;

        public string Name
        {
            get => _name;
            set
            {
                if (value.IsEmpty()) throw new NameException("Scene name can't be empty");
                _name = value;
            }
        }

        public string OwnerName
        {
            get => _ownerName;
            set => _ownerName = value;
        }

        public DateTime RegistrationDate
        {
            get => _registrationDate;
            set => _registrationDate = value;
        }

        public IList<PositionedModel> Models
        {
            get => _models;
            set => _models = value;
        }

        public void AddPositionedModel(Model model, ValueTuple<decimal, decimal, decimal> coordinates)
        {
            PositionedModel newPositionedModel = CreatePositionedModel(model, coordinates);
            _models.Add(newPositionedModel);
        }

        private PositionedModel CreatePositionedModel(Model model, ValueTuple<decimal, decimal, decimal> coordinates)
        {
            PositionedModel positionedModel = new PositionedModel()
            {
                Name = model.Name,
                OwnerName = model.OwnerName,
                Shape = model.Shape,
                Material = model.Material,
                Coordinates = coordinates
            };

            return positionedModel;
        }

        public DateTime LastModificationDate
        {
            get => _lastModificationDate;
            set => _lastModificationDate = value;
        }

        public DateTime LastRenderDate
        {
            get => _lastRenderDate;
            set => _lastRenderDate = value;
        }

        public ValueTuple<decimal, decimal, decimal> LookFrom
        {
            get => _lookfrom;
            set => _lookfrom = value;
        }

        public ValueTuple<decimal, decimal, decimal> LookAt
        {
            get => _lookat;
            set => _lookat = value;
        }

        public uint FoV
        {
            get => _fov;
            set => _fov = value;
        }

        public static void ThrowClientNotLoggedIn()
        {
            throw new SessionException("Client not logged in");
        }
    }
}
