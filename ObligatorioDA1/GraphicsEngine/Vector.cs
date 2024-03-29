﻿using System;

namespace GraphicsEngine
{
    public class Vector
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }


        public Vector Add(Vector vector)
        {
            return new Vector
            {
                X = X + vector.X,
                Y = Y + vector.Y,
                Z = Z + vector.Z
            };
        }

        public Vector Subtract(Vector vector)
        {
            return new Vector
            {
                X = X - vector.X,
                Y = Y - vector.Y,
                Z = Z - vector.Z
            };
        }

        public Vector Multiply(decimal scalar)
        {
            return new Vector
            {
                X = X * scalar,
                Y = Y * scalar,
                Z = Z * scalar
            };
        }

        public Vector Divide(decimal scalar)
        {
            return new Vector
            {
                X = X / scalar,
                Y = Y / scalar,
                Z = Z / scalar
            };
        }

        public decimal Length()
        {
            var squaredLength = SquaredLength();
            return Convert.ToDecimal(Math.Sqrt(squaredLength));
        }

        public double SquaredLength()
        {
            return Convert.ToDouble(X * X + Y * Y + Z * Z);
        }

        public void AddTo(Vector vector)
        {
            ReplaceCoordinatesWithVector(Add(vector));
        }

        public void SubtractFrom(Vector vector)
        {
            ReplaceCoordinatesWithVector(Subtract(vector));
        }

        public void ScaleUpBy(decimal scalar)
        {
            ReplaceCoordinatesWithVector(Multiply(scalar));
        }

        public void ScaleDownBy(decimal scalar)
        {
            ReplaceCoordinatesWithVector(Divide(scalar));
        }

        private void ReplaceCoordinatesWithVector(Vector vector)
        {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
        }

        public Vector Unit()
        {
            return Divide(Length());
        }

        public decimal Dot(Vector vector)
        {
            return X * vector.X + Y * vector.Y + Z * vector.Z;
        }

        public Vector Cross(Vector vector)
        {
            return new Vector
            {
                X = Y * vector.Z - Z * vector.Y,
                Y = Z * vector.X - X * vector.Z,
                Z = X * vector.Y - Y * vector.X
            };
        }

        public static Vector GetRandomInUnitSphere()
        {
            Vector finalVector;
            var onesVector = new Vector { X = 1, Y = 1, Z = 1 };
            do
            {
                var randomVector = GenerateRandomVector();
                finalVector = randomVector.Multiply(2).Subtract(onesVector);
            } while (finalVector.SquaredLength() >= 1);

            return finalVector;
        }

        private static Vector GenerateRandomVector()
        {
            var randomVector = new Vector
            {
                X = Convert.ToDecimal(RandomGenerator.NextDouble()),
                Y = Convert.ToDecimal(RandomGenerator.NextDouble()),
                Z = Convert.ToDecimal(RandomGenerator.NextDouble())
            };
            return randomVector;
        }
    }
}