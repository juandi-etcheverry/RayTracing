using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEngine
{
    internal class BlurCamera : Camera
    {
        private decimal focalDistance;
        private decimal lensRadius;
        public BlurCamera(BlurCameraDetails blurCameraDetails) : base(blurCameraDetails)
        {
            focalDistance = DistanceBetweenLookFromAndLookAt(blurCameraDetails);
            lensRadius = blurCameraDetails.Aperture / 2m;
            SetHorizontalUnitOfDistance();
            SetVerticalUnitOfDistance();
            SetLowerLeftCornerOfCameraView();
        }

        private decimal DistanceBetweenLookFromAndLookAt(BlurCameraDetails blurCameraDetails)
        {
            return blurCameraDetails.LookFrom.Subtract(blurCameraDetails.LookAt).Length();
        }

        private void SetVerticalUnitOfDistance()
        {
            VerticalUnitOfDistance = verticalUnit.Multiply(2 * halfOfHeight * focalDistance);
        }

        private void SetHorizontalUnitOfDistance()
        {
            HorizontalUnitOfDistance = horizontalUnit.Multiply(2 * halfOfWidth * focalDistance);
        }

        private void SetLowerLeftCornerOfCameraView()
        {
            LowerLeftCornerOfCameraView = Origin.Subtract(horizontalUnit.Multiply(halfOfWidth * focalDistance))
                .Subtract(verticalUnit.Multiply(halfOfHeight * focalDistance)).Subtract(depthUnit.Multiply(focalDistance));
        }

        internal override Ray RayFromCoordinates(decimal horizontalDistanceFromLeft, decimal verticalDistanceFromBottom)
        {
            var randomVector = Vector.GetRandomInUnitSphere();
            var vectorOffset = horizontalUnit.Multiply(randomVector.X).Add(verticalUnit.Multiply(randomVector.Y));
            var horizontalPosition = HorizontalUnitOfDistance.Multiply(horizontalDistanceFromLeft);
            var verticalPosition = VerticalUnitOfDistance.Multiply(verticalDistanceFromBottom);
            var rayDirectionIgnoringOrigin = LowerLeftCornerOfCameraView.Add(horizontalPosition
                .Add(verticalPosition)).Subtract(Origin).Subtract(vectorOffset);
            var emittedRay = new Ray
            {
                Origin = Origin.Add(vectorOffset),
                Direction = rayDirectionIgnoringOrigin
            };
            return emittedRay;
        }
    }
}
