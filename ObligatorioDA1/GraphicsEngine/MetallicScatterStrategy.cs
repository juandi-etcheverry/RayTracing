using Domain;

namespace GraphicsEngine
{
    internal class MetallicScatterStrategy : IScatterStrategy
    {
        internal HitRecord hitRecord { get; set; }
        internal Ray incomingRay { get; set; }

        public Ray Scatter()
        {
            var scatteredRay = new Ray
            {
                Origin = hitRecord.IntersectionPoint,
                Direction = ReflectedVector()
            };
            if (scatteredRay.Direction.Dot(hitRecord.Normal) > 0) return scatteredRay;

            return null;
        }

        public bool CanExecute()
        {
            return hitRecord.Material.GetType() == typeof(MetallicMaterial);
        }

        private Vector ReflectedVector()
        {
            var unitDirection = incomingRay.Direction.Unit();
            var cosineOfAngleOfReflection =
                unitDirection.Dot(hitRecord.Normal);
            var reflectedVector = unitDirection.Subtract(hitRecord.Normal.Multiply(2m * cosineOfAngleOfReflection));
            return reflectedVector.Add(Vector.GetRandomInUnitSphere()
                .Multiply(((MetallicMaterial)hitRecord.Material).Blur));
        }
    }
}