using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BusinessLogicExceptions;
using ValidationService;

namespace Domain
{
    public class Scene
    {
        private string _name;


        public Scene()
        {
            LastModificationDate = DateTime.Now;
            RegistrationDate = DateTime.Now;
            ClientScenePreferences = new ClientScenePreferences();
        }

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

        public string OwnerName { get; set; }

        public DateTime RegistrationDate { get; set; }

        public IList<PositionedModel> Models { get; set; } = new List<PositionedModel>();

        public DateTime LastModificationDate { get; set; }

        public DateTime LastRenderDate { get; set; }

        public ClientScenePreferences ClientScenePreferences { get; set; } = new ClientScenePreferences();
        public Bitmap Preview = null;

        public PositionedModel AddPositionedModel(Model model, ValueTuple<decimal, decimal, decimal> coordinates)
        {
            var newPositionedModel = new PositionedModel(model, coordinates);
            Models.Add(newPositionedModel);
            LastModificationDate = DateTime.Now;
            return newPositionedModel;
        }

        public void DeletePositionedModel(string name, ValueTuple<decimal, decimal, decimal> coordinates)
        {
            var positionedModel = GetPositionedModel(name, coordinates);
            LastModificationDate = DateTime.Now;
            Models.Remove(positionedModel);
        }

        public PositionedModel GetPositionedModel(string name, ValueTuple<decimal, decimal, decimal> coordinates)
        {
            var positionedModel =
                Models.FirstOrDefault(model => model.Name == name && model.Coordinates == coordinates);
            return positionedModel;
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