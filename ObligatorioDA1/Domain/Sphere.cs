using BusinessLogicExceptions;

namespace Domain
{
    public class Sphere : Shape
    {
        private double _radius;

        public double Radius
        {
            get => _radius;
            set
            {
                if (value <= 0) ThrowNonPositiveRadius();
                _radius = value;
            }
        }


        private void ThrowNonPositiveRadius()
        {
            throw new NonPositiveRadiusException("Sphere's Radius must be greater than 0");
        }
    }
}