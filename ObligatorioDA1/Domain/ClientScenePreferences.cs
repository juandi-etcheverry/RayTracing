using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ClientScenePreferences
    {
        private ValueTuple<decimal, decimal, decimal> _lookFromDefault;
        private ValueTuple<decimal, decimal, decimal> _lookAtDefault;
        private uint _fovDefault;

        public ValueTuple<decimal, decimal, decimal> LookFromDefault
        {
            get => _lookFromDefault;
            set => _lookFromDefault = value;
        }

        public ValueTuple<decimal, decimal, decimal> LookAtDefault
        {
            get => _lookAtDefault;
            set => _lookAtDefault = value;
        }

        public uint FoVDefault
        {
            get => _fovDefault;
            set
            {
                FovAcceptedRange(value);
                _fovDefault = value;
            }
        }

        public void FovAcceptedRange(uint fov)
        {
            if (fov < 1 || fov > 160) ThrowFoVOutOfRange();
        }

        public void ThrowFoVOutOfRange()
        {
            throw new ArgumentOutOfRangeException("FoV must be between 1 and 160");
        }
    }
}
