namespace Simbi.Services.Models;

public class PurchaseServiceModel
{
    public Guid Id { get; set; }

    public MaterialServiceModel Material { get; set; }

    public double QuantityInKilograms { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public double TotalPrice { get; set; }
}
