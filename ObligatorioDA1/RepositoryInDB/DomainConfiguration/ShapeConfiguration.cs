using System.Data.Entity;
using Domain;

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