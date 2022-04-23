namespace Simbi.Services.Models;

public class AdminRemarkServiceModel
{
    public Guid Id { get; set; }

    public string Text { get; set; }

    public UserServiceModel Creator { get; set; }
}
