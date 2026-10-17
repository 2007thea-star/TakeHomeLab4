using System.ComponentModel.DataAnnotations;

public class ResidentialLot : PropertyAsset
{
    // Fields
    public double Frontage;
    public double Depth;

    // Constructor
    public ResidentialLot(string code, double taxRate, double frontage, double depth)
        : base(code, taxRate)
    {
        Frontage = frontage;
        Depth = depth;
     
    }

    // Abstract methods
    public override double ComputeFootprintArea()
    {
        return Frontage * Depth;
    }

    public override double ComputeEnclosurePerimeter()
    {
        return 2 * (Frontage + Depth);
    }
}

