using Domain;
using System.Data.Entity;

namespace RepositoryInDB.DomainConfiguration
{
    internal class ShapeConfiguration
    {
        public static void ConfigureEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shape>().ToTable("Shapes");
            modelBuilder.Entity<Sphere>().ToTable("Spheres");
        }
    }
}
