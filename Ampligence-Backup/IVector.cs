using System;
namespace AmpligenceBackup
{
    public interface IVector<T>
    {
        T this[int index] { get; set; }
        int length { get; }

        IVector Add(IVector v1, IVector v2);
        IVector Add(IVector v2);
        IVector Subtract(IVector v1, IVector v2);
        IVector Subtract(IVector v2);
        IVector Multiply(T value, IVector v);
        IVector Multiply(T value);
        IVector cross(IVector v1, IVector v2);
        IVector cross(IVector v2);
        T Dot(IVector v1, IVector v2);
        T Dot(IVector v2);
        T Distance(IVector v1, IVector v2);
        T Distance(IVector v2);
        T DistanceTo(IVector a);
        T Magnitude()
        {
            get;
        }
        bool Equals(IVector v1, IVector v2);
        bool Equals(IVector v2);
        IVector Transform(IVector value, Quaternion rotation);
        IVector Transform(Quaternion rotation);
        IVector Reflect(IVector v, IVector normal);
        IVector Reflect(IVector nomral);
        IVector Normalize()
        {
            get;
        }
        IVector Lerp(IVector v1, IVector v2, T amount);
        IVector Lerp(IVector v2, T amount);
        IVector Negate()
        {
            get;
        }
        IVector MidpointWith(IVector b);
        IVector ProjectOnto(IVector b);
        IVector DeltaFrom(IVector a);
        void Normalize();
    }
    public interface IVector : IVector<float>
    {

    }
}