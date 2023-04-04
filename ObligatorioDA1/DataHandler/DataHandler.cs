﻿using BusinessLogic;
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
        private static void IsNameEmpty<T>(T objectX) where T : Shape 
        {
            if (StringValidatorExtension.IsEmpty(objectX.Name)) objectX.ThrowEmptyName();
        }

        public static void AddShape(Shape oneShape)
        {
            IsNameEmpty(oneShape);
           IsNameUnique(oneShape, Shapes); 
           Shapes.Add(oneShape);
        }

        public static void RemoveAllShapes() { Shapes.Clear(); }
    }
}