namespace Simbi.WindowsForms.Models;

public class PurchaseViewModel
{
    public Guid Id { get; set; }

    public string Material { get; set; }

    public double QuantityInKilograms { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public double TotalPrice { get; set; }
}
