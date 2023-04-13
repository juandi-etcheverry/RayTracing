﻿using System;
using BusinessLogicExceptions;
using ValidationService;

namespace Domain
{
    public class Client
    {
        private string _name;
        private string _password;
        private DateTime _registrationDate { get; set; }

        private static uint MIN_NAME_LENGTH = 3;
        private static uint MAX_NAME_LENGTH = 20;
        private static uint MIN_PASSWORD_LENGTH = 5;
        private static uint MAX_PASSWORD_LENGTH = 25;
        public string Name
        {
            get => _name;
            set
            {
                if (!value.IsBetween(MIN_NAME_LENGTH, MAX_NAME_LENGTH)) ThrowNameNotInRange();
                if (value.HasSpaces()) ThrowHasSpaces();
                if (!value.IsAlphaNumeric()) ThrowNotAlphanumeric();
                _name = value;
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (!value.IsBetween(MIN_PASSWORD_LENGTH, MAX_PASSWORD_LENGTH)) ThrowPasswordNotInRange();
                if (!value.HasUpper()) ThrowPasswordNoCapitalLetter();
                if (!value.HasNumber()) ThrowNoNumberPassword();
                _password = value;
            }
        }

        public Client()
        {
            _registrationDate = DateTime.Now;
        }

        public bool AreNamesEqual(string otherName)
        {
            return _name.Equals(otherName);
        }

        public bool AreNamesEqual(Client otherClient)
        {
            return AreNamesEqual(otherClient.Name);
        }

        public static void ThrowNameExists()
        {
            throw new NameException("Client name already exists");
        }
        public static void ThrowNotAlphanumeric()
        {
            throw new NameException("Client name can't have non-alphanumeric characters");
        }
        public static void ThrowHasSpaces()
        {
            throw new NameException("Client name can't have spaces");
        }

        public static void ThrowNameNotInRange()
        {
            throw new NameException("Client name must be between 3 and 20 characters");
        }

        public static void ThrowPasswordNotInRange()
        {
            throw new PasswordException("Client password must be between 5 and 25 characters");
        }

        public static void ThrowPasswordNoCapitalLetter()
        {
            throw new PasswordException("Client password must have at least one capital letter");
        }

        public static void ThrowNoNumberPassword()
        {
            throw new PasswordException("Client password must have at least one number");
        }

        public static void ThrowNoClientFound()
        {
            throw new NotFoundException("No client found");
        }

        public static void ThrowClientAlreadyLoggedIn()
        {
            throw new SessionAlreadyInitializedException("Client already logged in");
        }

        public static void ThrowClientNotLoggedIn()
        {
            throw new SessionNotInitializedException("Client not logged in");
        }
    }
}
