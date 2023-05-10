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
    }
}