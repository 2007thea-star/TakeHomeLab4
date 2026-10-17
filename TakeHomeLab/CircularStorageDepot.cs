using System.ComponentModel.DataAnnotations;

public class CircularStorageDepot : PropertyAsset
{
    // Field
    public double Radius;


    // Constructor using base keyword
    public CircularStorageDepot(string code, double taxRate, double radius)
        : base(code, taxRate)
    {
        Radius = radius;

    }

    // Overriding abstract methods
    public override double ComputeFootprintArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override double ComputeEnclosurePerimeter()
    {
        return 2 * Math.PI * Radius;
    }
}

