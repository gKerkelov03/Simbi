namespace Simbi.Data.Common;

public class User : ApplicationEntity
{
    public string Password { get; set; }

    public string Username { get; set; }

    public Role Role { get; set; }
}
