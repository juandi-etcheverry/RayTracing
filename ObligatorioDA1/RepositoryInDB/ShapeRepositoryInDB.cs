using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using IRepository;

namespace RepositoryInDB
{
    public class ShapeRepositoryInDB : IRepositoryShape
    {
        public Shape Add(Shape shape)
        {
            using (var context = new BusinessContext())
            {
                context.Shapes.Add(shape);
                context.SaveChanges();
            }
            return shape;
        }

        public IList<Shape> GetAll()
        {
            using (var context = new BusinessContext())
            {
                return context.Shapes.ToList();
            }
        }

        public Shape Remove(Shape shape)
        {
            using (var context = new BusinessContext())
            {
                context.Shapes.Remove(shape);
                context.SaveChanges();
            }
            return shape;
        }
    }
}
