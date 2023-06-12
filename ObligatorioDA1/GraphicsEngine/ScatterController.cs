using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace GraphicsEngine
{
    internal class ScatterController
    {
        private IList<ScatterStrategy> _scatterStrategies = new List<ScatterStrategy>();

        internal ScatterController(HitRecord hitRecord, Ray incomingRay)
        {

            var lambertianScatter = new LambertianScatterStrategy()
            {
                hitRecord = hitRecord,
                incomingRay = incomingRay
            };
            _scatterStrategies.Add(lambertianScatter);
        }

        internal Ray Scatter()
        {
            return _scatterStrategies.FirstOrDefault(strat => strat.CanExecute())?.Scatter();
        }
    }
}
