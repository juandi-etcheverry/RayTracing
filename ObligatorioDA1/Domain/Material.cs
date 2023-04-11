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
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (value.IsEmpty()) ThrowEmptyName();
                if (value.HasTrailingSpaces()) ThrowHasTrailingSpaces();
                _name = value;
            }
        }

        public ValueTuple<uint, uint, uint> Color { get; set; }
        public MaterialType Type { get; set; }

        public static void ThrowEmptyName()
        {
            throw new NameException("Material name can't be empty");
        }

        public static void ThrowHasTrailingSpaces()
        {
            throw new NameException("Material name can't have trailing spaces");
        }
    }
}
