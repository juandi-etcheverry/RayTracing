using System;
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
            return _repository.Get(name);
        }

        public Shape RemoveShape(Shape shape)
        {
            Shape removedShape = _repository.Remove(shape);
            if (removedShape.Name is null) Shape.ThrowNotFound();
            return shape;
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
            bool nameAlreadyExists = _repository.GetAll().
                Any(currentShape => currentShape.AreNamesEqual(name));
            if (nameAlreadyExists) Scene.ThrowNameExists();
        }
    }
}
