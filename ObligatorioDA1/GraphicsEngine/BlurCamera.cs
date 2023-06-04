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
            focalDistance = blurCameraDetails.FocalDistance;
            lensRadius = blurCameraDetails.Aperture / 2m;
        }

        protected override void SetVerticalUnitOfDistance()
        {
            VerticalUnitOfDistance = verticalUnit.Multiply(2 * halfOfHeight * focalDistance);
        }

        protected override void SetHorizontalUnitOfDistance()
        {
            HorizontalUnitOfDistance = horizontalUnit.Multiply(2 * halfOfWidth * focalDistance);
        }

        protected override void SetLowerLeftCornerOfCameraView()
        {
            LowerLeftCornerOfCameraView = Origin.Subtract(horizontalUnit.Multiply(halfOfWidth))
                .Subtract(verticalUnit.Multiply(halfOfHeight)).Subtract(depthUnit.Multiply(focalDistance));
        }

        internal override Ray RayFromCoordinates(decimal horizontalDistanceFromLeft, decimal verticalDistanceFromBottom)
        {
            var randomVector = Vector.GetRandomInUnitSphere();
            var vectorOffset = horizontalUnit.Multiply(randomVector.X).Add(verticalUnit.Multiply(randomVector.Y));
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
    }
}
