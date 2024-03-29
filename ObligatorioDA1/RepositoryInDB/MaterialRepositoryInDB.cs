﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain;
using IRepository;

namespace RepositoryInDB
{
    public class MaterialRepositoryInDB : IRepositoryMaterial
    {
        public Material Add(Material material)
        {
            using (var context = new BusinessContext())
            {
                var loggedClient = context.Clients.FirstOrDefault(c => c.Name == material.Client.Name);
                material.Client = loggedClient;

                context.Materials.Add(material);
                context.SaveChanges();
            }

            return material;
        }

        public List<Material> FindMany(string name)
        {
            using (var context = new BusinessContext())
            {
                return context.Materials.Include(m => m.Client)
                    .Where(m => m.MaterialName.ToLower().Equals(name.ToLower())).ToList();
            }
        }

        public IList<Material> GetAll()
        {
            using (var context = new BusinessContext())
            {
                return context.Materials.Include(m => m.Client).ToList();
            }
        }

        public Material Remove(Material material)
        {
            using (var context = new BusinessContext())
            {
                var materialToRemove = context.Materials.FirstOrDefault(m => m.Id == material.Id);
                context.Materials.Remove(materialToRemove);
                context.SaveChanges();
                return materialToRemove;
            }
        }

        public Material Update(Material material)
        {
            using (var context = new BusinessContext())
            {
                var materialToUpdate = context.Materials.FirstOrDefault(m => m.Id == material.Id);
                materialToUpdate.MaterialName = material.MaterialName;
                context.SaveChanges();
                return materialToUpdate;
            }
        }
    }
}