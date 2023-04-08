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
            return _repository.GetShapes();
        }
        public Shape GetShape(string name)
        {
            return _repository.GetShape(name);
        }

        public Shape RemoveShape(Shape shape)
        {
            _repository.RemoveShape(shape);
            return shape;
        }

        public Shape AddShape(Shape shape)
        {
            EnsureShapeNameUniqueness(shape.Name);
            _repository.AddShape(shape);
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
            bool nameAlreadyExists = _repository.GetShapes().
                Any(currentShape => NormalizedName(currentShape.Name) == NormalizedName(name));
            if (nameAlreadyExists) Shape.ThrowNameExists();
        }

        private string NormalizedName(string name)
        {
            return name.ToLower();
        }
    }
}
