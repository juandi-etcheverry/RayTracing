using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicExceptions;
using ValidationService;

namespace Domain
{
    public enum MaterialType
    {
        Lambertian
    }

    public class Material
    {
        public string Name { get; set; }
        public ValueTuple<uint, uint, uint> Color { get; set; }
        public MaterialType Type { get; set; }

    }
}
