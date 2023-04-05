﻿using System.Net.Http;

namespace BusinessLogic
{
    public class Shape
    {
        private string _name { get; set; }
        public string Name { get; set; }
        public string Owner { get; private set; }

        public bool AreNamesEqual(Shape other)
        {
            return this.Name == other.Name;
        }
        public void ThrowNameExists()
        {
            throw new UniqueNameException("Shape name already exists");
        }
        public void ThrowEmptyName()
        {
            throw new EmptyNameException("Shape Name can't be empty");
        }
        public void ThrowHasTrailingSpaces()
        {
            throw new TrailingSpacesNameException("Shape Name can't have trailing spaces");
        }
        public void ThrowNotInList()
        {
            throw new ShapeNotInListException("The shape is not in list");
        }

    }
}