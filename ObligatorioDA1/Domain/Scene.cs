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
                if (value.IsEmpty()) ThrowEmptyName();
                if (value.HasTrailingSpaces()) ThrowHasTrailingSpaces();
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

        public PositionedModel AddPositionedModel(Model model, ValueTuple<decimal, decimal, decimal> coordinates)
        {
            PositionedModel newPositionedModel = CreatePositionedModel(model, coordinates);
            _models.Add(newPositionedModel);
            _lastModificationDate = DateTime.Today;
            return newPositionedModel;
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

        public void DeletePositionedModel(string name, ValueTuple<decimal, decimal, decimal> coordinates)
        {
            PositionedModel positionedModel = GetPositionedModel(name, coordinates);
            _lastModificationDate = DateTime.Today;
            _models.Remove(positionedModel);
        }

        public PositionedModel GetPositionedModel(string name, ValueTuple<decimal, decimal, decimal> coordinates)
        {
            PositionedModel positionedModel = _models.FirstOrDefault(model => model.Name == name && model.Coordinates == coordinates);
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
            set
            {
                if (value < 1 || value > 160) ThrowFoVOutOfRange();
                _fov = value;
            }
        }

        public Scene()
        {
            _lastModificationDate = DateTime.Today;
            _registrationDate = DateTime.Today;
            _lookfrom = (0, 2, 0);
            _lookat = (0, 2, 5);
            _fov = 30;
        }

        public static void ThrowClientNotLoggedIn()
        {
            throw new SessionException("Client not logged in");
        }

        private static void ThrowEmptyName()
        {
            throw new NameException("Scene name can't be empty");
        }

        public bool AreNamesEqual(string otherName)
        {
            return _name.ToLower() == otherName.ToLower();
        }

        public static void ThrowNameExists()
        {
            throw new NameException("Scene name already exists");
        }

        public void ThrowHasTrailingSpaces()
        {
            throw new NameException("Scene name can't have trailing spaces");
        }

        public void ThrowFoVOutOfRange()
        {
            throw new ArgumentOutOfRangeException("FoV must be between 1 and 160");
        }
    }
}
