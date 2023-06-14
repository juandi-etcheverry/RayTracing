﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace GraphicsEngine
{
    internal class ScatterContext
    {
        private IList<IScatterStrategy> _scatterStrategies = new List<IScatterStrategy>();

        internal ScatterContext(HitRecord hitRecord, Ray incomingRay)
        {
            LoadLambertianScatter(hitRecord);
            LoadMetallicStrategy(hitRecord, incomingRay);
        }

        internal Ray Scatter()
        {
            return _scatterStrategies.FirstOrDefault(strat => strat.CanExecute())?.Scatter();
        }

        private void LoadLambertianScatter(HitRecord hitRecord)
        {
            var lambertianScatter = new LambertianScatterStrategy()
            {
                hitRecord = hitRecord
            };
            _scatterStrategies.Add(lambertianScatter);
        }

        private void LoadMetallicStrategy(HitRecord hitRecord, Ray incomingRay)
        {
            var metallicScatter = new MetallicScatterStrategy()
            {
                hitRecord = hitRecord,
                incomingRay = incomingRay
            };
            _scatterStrategies.Add(metallicScatter);
        }
    }
}