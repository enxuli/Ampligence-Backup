using System;
namespace AmpligenceBackup
{
    public interface IRectangle2D : IValueChangeable
    {
        bool isInRectangle(IVector point);

        IVector center { get; set; }
        IVector leftUp { get; set; }
        IVector rightUp { get; set; }
        IVector leftDown { get; set; }
        IVector rightDown { get; set; }

        float left { get; set; }
        float right { get; set; }
        float up { get; set; }
        float down { get; set; }

        float width { get; set; } //center fixed set
        float height { get; set; } //center fixed set
        float area { get; }

    }
}
