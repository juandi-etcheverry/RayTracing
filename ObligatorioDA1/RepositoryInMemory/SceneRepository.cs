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

        public void AddModel(Scene scene, PositionedModel model)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteModel(Scene scene, PositionedModel model)
        {
            throw new System.NotImplementedException();
        }

        public Scene Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IList<Scene> GetAll()
        {
            return _scenes;
        }

        public PositionedModel GetModel(Scene scene, string modelName)
        {
            throw new System.NotImplementedException();
        }

        public Scene Remove(Scene scene)
        {
            _scenes.Remove(scene);
            return scene;
        }

        public Scene Update(Scene x, string newName)
        {
            throw new System.NotImplementedException();
        }
    }
}