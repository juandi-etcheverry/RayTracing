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

        public IList<PositionedModel> Models { get; } = new List<PositionedModel>();

        public DateTime LastModificationDate { get; set; }

        public DateTime LastRenderDate { get; set; }

        public ClientScenePreferences ClientScenePreferences { get; set; }
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

        private void ThrowEmptyName()
        {
            throw new NameException("Scene name can't be empty");
        }

        public bool AreNamesEqual(string otherName)
        {
            return _name.ToLower() == otherName.ToLower();
        }

        private void ThrowHasTrailingSpaces()
        {
            throw new NameException("Scene name can't have trailing spaces");
        }
    }
}