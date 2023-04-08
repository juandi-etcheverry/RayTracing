using BusinessLogicExceptions;

namespace Domain
{
    public class Sphere : Shape
    {
        public double Radius { get; set; }

        public static void ThrowNegativeRadius()
        {
            throw new NegativeRadiusException("Sphere's Radius can't be negative");
        }
        public override void SpecificShapeValidator()
        {
            if (Radius <= 0) ThrowNegativeRadius();
        }
    }
}