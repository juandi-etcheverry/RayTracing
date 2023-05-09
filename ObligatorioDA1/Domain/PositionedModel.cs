using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PositionedModel : Model
    {
        private ValueTuple<decimal, decimal, decimal> _coordinates;

        public ValueTuple<decimal, decimal, decimal> Coordinates
        {
            get => _coordinates;
            set => _coordinates = value;
        }

        public PositionedModel(Model model, ValueTuple<decimal, decimal, decimal> coordinates)
        {
            Name = model.Name;
            OwnerName = model.OwnerName;
            Shape = model.Shape;
            Material = model.Material;
            Coordinates = coordinates;
        }
    }
}
