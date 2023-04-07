using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Xml.XPath;

namespace DataHandlers
{
    public static class DataHandler
    {
        
        public static List<Shape> Shapes { get; } = new List<Shape>();
        public static List<Client> Clients { get; } = new List<Client>();

        private static void IsNameUnique<T>(T objectX, List<T> objectList) where T : IDataEntity
        {
            bool doesNameExist = objectList.Exists((currentObject) => objectX.AreNamesEqual(currentObject));
            if (doesNameExist) objectX.ThrowNameExists();

        }
        private static void IsNameEmpty<T>(T objectX) where T : Shape 
        {
            if (objectX.Name.IsEmpty()) objectX.ThrowEmptyName();
        }

        private static void HasTrailingSpaces<T>(T objectX) where T : Shape
        {
            if (objectX.Name.HasTrailingSpaces()) objectX.ThrowHasTrailingSpaces();
        }

        private static void IsClientNameAlphanumeric(Client client)
        {
            if (!client.Name.IsAlphaNumeric()) client.ThrowNotAlphanumeric();
        }

        private static void HasSpaces<T>(T objectX) where T : Client
        {
            if (objectX.Name.HasSpaces()) objectX.ThrowHasNoSpaces();
        }

        private static void NameNotInRange(Client client)
        {
            if (!client.Name.IsBetween(Client.MIN_NAME_LENGTH, Client.MAX_NAME_LENGTH)) client.ThrowNameNotInRange();
        }

        private static void PasswordNotInRange(Client client)
        {
            if (!client.Password.IsBetween(Client.MIN_PASSWORD_LENGTH, Client.MAX_PASSWORD_LENGTH)) client.ThrowPasswordNotInRange();
        }

        private static void PasswordNoCapitalLetter(Client client)
        {
            if (!client.Password.HasUpper()) client.ThrowPasswordNoCapitalLetter();
        }
        
        public static void AddShape(Shape oneShape)
        {
            HasTrailingSpaces(oneShape);
            IsNameEmpty(oneShape);
            IsNameUnique(oneShape, Shapes); 
            Shapes.Add(oneShape);
        }

        public static void AddClient(Client oneClient)
        {
            NameNotInRange(oneClient);
            PasswordNoCapitalLetter(oneClient);
            PasswordNotInRange(oneClient);
            HasSpaces(oneClient);
            IsClientNameAlphanumeric(oneClient);
            IsNameUnique<Client>(oneClient, Clients);
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
            Shape aux = new Shape();
            aux.Name = newName;
            IsNameUnique<Shape>(aux, Shapes);
            shape.Name = newName;
        }
    }
 }