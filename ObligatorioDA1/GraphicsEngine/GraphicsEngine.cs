using System;
using Domain;

namespace GraphicsEngine
{
    public class GraphicsEngine
    {
        public uint Width { get; set; }
        private decimal _MINIMUM_DIRECTION_SCALING_FACTOR = 0.00001m;

        public PPMImage Render(Scene scene)
        {
            int SAMPLES_PER_PIXEL = 50;
            int MAX_DEPTH = 20;


            Vector LookAt = new Vector()
            {
                X = scene.ClientScenePreferences.LookAtDefault.Item1,
                Y = scene.ClientScenePreferences.LookAtDefault.Item2,
                Z = scene.ClientScenePreferences.LookAtDefault.Item3,
            };

            Vector LookFrom = new Vector()
            {
                X = scene.ClientScenePreferences.LookFromDefault.Item1,
                Y = scene.ClientScenePreferences.LookFromDefault.Item2,
                Z = scene.ClientScenePreferences.LookFromDefault.Item3,
            };

            Vector Up = new Vector()
            {
                X = 0,
                Y = 1,
                Z = 0
            };

            CameraDetails cameraDetails = new CameraDetails()
            {
                LookAt = LookAt,
                LookFrom = LookFrom,
                AspectRatio = 3m / 2m,
                FieldOfView = scene.ClientScenePreferences.FoVDefault,
                Up = Up
            };

            PPMImage renderedImage = new PPMImage(Width);

            Camera camera = new Camera(cameraDetails);

            for (int row = renderedImage.Height - 1; row >= 0; row--)
            {
                for (int column = 0; column < renderedImage.Width; column++)
                {
                    Vector colorVector = new Vector()
                    {
                        X = 0,
                        Y = 0,
                        Z = 0
                    };

                    for (int sample = 0; sample < SAMPLES_PER_PIXEL; sample++)
                    {
                        decimal xCoordinate = (column + Convert.ToDecimal(RandomGenerator.NextDouble())) /
                                              renderedImage.Width;
                        decimal yCoordinate = (row + Convert.ToDecimal(RandomGenerator.NextDouble())) / renderedImage.Height;
                        Ray coloringRay = camera.RayFromCoordinates(xCoordinate, yCoordinate);
                        colorVector.AddTo(ShootRay(coloringRay, MAX_DEPTH, scene));
                    }
                    colorVector = colorVector.Divide(SAMPLES_PER_PIXEL);
                    Color color = new Color() { R = colorVector.X, G = colorVector.Y, B = colorVector.Z };
                    renderedImage.SavePixel(row, column, color);
                }
            }
            return renderedImage;
        }

        private Vector ShootRay(Ray ray, decimal depth, Scene scene)
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
                if (depth <= 0)
                {
                    return new Vector() { X = 0, Y = 0, Z = 0 };
                }
                Vector newPoint = intersectionWithShape.IntersectionPoint.Add(intersectionWithShape.Normal)
                    .Add(GetRandomInUnitSphere());
                Vector newVector = newPoint.Subtract(intersectionWithShape.IntersectionPoint);
                Ray newRay = new Ray()
                {
                    Origin = intersectionWithShape.IntersectionPoint,
                    Direction = newVector
                };
                Vector nextColor = ShootRay(newRay, depth - 1, scene);
                return new Vector()
                {
                    X = nextColor.X * intersectionWithShape.Attenuation.R,
                    Y = nextColor.Y * intersectionWithShape.Attenuation.G,
                    Z = nextColor.Z * intersectionWithShape.Attenuation.B,
                };
            }
            Vector rayDirectionUnit = ray.Direction.Unit();
            decimal gradientYPosition = 0.5m * (rayDirectionUnit.Y + 1);
            Vector gradientStart = new Vector() { X = 1, Y = 1, Z = 1 };
            Vector gradientEnd = new Vector() { X = 0.5m, Y = 0.7m, Z = 1 };
            Vector colorVector = gradientStart.Multiply(1 - gradientYPosition)
                .Add(gradientEnd.Multiply(gradientYPosition));
            return colorVector;
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
                R = model.Material.Color.Item1 / 255m,
                G = model.Material.Color.Item2 / 255m,
                B = model.Material.Color.Item3 / 255m
            };
            Vector centerToRayOrigin = ray.Origin.Subtract(modelCoordinates);
            decimal a = ray.Direction.Dot(ray.Direction);
            decimal b = centerToRayOrigin.Dot(ray.Direction) * 2m;
            decimal c = centerToRayOrigin.Dot(centerToRayOrigin) - (Convert.ToDecimal(modelSphere.Radius * modelSphere.Radius));
            decimal discriminant = (b * b) - (4m * a * c);
            if (discriminant < 0)
            {
                return null;
            }

            decimal scalingFactorForIntersection =
                ((-1 * b) - Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(discriminant)))) / (2m * a);
            //(-1m * b) - Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(discriminant))) / (2m * a));
            Vector intersecitionPoint = ray.PointAt(scalingFactorForIntersection);
            Vector normal = intersecitionPoint.Subtract(modelCoordinates).Divide(Convert.ToDecimal(modelSphere.Radius));
            if (scalingFactorForIntersection < maxDirectionScalingFactor &&
                scalingFactorForIntersection > _MINIMUM_DIRECTION_SCALING_FACTOR)
            {
                return new HitRecord()
                {
                    ScalingFactor = scalingFactorForIntersection,
                    IntersectionPoint = intersecitionPoint,
                    Normal = normal,
                    Attenuation = attenuation
                };
            }

            return null;
        }

        private Vector GetRandomInUnitSphere()
        {
            Vector finalVector;
            Vector onesVector = new Vector() { X = 1, Y = 1, Z = 1 };
            do
            {
                Vector randomVector = new Vector()
                {
                    X = Convert.ToDecimal(RandomGenerator.NextDouble()),
                    Y = Convert.ToDecimal(RandomGenerator.NextDouble()),
                    Z = Convert.ToDecimal(RandomGenerator.NextDouble())
                };
                finalVector = randomVector.Multiply(2).Subtract(onesVector);
            } while (finalVector.SquaredLength() >= 1);
            return finalVector;
        }
    }
}
