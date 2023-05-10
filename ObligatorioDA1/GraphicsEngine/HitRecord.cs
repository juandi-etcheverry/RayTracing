namespace GraphicsEngine
{
    internal class HitRecord
    {
        internal decimal ScalingFactor { get; set; }
        internal Vector IntersectionPoint { get; set; }
        internal Vector Normal { get; set; }
        internal Color Attenuation { get; set; }
    }
}