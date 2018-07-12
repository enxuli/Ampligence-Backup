namespace AmpligenceBackup.Mapping
{
    public interface IMappingTransform
    {
        IRectangle3D Map(IRectangle2D rectangle2D);
    }
}