using System;

namespace Simbi.Data.Common;

public class ApplicationEntity : BaseEntity<Guid>
{
    public ApplicationEntity() => this.Id = Guid.NewGuid();    
}
