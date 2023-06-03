using System.Collections.Generic;
using System.Linq;
using BusinessLogicExceptions;
using Domain;
using IRepository;
using RepositoryInDB;
using RepositoryInMemory;

namespace BusinessLogic
{
    public class MaterialLogic
    {
        private readonly IRepositoryMaterial _repository = new MaterialRepositoryInDB();

        public IList<Material> GetAll()
        {
            return _repository.GetAll();
        }

        public IList<Material> GetClientMaterials()
        {
            EnsureClientIsLoggedIn();
            return _repository.GetAll().Where(material => material.Client.Name == Session.LoggedClient.Name).ToList();
        }

        public Material Add(Material newMaterial)
        {
            AssignMaterialToClient(newMaterial);
            ValidateMaterialNameUniqueness(newMaterial);
            _repository.Add(newMaterial);
            return newMaterial;
        }

        private void AssignMaterialToClient(Material material)
        {
            EnsureClientIsLoggedIn();
            material.Client = Session.LoggedClient;
        }

        private void EnsureClientIsLoggedIn()
        {
            if (Session.LoggedClient == null) ThrowClientNotLoggedIn();
        }

        public Material Remove(Material material)
        {
            ValidateMaterialExists(material);
            ValidateMaterialReferencedByModel(material);
            _repository.Remove(material);
            return material;
        }

        private void ValidateMaterialReferencedByModel(Material material)
        {
            var modelLogic = new ModelLogic();
            var isMaterialInUse = modelLogic.GetClientModels().Any(model => model.Material.MaterialName == material.MaterialName);
            if (isMaterialInUse) ThrowMaterialReferencedByModel();
        }

        public Material Rename(Material material, string newName)
        {
            ValidateRenaming(material, newName);
            return _repository.Update(material, newName);
        }


        public Material Get(string name)
        {
            var existanceValidationMaterial = new Material { MaterialName = name };
            AssignMaterialToClient(existanceValidationMaterial);
            ValidateMaterialExists(existanceValidationMaterial);
            return GetMaterialForOwner(existanceValidationMaterial);
        }

        private void ValidateRenaming(Material material, string newName)
        {
            ValidateMaterialExists(material);
            var nameUniquenessValidationMaterial = new Material { MaterialName = newName };
            AssignMaterialToClient(nameUniquenessValidationMaterial);
            ValidateMaterialNameUniqueness(nameUniquenessValidationMaterial);
        }

        private void ValidateMaterialNameUniqueness(Material material)
        {
            if (IsMaterialNameInUse(material)) ThrowNameInUse(material.MaterialName);
        }

        private void ValidateMaterialExists(Material material)
        {
            if (!IsMaterialNameInUse(material)) ThrowNotFound(material.MaterialName);
        }

        private void ThrowNameInUse(string name)
        {
            throw new NameException($"Material name {name} is already in use");
        }

        private void ThrowNotFound(string name)
        {
            throw new NotFoundException($"No material with the name {name} was found");
        }
        public void ThrowClientNotLoggedIn()
        {
            throw new SessionException("Client needs to be logged in to create new Material");
        }

        public void ThrowMaterialReferencedByModel()
        {
            throw new AssociationException("Material is already being used by a Model.");
        }

        private bool IsMaterialNameInUse(Material material)
        {
            var existingMaterials = _repository.FindMany(material.MaterialName);
            return existingMaterials.Exists(existingMaterial => existingMaterial.Client.Name == material.Client.Name);
        }

        private Material GetMaterialForOwner(Material checkMaterial)
        {
            return GetClientMaterials()
                .FirstOrDefault(material => material.MaterialName.ToLower() == checkMaterial.MaterialName.ToLower());
        }
    }
}