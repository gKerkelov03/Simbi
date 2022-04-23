namespace Simbi.Services.Models;

public class BaseServiceModel
{
    public Guid Id { get; set; }

    public BaseServiceModel() => this.Id = Guid.NewGuid();
}
