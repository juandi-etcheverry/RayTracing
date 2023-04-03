using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace DataHandlers
{
    public static class DataHandler
    {
        public static List<Shape> Shapes { get; } = new List<Shape>();

        private static void IsShapeNameUnique(string shapeName) 
        {
            bool doesNameExist = Shapes.Exists((currentShape) => currentShape.Name == shapeName);
            if (doesNameExist) throw new UniqueNameException("Shape name already exists");
             
        }

        public static void AddShape(Shape oneShape)
        {
           IsShapeNameUnique(oneShape.Name);
           Shapes.Add(oneShape);
        }

        public static void RemoveAllShapes() { Shapes.Clear(); }
    }
}