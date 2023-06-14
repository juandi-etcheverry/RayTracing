using System;

namespace GraphicsEngine
{
    internal class BlurCameraDetails : CameraDetails
    {
        private decimal _aperture;

        internal BlurCameraDetails(CameraDetails cameraDetails)
        {
            LookAt = cameraDetails.LookAt;
            LookFrom = cameraDetails.LookFrom;
            Up = cameraDetails.Up;
            FieldOfView = cameraDetails.FieldOfView;
            AspectRatio = cameraDetails.AspectRatio;
        }

        internal decimal Aperture
        {
            get => _aperture;
            set
            {
                ValidateAperture(value);
                _aperture = value;
            }
        }

        private void ValidateAperture(decimal aperture)
        {
            if (aperture < 0 || aperture > 3)
                throw new ArgumentOutOfRangeException("The aperture can only be numbers between 0 and 3");
        }
    }
}