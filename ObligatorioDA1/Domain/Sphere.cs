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
                if (value <= 0) ThrowNegativeRadius();
            }
        }


        public static void ThrowNegativeRadius()
        {
            throw new NegativeRadiusException("Sphere's Radius can't be negative");
        }
    }
}