public class TriangularPark : PropertyAsset
{
    // Fields
    public double BaseSpan, Height, Side1, Side2, Side3;

    // Constructor using base keyword
    public TriangularPark(string code, double taxRate, double baseSpan, double height, double s1, double s2, double s3)
        : base(code, taxRate)
    {
        BaseSpan = baseSpan;
        Height = height;
        Side1 = s1;
        Side2 = s2;
        Side3 = s3;
    }

    // Overriding abstract methods
    public override double ComputeFootprintArea()
    {
        return 0.5 * BaseSpan * Height;
    }

    public override double ComputeEnclosurePerimeter()
    {
        return Side1 + Side2 + Side3;
    }
}
