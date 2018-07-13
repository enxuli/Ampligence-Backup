using UnityEngine;

namespace AmpligenceBackup.Mapping
{
    public interface IMappingTransform
    {
        IRectangle3D Rectangle3D { get; }

        void InitMap(IRectangle2D rectangle2D);
        void Translate(IVector destination);
        void TranslateByDelta(IVector delta);
        void Rotate(Quaternion quaternion);
        void Scale(float scaleLocalX, float scaleLocalY);
    }
}