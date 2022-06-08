namespace Simbi.Services.Models;

public class AdminRemarkServiceModel : BaseServiceModel
{
    public string Text { get; set; }

    public Guid CreatorId { get; set; }
    public UserServiceModel Creator { get; set; }
}
