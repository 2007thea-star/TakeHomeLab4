public abstract class PropertyAsset
{
    // Fields 
    public string PropertyCode;
    public double TaxRatePerUnitArea;

    // Constructor
    public PropertyAsset(string code, double taxRate)
    {
        PropertyCode = code;
        TaxRatePerUnitArea = taxRate;
    }

    // Abstract Methods
    public abstract double ComputeFootprintArea();
    public abstract double ComputeEnclosurePerimeter();

    // Virtual Method 
    public virtual double ComputeEstimatedTax()
    {
        return ComputeFootprintArea() * TaxRatePerUnitArea;
    }
}
