namespace GraphicsEngine
{
    internal interface IScatterStrategy
    {
        Ray Scatter();
        bool CanExecute();
    }
}