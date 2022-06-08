using Simbi.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simbi.Data.Models;

public class AdminRemarkEntity : ApplicationEntity
{
    public string Text { get; set; }

    [ForeignKey("Creator")]
    public Guid? CreatorId { get; set; }

    public virtual UserEntity? Creator { get; set; }
}
