using System;
using System.Drawing;
using System.IO;

namespace GraphicsEngine
{
    public class ImageParser
    {
        private const string PpmVersion = "P3";
        private readonly Color[,] pixelData;
        internal uint HorizontalResolution;
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

        public static int HashDate(DateTime t)
        {
            var year = t.Year;
            var month = t.Month;
            var day = t.Day;
            var hour = t.Hour;
            var min = t.Minute;
            var sec = t.Second;
            var mili = t.Millisecond;
            return year + month + day + hour + min + sec + mili;
        }

        public static Bitmap CreateBitmapFromPPMImage(PPMImage ppmImage)
        {
            var parsedPPM = ppmImage.parser.Parse();
            Console.WriteLine("Attempting to parse PPM to Bitmap");
            return StringPPMToBitmap(parsedPPM);
        }

        public static Bitmap CreateBitmapFromFilePath(string filePath)
        {
            if (filePath.EndsWith("ppm")) return ConvertPpmToBitmap(filePath);
            return new Bitmap(filePath);
        }

        private static Bitmap StringPPMToBitmap(string parsedPPM)
        {
            var imageLines = parsedPPM.Split('\n');
            var WIDHT_HEIGHT_LINE = 1;
            var size = imageLines[WIDHT_HEIGHT_LINE].Split(' ');
            var width = int.Parse(size[0]);
            var height = int.Parse(size[1]);
            var bitmap = new Bitmap(width, height);
            var linePosition = 3;
            for (var y = 0; y < height; y++)
            for (var x = 0; x < width; x++)
            {
                var RGBLine = imageLines[linePosition].Split(' ');
                var r = int.Parse(RGBLine[0]);
                var g = int.Parse(RGBLine[1]);
                var b = int.Parse(RGBLine[2]);
                var color = System.Drawing.Color.FromArgb(r, g, b);
                bitmap.SetPixel(x, y, color);
                linePosition++;
            }

            Console.WriteLine("File Parsed");
            return bitmap;
        }

        public static Bitmap ConvertPpmToBitmap(string filePath)
        {
            Console.WriteLine("Attempting read...");
            var parsedPPM = File.ReadAllText(filePath);
            return StringPPMToBitmap(parsedPPM);
        }
    }
}