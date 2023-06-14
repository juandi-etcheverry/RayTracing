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

        private static void ClearLogs()
        {
            using (var context = new BusinessContext())
            {
                context.Logs.RemoveRange(context.Logs);
                context.SaveChanges();
            }
        }

        public static void ClearAll()
        {
            ClearLogs();
            ClearScenes();
            ClearModels();
            ClearShapes();
            ClearMaterials();
            ClearClients();
        }
    }
}