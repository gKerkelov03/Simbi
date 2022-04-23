namespace Simbi.WindowsForms.Models;

public class OrderViewModel
{
    public Guid Id { get; set; }

    public string ClientName { get; set; }

    public string ClientPhoneNumber { get; set; }

    public ICollection<PurchaseViewModel> Purchases { get; set; }
}
