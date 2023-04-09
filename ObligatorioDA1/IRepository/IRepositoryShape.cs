using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace IRepository
{
    public interface IRepositoryShape
    {
        IList<Shape> GetShapes();
        Shape GetShape(string name);
        Shape AddShape(Shape shape);
        Shape RemoveShape(Shape shape);
    }
}
