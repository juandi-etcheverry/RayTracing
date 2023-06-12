using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MetallicMaterial : Material
    {
        private decimal _blur;
        private decimal MIN_BLUR_VALUE = 0m;
        public decimal Blur
        {
            get => _blur;
            set
            {
                ValidateBlur(value);
                _blur = value;
            }
        }

        private void ValidateBlur(decimal blur)
        {
            if (blur < MIN_BLUR_VALUE) throw new ArgumentOutOfRangeException("Blur must be greater than or equal to 0");
        }
    }
}
