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
        public uint Width
        {
            get => _width;
            set
            {
                Height = Convert.ToInt32(Math.Round(Convert.ToDouble(value * 2 / 3)));
                _width = value;
            }
        }
        public int Height { get; private set; }

        public Color[,] PixelData;

        public PPMImage(uint width)
        {
            Width = width;
            PixelData = new Color[Height, Width];
        }

        internal void SavePixel(int row, int column, Color rgbColor)
        {
            int xCoordinate = column;
            int yCoordinate = Height - row - 1;
            if (yCoordinate >= Height)
            {
                throw new OverflowException("Pixel Overflow Error");
            }
            PixelData[yCoordinate, xCoordinate] = rgbColor;
        }
    }
}
