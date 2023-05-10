using System;
using System.IO;

namespace GraphicsEngine
{
    public class PPMImage
    {
        private readonly decimal _ASPECT_RATIO = 2m / 3m;
        public ImageParser parser;

        public Color[,] PixelData;

        public PPMImage(uint width)
        {
            Width = width;
            PixelData = new Color[Height, Width];
            parser = new ImageParser(PixelData)
            {
                HorizontalResolution = width,
                VerticalResolution = Height
            };
        }

        private uint _width { get; set; }

        public uint Width
        {
            get => _width;
            set
            {
                Height = CalculateHeightBasedOnWidthAndAspectRatio(value);
                _width = value;
            }
        }

        public int Height { get; private set; }

        public void SaveFile(string fileName)
        {
            var parsedData = parser.Parse();
            File.WriteAllText(fileName, parsedData);
            Console.WriteLine("SAVED");
        }

        internal void SavePixel(int row, int column, Color rgbColor)
        {
            var xCoordinate = column;
            var yCoordinate = Height - row - 1;
            EnsureYCoordinateDoesNotOverflow(yCoordinate);
            PixelData[yCoordinate, xCoordinate] = rgbColor;
        }

        private int CalculateHeightBasedOnWidthAndAspectRatio(uint width)
        {
            return Convert.ToInt32(Math.Round(width * _ASPECT_RATIO, MidpointRounding.AwayFromZero));
        }

        private void EnsureYCoordinateDoesNotOverflow(int yCoordinate)
        {
            if (yCoordinate >= Height) ThrowPixelOverflow();
        }

        private void ThrowPixelOverflow()
        {
            throw new OverflowException("Pixel Overflow Error");
        }
    }
}