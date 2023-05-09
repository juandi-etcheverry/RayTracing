using System;
using Domain;

namespace GraphicsEngine
{
    public class GraphicsEngine
    {
        private decimal _MINIMUM_DIRECTION_SCALING_FACTOR = 0.00001m;

        private Color ShootRay(Ray ray, decimal depth, Scene scene)
        {
            HitRecord intersectionWithShape = null;
            decimal maxDirectionScalingFactor = Decimal.MaxValue;
            foreach (PositionedModel model in scene.Models)
            {
                HitRecord modelIntersection = PossibleRayIntersectionWithModel(model, ray, maxDirectionScalingFactor);
                if (modelIntersection != null)
                {
                    intersectionWithShape = modelIntersection;
                    maxDirectionScalingFactor = modelIntersection.ScalingFactor;
                }
            }

            if (intersectionWithShape != null)
            {
                if (depth == 0)
                {
                    return new Color() { R = 0, G = 0, B = 0 };
                }
                Vector newPoint = intersectionWithShape.IntersectionPoint.Add(intersectionWithShape.Normal)
                    .Add(GetRandomInUnitSphere());
                Vector newVector = newPoint.Subtract(intersectionWithShape.IntersectionPoint);
                Ray newRay = new Ray()
                {
                    Origin = intersectionWithShape.IntersectionPoint,
                    Direction = newVector
                };
                Color nextColor = ShootRay(newRay, depth - 1, scene);
                return new Color()
                {
                    R = nextColor.R * intersectionWithShape.Attenuation.R,
                    G = nextColor.G * intersectionWithShape.Attenuation.G,
                    B = nextColor.B * intersectionWithShape.Attenuation.B,
                };
            }
            Vector rayDirectionUnit = ray.Direction.Unit();
            decimal gradientYPosition = 0.5m * (rayDirectionUnit.Y + 1);
            Vector gradientStart = new Vector() { X = 1, Y = 1, Z = 1 };
            Vector gradientEnd = new Vector() { X = 0.5m, Y = 0.7m, Z = 1 };
            Vector colorVector = gradientStart.Multiply(1 - gradientYPosition)
                .Add(gradientEnd.Multiply(gradientYPosition));
            Color gradient = new Color() { R = colorVector.X, G = colorVector.Y, B = colorVector.Z };
            return gradient;
        }
        private HitRecord PossibleRayIntersectionWithModel(PositionedModel model, Ray ray, decimal maxDirectionScalingFactor)
        {
            Sphere modelSphere = (Sphere)model.Shape;
            Vector modelCoordinates = new Vector()
            {
                X = model.Coordinates.Item1,
                Y = model.Coordinates.Item2,
                Z = model.Coordinates.Item3
            };
            Color attenuation = new Color()
            {
                R = model.Material.Color.Item1 / 255,
                G = model.Material.Color.Item2 / 255,
                B = model.Material.Color.Item3 / 255
            };
            Vector centerToRayOrigin = ray.Origin.Subtract(modelCoordinates);
            decimal a = ray.Direction.Dot(ray.Direction);
            decimal b = centerToRayOrigin.Dot(ray.Direction) * 2;
            decimal c = centerToRayOrigin.Dot(centerToRayOrigin) - (Convert.ToDecimal(modelSphere.Radius * modelSphere.Radius));
            decimal discriminant = (b * b) - (4 * a * c);
            if (discriminant < 0)
            {
                return null;
            }
            decimal diretionScalingFactorForIntersection =
                ((-1 * b) - Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(discriminant))) / 2 * a);
            Vector intersecitionPoint = ray.PointAt(diretionScalingFactorForIntersection);
            Vector normal = intersecitionPoint.Subtract(modelCoordinates).Divide(Convert.ToDecimal((double)modelSphere.Radius));
            if (diretionScalingFactorForIntersection < maxDirectionScalingFactor &&
                diretionScalingFactorForIntersection > _MINIMUM_DIRECTION_SCALING_FACTOR)
            {
                return new HitRecord()
                {
                    ScalingFactor = diretionScalingFactorForIntersection,
                    IntersectionPoint = intersecitionPoint,
                    Normal = normal,
                    Attenuation = attenuation
                };
            }
            return null;
        }

        private Vector GetRandomInUnitSphere()
        {
            Random random = new Random();
            Vector finalVector;
            do
            {
                Vector randomVector = new Vector()
                {
                    X = Convert.ToDecimal(random.NextDouble()),
                    Y = Convert.ToDecimal(random.NextDouble()),
                    Z = Convert.ToDecimal(random.NextDouble())
                };
                finalVector = randomVector.Multiply(2).Subtract(new Vector() { X = 1, Y = 1, Z = 1 });
            } while ((finalVector.Length() * finalVector.Length()) >= 1);
            return finalVector;
        }
    }
}
