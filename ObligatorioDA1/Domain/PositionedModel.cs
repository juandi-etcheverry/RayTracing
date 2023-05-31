using System;
using System.Drawing;

namespace Domain
{
    public class PositionedModel : Model
    {
        public decimal CoordinateX { get; set; }
        public decimal CoordinateY { get; set; }
        public decimal CoordinateZ { get; set; }
        public Scene Scene { get; set; } //no se si va

        public PositionedModel(Model model, ValueTuple<decimal, decimal, decimal> coordinates)
        {
            ModelName = model.ModelName;
            Client = model.Client;
            Shape = model.Shape;
            Material = model.Material;
            Preview = model.Preview;
            CoordinateX = coordinates.Item1;
            CoordinateY = coordinates.Item2;
            CoordinateZ = coordinates.Item3;
        }

        public ValueTuple<decimal, decimal, decimal> GetCoordinates()
        {
            return new ValueTuple<decimal, decimal, decimal>(CoordinateX, CoordinateY, CoordinateZ);
        }
    }
}