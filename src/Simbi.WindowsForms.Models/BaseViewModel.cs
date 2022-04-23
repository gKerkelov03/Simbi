namespace Simbi.WindowsForms.Models;

public class BaseViewModel 
{
    public Guid Id { get; set; }

    public BaseViewModel() => this.Id = Guid.NewGuid();
}
