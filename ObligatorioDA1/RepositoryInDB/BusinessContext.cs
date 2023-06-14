using System.Data.Entity;
using Domain;
using RepositoryInDB.DomainConfiguration;

namespace RepositoryInDB
{
    public class BusinessContext : DbContext
    {
        public BusinessContext() : base("DA1DB")
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Shape> Shapes { get; set; }
        public DbSet<Scene> Scenes { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ClientConfiguration.ConfigureEntity(modelBuilder);
            ModelConfiguration.ConfigureEntity(modelBuilder);
            ShapeConfiguration.ConfigureEntity(modelBuilder);
            SceneConfiguration.ConfigureEntity(modelBuilder);
            LogConfiguration.ConfigureEntity(modelBuilder);
        }
    }
}