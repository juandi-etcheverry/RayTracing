using System.Collections.Generic;
using System.Linq;
using Domain;
using IRepository;

namespace RepositoryInMemory
{
    public class ShapeRepository : IRepositoryShape
    {
        private static readonly IList<Shape> Shapes = new List<Shape>();

        public IList<Shape> GetAll()
        {
            return Shapes;
        }

        public Shape Add(Shape shape)
        {
            Shapes.Add(shape);
            return shape;
        }

        public Shape Remove(Shape shape)
        {
            Shapes.Remove(shape);
            return shape;
        }

        public Shape Update(Shape x, string newName)
        {
            throw new System.NotImplementedException();
        }
    }
}