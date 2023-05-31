using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using IRepository;

namespace RepositoryInDB
{
    public class SceneRepositoryInDB : IRepositoryScene
    {
        public Scene Add(Scene scene)
        {
            using (var context = new BusinessContext())
            {
                context.Scenes.Add(scene);
                context.SaveChanges();
            }
            return scene;
        }

        public IList<Scene> GetAll()
        {
            using (var context = new BusinessContext())
            {
                return context.Scenes.ToList();
            }
        }

        public Scene Remove(Scene scene)
        {
            using (var context = new BusinessContext())
            {
                context.Scenes.Remove(scene);
                context.SaveChanges();
            }
            return scene;
        }
    }
}
