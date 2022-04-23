namespace Simbi.WindowsForms.Models;

public class OrderViewModel : BaseViewModel
{
    public string ClientName { get; set; }

    public string ClientPhoneNumber { get; set; }

    public ICollection<PurchaseViewModel> Purchases { get; set; }
}
