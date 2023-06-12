using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEngine
{
    internal class LambertianScatterStrategy : ScatterStrategy
    {
        internal override Ray Scatter()
        {
            var newPoint = hitRecord.IntersectionPoint.Add(hitRecord.Normal)
                .Add(Vector.GetRandomInUnitSphere());
            var newVector = newPoint.Subtract(hitRecord.IntersectionPoint);
            var newRay = new Ray
            {
                Origin = hitRecord.IntersectionPoint,
                Direction = newVector
            };
            return newRay;
        }

        internal override bool CanExecute()
        {
            return hitRecord.Material.GetType() == typeof(Material);
        }
    }
}
