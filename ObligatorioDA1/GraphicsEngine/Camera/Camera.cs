using System;

namespace GraphicsEngine
{
    internal class Camera
    {
        private readonly CameraDetails _cameraDetails;
        protected Vector depthUnit;
        protected decimal halfOfHeight;
        protected decimal halfOfWidth;
        protected Vector horizontalUnit;
        protected Vector verticalUnit;

        internal Camera(CameraDetails cameraDetails)
        {
            _cameraDetails = cameraDetails;
            halfOfHeight = CalculateHalfOfHeight();
            halfOfWidth = CalculateHalfOfWidth();

            depthUnit = CalculateDepthUnit();
            horizontalUnit = CalculateHorizontalUnit();
            verticalUnit = CalculateVerticalUnit();

            Origin = _cameraDetails.LookFrom;
            SetHorizontalUnitOfDistance();
            SetVerticalUnitOfDistance();
            SetLowerLeftCornerOfCameraView();
        }

        internal Vector Origin { get; set; }
        internal Vector HorizontalUnitOfDistance { get; set; }
        internal Vector VerticalUnitOfDistance { get; set; }
        internal Vector LowerLeftCornerOfCameraView { get; set; }

        internal virtual Ray RayFromCoordinates(decimal horizontalDistanceFromLeft, decimal verticalDistanceFromBottom)
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

        private void SetVerticalUnitOfDistance()
        {
            VerticalUnitOfDistance = verticalUnit.Multiply(2 * halfOfHeight);
        }

        private void SetHorizontalUnitOfDistance()
        {
            HorizontalUnitOfDistance = horizontalUnit.Multiply(2 * halfOfWidth);
        }

        private void SetLowerLeftCornerOfCameraView()
        {
            LowerLeftCornerOfCameraView = Origin.Subtract(horizontalUnit.Multiply(halfOfWidth))
                .Subtract(verticalUnit.Multiply(halfOfHeight)).Subtract(depthUnit);
        }

        private Vector CalculateVerticalUnit()
        {
            return depthUnit.Cross(horizontalUnit);
        }

        private Vector CalculateHorizontalUnit()
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

        private decimal CalculateHalfOfWidth()
        {
            return halfOfHeight * _cameraDetails.AspectRatio;
        }

        private double CalculateRayAngle()
        {
            return _cameraDetails.FieldOfView * Math.PI / 180;
        }
    }
}