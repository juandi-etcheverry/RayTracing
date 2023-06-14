using System.Data.Entity;
using Domain;

namespace RepositoryInDB.DomainConfiguration
{
    public class SceneConfiguration
    {
        public static void ConfigureEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Scene>().Property(s => s.RegistrationDate).HasColumnType("datetime2");
            modelBuilder.Entity<Scene>().Property(s => s.LastModificationDate).HasColumnType("datetime2");
            modelBuilder.Entity<Scene>().Property(s => s.LastRenderDate).HasColumnType("datetime2");

            modelBuilder.Entity<Scene>()
                .HasMany(s => s.Models)
                .WithRequired(pm => pm.Scene)
                .WillCascadeOnDelete(true);
        }
    }
}