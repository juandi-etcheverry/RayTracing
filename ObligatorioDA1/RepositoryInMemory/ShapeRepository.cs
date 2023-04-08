using Domain;
using IRepository;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryInMemory
{
    public class ShapeRepository : IRepositoryShape
    {
        private static readonly IList<Shape> Shapes = new List<Shape>();
        public IList<Shape> GetShapes()
        {
            return Shapes;
        }

        public Shape GetShape(string name)
        {
            Shape comparisonShape = new Shape() { Name = name };
            return Shapes.FirstOrDefault(s => s.AreNamesEqual(comparisonShape));
        }

        public Shape AddShape(Shape shape)
        {
            Shapes.Add(shape);
            return shape;
        }

        public Shape RemoveShape(Shape shape)
        {
            Shapes.Remove(shape);
            return shape;
        }
    }
}
