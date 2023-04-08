using Domain;
using System.Collections.Generic;

namespace DataHandlers
{
    public static class DataHandler
    {
        public static List<Shape> Shapes { get; } = new List<Shape>();
        public static List<Client> Clients { get; } = new List<Client>();

        private static void IsNameUnique(Client client)
        {
            bool doesNameExist = Clients.Exists(client.AreNamesEqual);
            if (doesNameExist) client.ThrowNameExists();
        }

        private static void IsNameUnique(Shape shape)
        {
            bool doesNameExist = Shapes.Exists(shape.AreNamesEqual);
            if (doesNameExist) shape.ThrowNameExists();
        }

        public static void AddShape(Shape oneShape)
        {
            oneShape.SpecificShapeValidator();
            IsNameUnique(oneShape); 
            Shapes.Add(oneShape);
        }

        public static void AddClient(Client oneClient)
        {
            IsNameUnique(oneClient);
            Clients.Add(oneClient);
        }

        public static void RemoveAllShapes() { Shapes.Clear(); }
        public static void RemoveAllClients() { Clients.Clear();}

        public static void DeleteShape(Shape shape1)
        {
            bool removed = Shapes.Remove(shape1);
            if (!removed) shape1.ThrowNotInList();
        }
        public static void RenameShape(Shape shape, string newName)
        {
            Shape aux = new Shape
            {
                Name = newName
            };
            IsNameUnique(aux);
            shape.Name = newName;
        }
    }
 }