using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInDB.DomainConfiguration
{
    public class SceneConfiguration
    {
        public static void ConfigureEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Scene>().Property(s => s.RegistrationDate).HasColumnType("datetime2");
            modelBuilder.Entity<Scene>().Property(s => s.LastModificationDate).HasColumnType("datetime2");
            modelBuilder.Entity<Scene>().Property(s => s.LastRenderDate).HasColumnType("datetime2");

            modelBuilder.Entity<PositionedModel>()
                .HasKey(p => p.Id)
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
