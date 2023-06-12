using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace GraphicsEngine
{
    internal class MetallicScatterStrategy : ScatterStrategy
    {
        internal override Ray Scatter()
        {
            var scatteredRay = new Ray()
            {
                Origin = hitRecord.IntersectionPoint,
                Direction = ReflectedVector()
            };
            if (scatteredRay.Direction.Dot(hitRecord.Normal) > 0)
            {
                return scatteredRay;
            }

            return null;
        }

        private Vector ReflectedVector()
        {
            var cosineOfAngleOfReflection =
                incomingRay.Direction.Unit().Dot(hitRecord.Normal);
            var reflectedVector = incomingRay.Direction.Subtract(hitRecord.Normal.Multiply(2m * cosineOfAngleOfReflection));
            return reflectedVector.Add(Vector.GetRandomInUnitSphere()).Multiply(((MetallicMaterial)hitRecord.Material).Blur);
        }

        internal override bool CanExecute()
        {
            return hitRecord.Material.GetType() == typeof(MetallicMaterial);
        }
    }
}
