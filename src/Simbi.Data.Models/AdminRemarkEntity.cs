using Simbi.Data.Common;

namespace Simbi.Data.Models;

public class AdminRemarkEntity : ApplicationEntity
{
    public string Text { get; set; }

    public virtual UserEntity Creator { get; set; }
}
