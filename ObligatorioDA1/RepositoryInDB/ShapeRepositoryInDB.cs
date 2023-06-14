using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
                var loggedClient = context.Clients.FirstOrDefault(c => c.Name == shape.Client.Name);
                shape.Client = loggedClient;

                context.Shapes.Add(shape);
                context.SaveChanges();
            }

            return shape;
        }

        public IList<Shape> GetAll()
        {
            using (var context = new BusinessContext())
            {
                return context.Shapes.Include(s => s.Client).ToList();
            }
        }

        public Shape Remove(Shape shape)
        {
            using (var context = new BusinessContext())
            {
                var shapeToRemove = context.Shapes.FirstOrDefault(s => s.Id == shape.Id);
                context.Shapes.Remove(shapeToRemove);
                context.SaveChanges();
                return shapeToRemove;
            }
        }

        public Shape Update(Shape shape)
        {
            using (var context = new BusinessContext())
            {
                var shapeToUpdate = context.Shapes.FirstOrDefault(s => s.Id == shape.Id);
                shapeToUpdate.ShapeName = shape.ShapeName;
                context.SaveChanges();
                return shapeToUpdate;
            }
        }
    }
}