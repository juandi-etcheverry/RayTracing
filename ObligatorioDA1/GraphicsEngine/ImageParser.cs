using System;
using System.Drawing;
using System.IO;

namespace GraphicsEngine
{
    public class ImageParser
    {
        private const string PpmVersion = "P3";
        internal uint HorizontalResolution;
        private readonly Color[,] pixelData;
        internal int VerticalResolution;

        public ImageParser(Color[,] data)
        {
            pixelData = data;
        }

        internal string Parse()
        {
            var parsedImage = GenerateInitialParsedPPMString();
            foreach (var pixel in pixelData) parsedImage += ParsePixel(pixel);
            return parsedImage;
        }

        private string GenerateInitialParsedPPMString()
        {
            var newLine = "\n";
            var resolutionData = GenerateResolutionData();
            return PpmVersion + newLine + resolutionData + "255" + newLine;
        }

        private string GenerateResolutionData()
        {
            var newLine = "\n";
            return HorizontalResolution + " " + VerticalResolution + newLine;
        }

        private string ParsePixel(Color pixel)
        {
            var newLine = "\n";
            return pixel.Red() + " " + pixel.Green() + " " + pixel.Blue() + newLine;
        }

        public static Bitmap ConvertPpmToBitmap(string filePath)
        {
            Console.WriteLine("Attempting read...");
            using (var streamReader = new StreamReader(filePath))
            {
                streamReader.ReadLine();

                string[] size = streamReader.ReadLine()?.Split(' ');
                int width = int.Parse(size[0]);
                int height = int.Parse(size[1]);

                streamReader.ReadLine();

                Bitmap bitmap = new Bitmap(width, height);
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        string[] RGBLine = streamReader.ReadLine().Split(' ');
                        int r = int.Parse(RGBLine[0]);
                        int g = int.Parse(RGBLine[1]);
                        int b = int.Parse(RGBLine[2]);
                        var color = System.Drawing.Color.FromArgb(r, g, b);
                        bitmap.SetPixel(x, y, color);
                    }
                }
                Console.WriteLine("File Parsed");
                return bitmap;
            }
        }
    }
}
