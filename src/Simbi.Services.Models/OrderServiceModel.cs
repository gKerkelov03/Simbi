namespace Simbi.Services.Models;

public class OrderServiceModel
{
    public Guid Id { get; set; }

    public string ClientName { get; set; }

    public string ClientPhoneNumber { get; set; }

    public ICollection<PurchaseServiceModel> Purchases { get; set; }
}
