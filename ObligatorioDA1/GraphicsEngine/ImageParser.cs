using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Permissions;

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

        public static int HashDate(DateTime t)
        {
            int year = t.Year;
            int month = t.Month;
            int day = t.Day;
            int hour = t.Hour;
            int min = t.Minute;
            int sec = t.Second;
            int mili = t.Millisecond;
            return year + month + day + hour + min + sec + mili;
        }
        public static Bitmap CreateBitmapFromPPMImage(PPMImage ppmImage)
        {
            string parsedPPM = ppmImage.parser.Parse();
            Console.WriteLine("Attempting to parse PPM to Bitmap");
            return StringPPMToBitmap(parsedPPM);
        }

        public static Bitmap CreateBitmapFromFilePath(string filePath)
        {
            if (filePath.EndsWith("ppm"))
            {
                return ConvertPpmToBitmap(filePath);
            }
            return new Bitmap(filePath);
        }

        private static Bitmap StringPPMToBitmap(string parsedPPM)
        {
            string[] imageLines = parsedPPM.Split('\n');
            int WIDHT_HEIGHT_LINE = 1;
            string[] size = imageLines[WIDHT_HEIGHT_LINE].Split(' ');
            int width = int.Parse(size[0]);
            int height = int.Parse(size[1]);
            Bitmap bitmap = new Bitmap(width, height);
            int linePosition = 2;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    string[] RGBLine = imageLines[linePosition].Split(' ');
                    int r = int.Parse(RGBLine[0]);
                    int g = int.Parse(RGBLine[1]);
                    int b = int.Parse(RGBLine[2]);
                    var color = System.Drawing.Color.FromArgb(r, g, b);
                    bitmap.SetPixel(x, y, color);
                    linePosition++;
                }
            }
            Console.WriteLine("File Parsed");
            return bitmap;
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
