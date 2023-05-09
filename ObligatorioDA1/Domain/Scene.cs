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
        private ClientScenePreferences _clientScenePreferences = new ClientScenePreferences();

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
            PositionedModel newPositionedModel = new PositionedModel(model, coordinates);
            _models.Add(newPositionedModel);
            _lastModificationDate = DateTime.Now;
            return newPositionedModel;
        }

        public void DeletePositionedModel(string name, ValueTuple<decimal, decimal, decimal> coordinates)
        {
            PositionedModel positionedModel = GetPositionedModel(name, coordinates);
            _lastModificationDate = DateTime.Now;
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

        public ClientScenePreferences ClientScenePreferences
        {
            get => _clientScenePreferences;
            set => _clientScenePreferences = value;
        }

        public Scene()
        {
            _lastModificationDate = DateTime.Now;
            _registrationDate = DateTime.Now;
            _clientScenePreferences = new ClientScenePreferences();
        }

        public static void ThrowClientNotLoggedIn()
        {
            throw new SessionException("Client not logged in");
        }

        private static void ThrowEmptyName()
        {
            throw new NameException("Scene name can't be empty");
        }

        public static void ThrowNotFound()
        {
            throw new NotFoundException("Scene not found");
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
