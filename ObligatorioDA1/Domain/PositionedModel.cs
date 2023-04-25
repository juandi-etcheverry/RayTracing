using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class PositionedModel: Model
    {
        private ValueTuple<decimal, decimal, decimal> _coordinates;

        public ValueTuple<decimal, decimal, decimal> Coordinates
        {
            get => _coordinates;
            set => _coordinates = value;
        }
    }
}
