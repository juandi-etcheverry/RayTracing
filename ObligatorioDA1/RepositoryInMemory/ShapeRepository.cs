using Domain;
using IRepository;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryInMemory
{
    public class ShapeRepository : IRepositoryShape
    {
        private static readonly IList<Shape> Shapes = new List<Shape>();
        public IList<Shape> GetAll()
        {
            return Shapes;
        }

        public Shape Get(string name)
        {
            return Shapes.FirstOrDefault(s => s.AreNamesEqual(name));
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
    }
}
