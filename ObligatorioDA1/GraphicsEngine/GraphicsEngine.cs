using System;
using BusinessLogic;
using Domain;

namespace GraphicsEngine
{
    public class GraphicsEngine
    {
        private readonly decimal _MINIMUM_DIRECTION_SCALING_FACTOR = 0.00001m;
        public uint Width { get; set; }
        private Camera _camera;
        private Scene _scene;
        private readonly RenderLogLogic _renderLogLogic = new RenderLogLogic();

        public GraphicsEngine(Scene scene)
        {
            _scene = scene;
            DefaultCamera();
        }
        public PPMImage Render()
        {
            //create Log
            Log newLog = new Log();
            newLog.RenderingTimeInSeconds = 2; //cambiar
            newLog.RenderWindow = DateTime.Today; //cambiar
            newLog.SceneName = _scene.SceneName; //cambiar
            newLog.NumberOfModels = _scene.Models.Count;
            _renderLogLogic.Add(newLog);


            var renderedImage = new PPMImage(Width);

            for (var row = renderedImage.Height - 1; row >= 0; row--)
                for (var column = 0; column < renderedImage.Width; column++)
                {
                    var color = CalculatePixelColor(column, row, renderedImage);
                    renderedImage.SavePixel(row, column, color);
                }

            return renderedImage;
        }

        public void BlurCamera(decimal aperture)
        {
            var cameraDetails = DefaultCameraDetails(_scene);
            var blurCameraDetails = new BlurCameraDetails(cameraDetails)
            {
                Aperture = aperture
            };
            var camera = new BlurCamera(blurCameraDetails);
            _camera = camera;
        }

        public void DefaultCamera()
        {
            var cameraDetails = DefaultCameraDetails(_scene);
            var camera = new Camera(cameraDetails);
            _camera = camera;
        }

        private Color CalculatePixelColor(int column, int row,
            PPMImage renderedImage)
        {

            var SAMPLES_PER_PIXEL = 50;
            var MAX_DEPTH = 20;

            var colorVector = new Vector
            {
                X = 0,
                Y = 0,
                Z = 0
            };

            for (var sample = 0; sample < SAMPLES_PER_PIXEL; sample++)
            {
                var xCoordinate = (column + Convert.ToDecimal(RandomGenerator.NextDouble())) /
                                  renderedImage.Width;
                var yCoordinate = (row + Convert.ToDecimal(RandomGenerator.NextDouble())) / renderedImage.Height;
                var coloringRay = _camera.RayFromCoordinates(xCoordinate, yCoordinate);
                colorVector.AddTo(ShootRay(coloringRay, MAX_DEPTH));
            }

            colorVector = colorVector.Divide(SAMPLES_PER_PIXEL);
            var color = new Color { R = colorVector.X, G = colorVector.Y, B = colorVector.Z };
            return color;
        }

        private CameraDetails DefaultCameraDetails(Scene scene)
        {
            var LookAt = new Vector
            {
                X = scene.ClientScenePreferences.LookAtDefaultX,
                Y = scene.ClientScenePreferences.LookAtDefaultY,
                Z = scene.ClientScenePreferences.LookAtDefaultZ
            };

            var LookFrom = new Vector
            {
                X = scene.ClientScenePreferences.LookAtDefaultX,
                Y = scene.ClientScenePreferences.LookFromDefaultY,
                Z = scene.ClientScenePreferences.LookFromDefaultZ
            };

            var Up = new Vector
            {
                X = 0,
                Y = 1,
                Z = 0
            };

            var cameraDetails = new CameraDetails
            {
                LookAt = LookAt,
                LookFrom = LookFrom,
                AspectRatio = 3m / 2m,
                FieldOfView = scene.ClientScenePreferences.FoVDefault,
                Up = Up
            };

            return cameraDetails;
        }

