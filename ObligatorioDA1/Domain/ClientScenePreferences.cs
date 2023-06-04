using System;

namespace Domain
{
    public class ClientScenePreferences
    {
        private int _fovDefault;

        public decimal LookFromDefaultX { get; set; }
        public decimal LookFromDefaultY { get; set; }
        public decimal LookFromDefaultZ { get; set; }

        public decimal LookAtDefaultX { get; set; }
        public decimal LookAtDefaultY { get; set; }
        public decimal LookAtDefaultZ { get; set; }

        public int Id { get; set; }

        public int FoVDefault
        {
            get => _fovDefault;
            set
            {
                if (value < 1 || value > 160) ThrowFoVOutOfRange();
                _fovDefault = value;
            }
        }

        public ValueTuple<decimal, decimal, decimal> GetLookFromDefault()
        {
            return new ValueTuple<decimal, decimal, decimal>(LookFromDefaultX, LookFromDefaultY, LookFromDefaultZ);
        }

        public ValueTuple<decimal, decimal, decimal> GetLookAtDefault()
        {
            return new ValueTuple<decimal, decimal, decimal>(LookAtDefaultX, LookAtDefaultY, LookAtDefaultZ);
        }

        public void SetLookFromDefault(ValueTuple<decimal, decimal, decimal> lookFromDefault)
        {
            LookFromDefaultX = lookFromDefault.Item1;
            LookFromDefaultY = lookFromDefault.Item2;
            LookFromDefaultZ = lookFromDefault.Item3;
        }

        public void SetLookAtDefault(ValueTuple<decimal, decimal, decimal> lookAtDefault)
        {
            LookAtDefaultX = lookAtDefault.Item1;
            LookAtDefaultY = lookAtDefault.Item2;
            LookAtDefaultZ = lookAtDefault.Item3;
        }

        private void ThrowFoVOutOfRange()
        {
            throw new ArgumentOutOfRangeException("FoV must be between 1 and 160");
        }
    }
}