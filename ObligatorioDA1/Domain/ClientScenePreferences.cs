using System;

namespace Domain
{
    public class ClientScenePreferences
    {
        private uint _fovDefault;

        public ValueTuple<decimal, decimal, decimal> LookFromDefault { get; set; }

        public ValueTuple<decimal, decimal, decimal> LookAtDefault { get; set; }

        public uint FoVDefault
        {
            get => _fovDefault;
            set
            {
                FovAcceptedRange(value);
                _fovDefault = value;
            }
        }

        private void FovAcceptedRange(uint fov)
        {
            if (fov < 1 || fov > 160) ThrowFoVOutOfRange();
        }

        private void ThrowFoVOutOfRange()
        {
            throw new ArgumentOutOfRangeException("FoV must be between 1 and 160");
        }
    }
}