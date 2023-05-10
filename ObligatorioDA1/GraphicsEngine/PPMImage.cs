using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEngine
{
    internal class PPMImage
    {
        private uint _width { get; set; }
        private decimal _ASPECT_RATIO = 2m / 3m;
        private ImageParser parser;
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

        public Color[,] PixelData;

        public PPMImage(uint width)
        {
            Width = width;
            PixelData = new Color[Height, Width];
            parser = new ImageParser()
            {
                HorizontalResolution = width,
                VerticalResolution = Height,
            };
        }

        public void SaveFile(string fileName)
        {
            string parsedData = parser.Parse(PixelData);
            System.IO.File.WriteAllText(fileName, parsedData);
            Console.WriteLine("SAVED");
        }

        internal void SavePixel(int row, int column, Color rgbColor)
        {
            int xCoordinate = column;
            int yCoordinate = Height - row - 1;
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
