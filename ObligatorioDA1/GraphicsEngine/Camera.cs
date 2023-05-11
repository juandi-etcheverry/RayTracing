using System;

namespace GraphicsEngine
{
    internal class Camera
    {
        private readonly CameraDetails _cameraDetails;

        internal Camera(CameraDetails cameraDetails)
        {
            _cameraDetails = cameraDetails;
            var halfOfHeight = CalculateHalfOfHeight();
            var halfOfWidth = CalculateHalfOfWidth(halfOfHeight);

            var depthUnit = CalculateDepthUnit();
            var horizontalUnit = CalculateHorizontalUnit(depthUnit);
            var verticalUnit = CalculateVerticalUnit(depthUnit, horizontalUnit);

            Origin = _cameraDetails.LookFrom;
            SetHorizontalUnitOfDistance(horizontalUnit, halfOfWidth);
            SetVerticalUnitOfDistance(verticalUnit, halfOfHeight);
            LowerLeftCornerOfCameraView = Origin.Subtract(horizontalUnit.Multiply(halfOfWidth))
                .Subtract(verticalUnit.Multiply(halfOfHeight)).Subtract(depthUnit);
        }

        internal Vector Origin { get; set; }
        internal Vector HorizontalUnitOfDistance { get; set; }
        internal Vector VerticalUnitOfDistance { get; set; }
        internal Vector LowerLeftCornerOfCameraView { get; set; }

        internal Ray RayFromCoordinates(decimal horizontalDistanceFromLeft, decimal verticalDistanceFromBottom)
        {
            var horizontalPosition = HorizontalUnitOfDistance.Multiply(horizontalDistanceFromLeft);
            var verticalPosition = VerticalUnitOfDistance.Multiply(verticalDistanceFromBottom);
            var rayDirectionIgnoringOrigin = LowerLeftCornerOfCameraView.Add(horizontalPosition
                .Add(verticalPosition)).Subtract(Origin);
            var emittedRay = new Ray
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
            var rayAngleFromImage = CalculateRayAngle();
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