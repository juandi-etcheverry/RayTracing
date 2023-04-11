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
            _repository.Add(shape);
            return shape;
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
            if (nameAlreadyExists) Shape.ThrowNameExists();
        }
    }
}
