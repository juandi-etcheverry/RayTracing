using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public void DeleteModel(Scene scene, PositionedModel model)
        {
            throw new NotImplementedException();
        }

        public Scene Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Scene> GetAll()
        {
            return _scenes;
        }

        public PositionedModel GetModel(Scene scene, int idModel)
        {
            throw new NotImplementedException();
        }

        public Scene Remove(Scene scene)
        {
            _scenes.Remove(scene);
            return scene;
        }

        public Scene Update(Scene x)
        {
            throw new NotImplementedException();
        }
    }
}