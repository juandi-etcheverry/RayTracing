using BusinessLogicExceptions;

namespace BusinessLogic
{
    public class Sphere : Shape
    {
        public double Radius { get; set; }

        public void ThrowNegativeRadius()
        {
            throw new NegativeRadiusException("Sphere's Radius can't be negative");
        }
        public override void SpecificShapeValidator()
        {
            if (Radius <= 0) { ThrowNegativeRadius(); }
        }
    }
}