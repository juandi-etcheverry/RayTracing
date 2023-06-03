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
        private string _sceneName;
        public int Id { get; set; }
        public Client Client { get; set; }
        public DateTime RegistrationDate { get; set; }
        public IList<PositionedModel> Models { get; set; }
        public DateTime LastModificationDate { get; set; }
        public DateTime LastRenderDate { get; set; }
        public ClientScenePreferences ClientScenePreferences { get; set; }
        public Bitmap Preview = null;


        public Scene()
        {
            LastModificationDate = DateTime.Now;
            RegistrationDate = DateTime.Now;
            ClientScenePreferences = new ClientScenePreferences();
        }

        public string SceneName
        {
            get => _sceneName;
            set
            {
                if (value.IsEmpty()) ThrowEmptyName();
                if (value.HasTrailingSpaces()) ThrowHasTrailingSpaces();
                _sceneName = value;
            }
        }

        private void ThrowEmptyName()
        {
            throw new NameException("Scene name can't be empty");
        }

        public bool AreNamesEqual(string otherName)
        {
            return _sceneName.ToLower() == otherName.ToLower();
        }

        private void ThrowHasTrailingSpaces()
        {
            throw new NameException("Scene name can't have trailing spaces");
        }
    }
}