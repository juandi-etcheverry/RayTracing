using System.Data.Entity;
using Domain;

namespace RepositoryInDB.DomainConfiguration
{
    internal class LogConfiguration
    {
        public static void ConfigureEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>().Property(l => l.RenderDate).HasColumnType("datetime2");
        }
    }
}