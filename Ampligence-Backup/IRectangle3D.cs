namespace AmpligenceBackup
{
    public interface IRectangle3D
    {
        IVector center { get; }
        IVector leftUp { get; }
        IVector rightUp { get; }
        IVector leftDown { get; }
        IVector rightDown { get; }

        float width { get; } 
        float height { get; } 
        float area { get; }
    }
}