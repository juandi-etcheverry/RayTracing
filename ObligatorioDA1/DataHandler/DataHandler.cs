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
           Shapes.Add(oneShape);
        }
    }
}