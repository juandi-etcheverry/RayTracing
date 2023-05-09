using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsEngine
{
    internal class ImageParser
    {
        internal uint HorizontalResolution;
        internal int VerticalResolution;

        private const string PpmVersion = "P3";

        internal string Parse(Color[,] pixelData)
        {
            string parsedImage = GenerateInitialParsedPPMString();
            foreach (Color pixel in pixelData)
            {
                parsedImage += ParsePixel(pixel);
            }
            return parsedImage;
        }

        private string GenerateInitialParsedPPMString()
        {
            string newLine = "\n";
            string resolutionData = GenerateResolutionData();
            return PpmVersion + newLine + resolutionData + "255" + newLine;
        }

        private string GenerateResolutionData()
        {
            string newLine = "\n";
            return HorizontalResolution.ToString() + " " + VerticalResolution.ToString() + newLine;
        }

        private string ParsePixel(Color pixel)
        {
            string newLine = "\n";
            return pixel.Red() + " " + pixel.Green() + " " + pixel.Blue() + newLine;
        }
    }
}
