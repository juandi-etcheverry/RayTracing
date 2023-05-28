using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInDB.DomainConfiguration
{
    internal class ClientScenePreferencesConfiguration
    {
        public static void ConfigureEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientScenePreferences>().HasKey(c => c.Id);
            modelBuilder.Entity<ClientScenePreferences>().Property(c => c.FoVDefault).HasColumnName("FoVDefault");
        }
    }
}
