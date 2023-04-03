using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace DataHandlers
{
    public static class DataHandler
    {
        public static List<Shape> Shapes { get; } = new List<Shape>();


        public static void AddShape(Shape oneShape)
        {
           if (Shapes.Contains(oneShape)) throw new UniqueNameException("Shape name already exists");
           Shapes.Add(oneShape);
        }

        public static void RemoveAllShapes() { Shapes.Clear(); }
    }
}