using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInDB.DomainConfiguration
{
    internal class LogConfiguration
    {
        public static void ConfigureEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>().Property(l => l.RenderDate).HasColumnType("datetime2");
            modelBuilder.Entity<Log>().Property(l => l.RenderWindow).HasColumnType("datetime2");
        }
    }
}
