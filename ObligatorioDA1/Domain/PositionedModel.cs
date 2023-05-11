    using System;

namespace Domain
{
    public class PositionedModel : Model
    {
        public PositionedModel(Model model, ValueTuple<decimal, decimal, decimal> coordinates)
        {
            Name = model.Name;
            OwnerName = model.OwnerName;
            Shape = model.Shape;
            Material = model.Material;
            Preview = model.Preview;
            Coordinates = coordinates;
        }

        public ValueTuple<decimal, decimal, decimal> Coordinates { get; set; }
    }
}