        private Vector ShootRay(Ray ray, decimal depth)
        {
            HitRecord intersectionWithShape = null;
            var maxDirectionScalingFactor = decimal.MaxValue;
            foreach (var model in _scene.Models)
            {
                var modelIntersection = PossibleRayIntersectionWithModel(model, ray, maxDirectionScalingFactor);
                if (modelIntersection != null)
                {
                    intersectionWithShape = modelIntersection;
                    maxDirectionScalingFactor = modelIntersection.ScalingFactor;
                }
            }

            if (intersectionWithShape != null)
            {
                if (depth <= 0) return new Vector { X = 0, Y = 0, Z = 0 };
                var newRay = CalculateBouncedRay(intersectionWithShape);
                var nextColor = ShootRay(newRay, depth - 1);
                return new Vector
                {
                    X = nextColor.X * intersectionWithShape.Attenuation.R,
                    Y = nextColor.Y * intersectionWithShape.Attenuation.G,
                    Z = nextColor.Z * intersectionWithShape.Attenuation.B
                };
            }

            return GenerateGradientBackground(ray);
        }

        private Ray CalculateBouncedRay(HitRecord intersectionWithShape)
        {
            var newPoint = intersectionWithShape.IntersectionPoint.Add(intersectionWithShape.Normal)
                .Add(Vector.GetRandomInUnitSphere());
            var newVector = newPoint.Subtract(intersectionWithShape.IntersectionPoint);
            var newRay = new Ray
            {
                Origin = intersectionWithShape.IntersectionPoint,
                Direction = newVector
            };
            return newRay;
        }

        private static Vector GenerateGradientBackground(Ray ray)
        {
            var rayDirectionUnit = ray.Direction.Unit();
            var gradientYPosition = 0.5m * (rayDirectionUnit.Y + 1);
            var gradientStart = new Vector { X = 1, Y = 1, Z = 1 };
            var gradientEnd = new Vector { X = 0.5m, Y = 0.7m, Z = 1 };
            var colorVector = gradientStart.Multiply(1 - gradientYPosition)
                .Add(gradientEnd.Multiply(gradientYPosition));
            return colorVector;
        }

        private HitRecord PossibleRayIntersectionWithModel(PositionedModel model, Ray ray,
            decimal maxDirectionScalingFactor)
        {
            var modelSphere = (Sphere)model.Model.Shape;
            var modelCoordinates = PointFromModelCoordinates(model);
            var attenuation = ColorFromModelMaterial(model);

            var centerToRayOrigin = ray.Origin.Subtract(modelCoordinates);
            var a = ray.Direction.Dot(ray.Direction);
            var b = centerToRayOrigin.Dot(ray.Direction) * 2m;
            var c = centerToRayOrigin.Dot(centerToRayOrigin) -
                    Convert.ToDecimal(modelSphere.Radius * modelSphere.Radius);
            var discriminant = b * b - 4m * a * c;
            if (discriminant < 0) return null;

            var scalingFactorForIntersection =
                (-1 * b - Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(discriminant)))) / (2m * a);
            var intersecitionPoint = ray.PointAt(scalingFactorForIntersection);
            var normal = intersecitionPoint.Subtract(modelCoordinates).Divide(Convert.ToDecimal(modelSphere.Radius));
            if (scalingFactorForIntersection < maxDirectionScalingFactor &&
                scalingFactorForIntersection > _MINIMUM_DIRECTION_SCALING_FACTOR)
            {
                return new HitRecord
                {
                    ScalingFactor = scalingFactorForIntersection,
                    IntersectionPoint = intersecitionPoint,
                    Normal = normal,
                    Attenuation = attenuation
                };
            }

            return null;
        }

        private Color ColorFromModelMaterial(PositionedModel model)
        {
            var attenuation = new Color
            {
                R = model.Model.Material.ColorX / 255m,
                G = model.Model.Material.ColorY / 255m,
                B = model.Model.Material.ColorZ / 255m
            };
            return attenuation;
        }

        private Vector PointFromModelCoordinates(PositionedModel model)
        {
            var modelCoordinates = new Vector
            {
                X = model.CoordinateX,
                Y = model.CoordinateY,
                Z = model.CoordinateZ
            };
            return modelCoordinates;
        }


    }
}