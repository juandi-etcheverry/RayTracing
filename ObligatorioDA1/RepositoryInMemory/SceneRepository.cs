using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using IRepository;

namespace RepositoryInMemory
{
    public class SceneRepository : IRepositoryScene
    {
        private static readonly IList<Scene> _scenes = new List<Scene>();

        public Scene Add(Scene scene)
        {
            _scenes.Add(scene);
            return scene;
        }

        public Scene Get(string name)
        {
            return _scenes.FirstOrDefault(s => s.Name.ToLower() == name.ToLower());
        }

        public IList<Scene> GetAll()
        {
            return _scenes;
        }

        public Scene Remove(Scene scene)
        {
            _scenes.Remove(scene);
            return scene;
        }
    }
}
