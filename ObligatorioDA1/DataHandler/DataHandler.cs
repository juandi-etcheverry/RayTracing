using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.XPath;

namespace DataHandlers
{
    public static class DataHandler
    {
        
        public static List<Shape> Shapes { get; } = new List<Shape>();

        private static void IsNameUnique<T>(T objectX, List<T> objectList) where T : Shape
        {
            bool doesNameExist = objectList.Exists((currentObject) => objectX.AreNamesEqual(currentObject));
            if (doesNameExist) objectX.ThrowNameExists();

        }

        public static void AddShape(Shape oneShape)
        {
           IsNameUnique(oneShape, Shapes);
           Shapes.Add(oneShape);
        }

        public static void RemoveAllShapes() { Shapes.Clear(); }
    }
}