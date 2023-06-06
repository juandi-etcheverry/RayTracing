﻿using System.Data.Entity;
using Domain;

namespace RepositoryInDB.DomainConfiguration
{
    internal class ClientConfiguration
    {
        public static void ConfigureEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasKey(c => c.Name);
        }
    }
}