using System.Collections.Generic;
using System.Linq;
using BusinessLogicExceptions;
using Domain;
using IRepository;
using RepositoryInDB;

namespace BusinessLogic
{
    public class ShapeLogic
    {
        private readonly IRepositoryShape _repository = new ShapeRepositoryInDB();

        public IList<Shape> GetShapes()
        {
            return _repository.GetAll();
        }

        public IList<Shape> GetClientShapes()
        {
            EnsureClientIsLoggedIn();
            return _repository.GetAll().Where(shape => shape.Client.Name == Session.LoggedClient.Name).ToList();
        }

        public Shape GetShape(string name)
        {
            EnsureClientIsLoggedIn();
            var existenceValidationShape = new Shape { ShapeName = name };
            AssignShapeToClient(existenceValidationShape);
            EnsureShapeExists(name);
            return GetShapeForOwner(existenceValidationShape);
        }

        private void EnsureShapeExists(string name)
        {
            var sceneExists = GetClientShapes().Any(shape => shape.ShapeName.ToLower() == name.ToLower());
            if (!sceneExists) ThrowNotFound();
        }

        public Shape RemoveShape(Shape shape)
        {
            ValidateShapeRefencedByModel(shape);
            var removedShape = _repository.Remove(shape);
            if (removedShape.ShapeName is null) ThrowNotFound();
            return shape;
        }

        private void ValidateShapeRefencedByModel(Shape shape)
        {
            var modelLogic = new ModelLogic();
            var isShapeInUse = modelLogic.GetClientModels().Any(model => model.Shape.ShapeName == shape.ShapeName);
            if (isShapeInUse) ThrowShapeReferencedByModel();
        }

        public Shape AddShape(Shape shape)
        {
            EnsureShapeNameUniqueness(shape.ShapeName);
            AssignShapeToClient(shape);
            _repository.Add(shape);
            return shape;
        }

        private void AssignShapeToClient(Shape shape)
        {
            EnsureClientIsLoggedIn();
            shape.Client = Session.LoggedClient;
        }

        private void EnsureClientIsLoggedIn()
        {
            if (Session.LoggedClient == null) ThrowClientNotLoggedIn();
        }

        public Shape RenameShape(Shape shape, string newName)
        {
            EnsureShapeNameUniqueness(newName);
            shape.ShapeName = newName;
            return _repository.Update(shape);
        }

        private void EnsureShapeNameUniqueness(string name)
        {
            var nameAlreadyExists = GetClientShapes().Any(currentShape => currentShape.AreNamesEqual(name));
            if (nameAlreadyExists) ThrowNameExists();
        }

        private Shape GetShapeForOwner(Shape checkShape)
        {
            return GetClientShapes().FirstOrDefault(shape => shape.AreNamesEqual(checkShape.ShapeName));
        }

        private void ThrowNotFound()
        {
            throw new NotFoundException("The shape is not in list");
        }

        private void ThrowClientNotLoggedIn()
        {
            throw new SessionException("Client not logged in");
        }

        private void ThrowShapeReferencedByModel()
        {
            throw new AssociationException("Shape is already being used by a Model.");
        }

        private void ThrowNameExists()
        {
            throw new NameException("Shape name already exists");
        }
    }
}