using System;

namespace Domain
{
    public class PositionedModel
    {
        public decimal CoordinateX { get; set; }
        public decimal CoordinateY { get; set; }
        public decimal CoordinateZ { get; set; }
        public Scene Scene { get; set; }
        public Model Model { get; set; }
        public int Id { get; set; }

        public ValueTuple<decimal, decimal, decimal> GetCoordinates()
        {
            return new ValueTuple<decimal, decimal, decimal>(CoordinateX, CoordinateY, CoordinateZ);
        }
    }
}