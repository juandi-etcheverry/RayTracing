using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInDB
{
    public class ClearDatabase
    {
        private static void ClearClients()
        {
            using (var context = new BusinessContext())
            {
                context.Clients.RemoveRange(context.Clients);
                context.SaveChanges();
            }
        }

        private static void ClearMaterials()
        {
            using (var context = new BusinessContext())
            {
                context.Materials.RemoveRange(context.Materials);
                context.SaveChanges();
            }
        }

        private static void ClearShapes()
        {
            using (var context = new BusinessContext())
            {
                context.Shapes.RemoveRange(context.Shapes);
                context.SaveChanges();
            }
        }

        private static void ClearModels()
        {
            using (var context = new BusinessContext())
            {
                context.Models.RemoveRange(context.Models);
                context.SaveChanges();
            }
        }

        private static void ClearScenes()
        {
            using (var context = new BusinessContext())
            {
                context.Scenes.RemoveRange(context.Scenes);
                context.SaveChanges();
            }
        }

        public static void ClearAll()
        {
            ClearScenes();
            ClearModels();
            ClearShapes();
            ClearMaterials();
            ClearClients();
        }
    }
}
