using System;
using BusinessLogicExceptions;
using ValidationService;

namespace Domain
{
    public class Material
    {
        private string _materialName;

        public string MaterialName
        {
            get => _materialName;
            set
            {
                if (value.IsEmpty()) ThrowEmptyName();
                if (value.HasTrailingSpaces()) ThrowHasTrailingSpaces();
                _materialName = value;
            }
        }

        private int _colorX { get; set; }
        private int _colorY { get; set; }
        private int _colorZ { get; set; }

        public int ColorX
        {
            get => _colorX;
            set
            {
                if (HasInvalidColor(value)) ThrowColorsOutOfRange();
                _colorX = value;
            }
        }
        public int ColorY
        {
            get => _colorY;
            set
            {
                if (HasInvalidColor(value)) ThrowColorsOutOfRange();
                _colorY = value;
            }
        }
        public int ColorZ
        {
            get => _colorZ;
            set
            {
                if (HasInvalidColor(value)) ThrowColorsOutOfRange();
                _colorZ = value;
            }
        }

        public int Id { get; set; }
        public Client Client { get; set; }

        public ValueTuple<int, int, int> GetColor()
        {
            return new ValueTuple<int, int, int>(ColorX, ColorY, ColorZ);
        }

        public void SetColor(int x, int y, int z)
        {
            if (HasInvalidColor(x) || HasInvalidColor(y) || HasInvalidColor(z)) ThrowColorsOutOfRange();
            ColorX = x;
            ColorY = y;
            ColorZ = z;
        }

        private void ThrowEmptyName()
        {
            throw new NameException("Material name can't be empty");
        }

        private void ThrowHasTrailingSpaces()
        {
            throw new NameException("Material name can't have trailing spaces");
        }

        private void ThrowColorsOutOfRange()
        {
            throw new ArgumentOutOfRangeException("RGB must be numbers between 0 and 255");
        }

        private bool HasInvalidColor(int color)
        {
            return color > 255 || color < 0;
        }
    }
}