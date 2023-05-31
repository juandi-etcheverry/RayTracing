using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryInDB.DomainConfiguration;

namespace RepositoryInDB
{
    public class BusinessContext: DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Shape> Shapes { get; set; }
        public DbSet<Scene> Scenes { get; set; }

        public BusinessContext(): base("DA1DB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ClientConfiguration.ConfigureEntity(modelBuilder);
            ModelConfiguration.ConfigureEntity(modelBuilder);
            ShapeConfiguration.ConfigureEntity(modelBuilder);
        }

    }
}
