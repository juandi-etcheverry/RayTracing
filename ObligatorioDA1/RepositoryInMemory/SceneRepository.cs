using System.Collections.Generic;
using System.Linq;
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