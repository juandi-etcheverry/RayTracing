using System.Collections.Generic;
using System.Linq;
using Domain;
using IRepository;
using RepositoryInMemory;

namespace BusinessLogic
{
    public class ShapeLogic
    {
        private readonly IRepositoryShape _repository = new ShapeRepository();

        public IList<Shape> GetShapes()
        {
            return _repository.GetAll();
        }

        public IList<Shape> GetClientShapes()
        {
            EnsureClientIsLoggedIn();
            return _repository.GetAll().Where(shape => shape.OwnerName == Session.LoggedClient.Name).ToList();
        }

        public Shape GetShape(string name)
        {
            EnsureClientIsLoggedIn();
            var existanceValidationShape = new Shape { Name = name };
            AssignShapeToClient(existanceValidationShape);
            EnsureShapeExists(name);
            return GetShapeForOwner(existanceValidationShape);
        }

        private void EnsureShapeExists(string name)
        {
            var sceneExists = GetClientShapes().Any(shape => shape.Name.ToLower() == name.ToLower());
            if (!sceneExists) Shape.ThrowNotFound();
        }

        public Shape RemoveShape(Shape shape)
        {
            ValidateShapeRefencedByModel(shape);
            var removedShape = _repository.Remove(shape);
            if (removedShape.Name is null) Shape.ThrowNotFound();
            return shape;
        }

        private void ValidateShapeRefencedByModel(Shape shape)
        {
            var modelLogic = new ModelLogic();
            var isShapeInUse = modelLogic.GetClientModels().Any(model => model.Shape.Name == shape.Name);
            if (isShapeInUse) Shape.ThrowShapeReferencedByModel();
        }

        public Shape AddShape(Shape shape)
        {
            EnsureShapeNameUniqueness(shape.Name);
            AssignShapeToClient(shape);
            _repository.Add(shape);
            return shape;
        }

        private void AssignShapeToClient(Shape shape)
        {
            EnsureClientIsLoggedIn();
            shape.OwnerName = Session.LoggedClient.Name;
        }

        private void EnsureClientIsLoggedIn()
        {
            if (Session.LoggedClient == null) Shape.ThrowClientNotLoggedIn();
        }

        public Shape RenameShape(Shape shape, string newName)
        {
            EnsureShapeNameUniqueness(newName);
            shape.Name = newName;
            return shape;
        }

        private void EnsureShapeNameUniqueness(string name)
        {
            var nameAlreadyExists = GetClientShapes().Any(currentShape => currentShape.AreNamesEqual(name));
            if (nameAlreadyExists) Scene.ThrowNameExists();
        }

        private Shape GetShapeForOwner(Shape checkShape)
        {
            return GetClientShapes().FirstOrDefault(shape => shape.AreNamesEqual(checkShape.Name));
        }
    }
}