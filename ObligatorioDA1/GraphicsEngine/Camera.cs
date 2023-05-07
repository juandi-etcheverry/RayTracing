using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEngine
{
    internal class Camera
    {
        internal Vector Origin { get; set; }
        internal Vector HorizontalUnitOfDistance { get; set; }
        internal Vector VerticalUnitOfDistance { get; set; }
        internal Vector LowerLeftCornerOfCameraView { get; set; }
        private readonly CameraDetails _cameraDetails;
        internal Camera(CameraDetails cameraDetails)
        {
            _cameraDetails = cameraDetails;
            decimal halfOfHeight = CalculateHalfOfHeight();
            decimal halfOfWidth = CalculateHalfOfWidth(halfOfHeight);

            Vector depthUnit = CalculateDepthUnit();
            Vector horizontalUnit = CalculateHorizontalUnit(depthUnit);
            Vector verticalUnit = CalculateVerticalUnit(depthUnit, horizontalUnit);

            Origin = _cameraDetails.LookFrom;
            SetHorizontalUnitOfDistance(horizontalUnit, halfOfWidth);
            SetVerticalUnitOfDistance(verticalUnit, halfOfHeight);
            LowerLeftCornerOfCameraView = Origin.Subtract(horizontalUnit.Multiply(halfOfWidth))
                .Subtract(verticalUnit.Multiply(halfOfHeight)).Subtract(depthUnit);
        }

        public Ray RayFromCoordinates(int horizontalDistanceFromLeft, int verticalDistanceFromBottom)
        {
            Vector horizontalPosition = HorizontalUnitOfDistance.Multiply(horizontalDistanceFromLeft);
            Vector verticalPosition = VerticalUnitOfDistance.Multiply(verticalDistanceFromBottom);
            Vector rayDirectionIgnoringOrigin = LowerLeftCornerOfCameraView.Add(horizontalPosition)
                .Add(verticalPosition).Subtract(Origin);
            Ray emittedRay = new Ray()
            {
                Origin = Origin,
                Direction = rayDirectionIgnoringOrigin
            };
            return emittedRay;
        }

        private void SetVerticalUnitOfDistance(Vector verticalUnit, decimal halfOfHeight)
        {
            VerticalUnitOfDistance = verticalUnit.Multiply(2 * halfOfHeight);
        }

        private void SetHorizontalUnitOfDistance(Vector horizontalUnit, decimal halfOfWidth)
        {
            HorizontalUnitOfDistance = horizontalUnit.Multiply(2 * halfOfWidth);
        }

        private static Vector CalculateVerticalUnit(Vector depthUnit, Vector horizontalUnit)
        {
            return depthUnit.Cross(horizontalUnit);
        }

        private Vector CalculateHorizontalUnit(Vector depthUnit)
        {
            return _cameraDetails.Up.Cross(depthUnit).Unit();
        }

        private Vector CalculateDepthUnit()
        {
            return _cameraDetails.LookFrom.Subtract(_cameraDetails.LookAt).Unit();
        }

        private decimal CalculateHalfOfHeight()
        {
            double rayAngleFromImage = CalculateRayAngle();
            return Convert.ToDecimal(Math.Tan(rayAngleFromImage / 2));
        }
        private decimal CalculateHalfOfWidth(decimal halfOfHeight)
        {
            return halfOfHeight * _cameraDetails.AspectRatio;
        }

        private double CalculateRayAngle()
        {
            return _cameraDetails.FieldOfView * Math.PI / 180;
        }
    }
}
