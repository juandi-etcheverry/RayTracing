namespace GraphicsEngine
{
    public class Ray
    {
        public Vector Origin { get; set; }
        public Vector Direction { get; set; }

        public Vector PointAt(decimal directionScalar)
        {
            return Origin.Add(Direction.Multiply(directionScalar));
        }
    }
}