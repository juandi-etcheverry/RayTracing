using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace IRepository
{
    public interface IRepositoryShape: IRepository<Shape>
    {
        IList<Shape> GetAll();
        Shape Get(string name);
        Shape Add(Shape shape);
        Shape Remove(Shape shape);
    }
}
