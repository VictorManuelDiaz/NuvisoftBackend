using NuvisoftBackend.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Application.Interfaces
{
    public interface IAuxiliaryUseCase<Entity, EntityId> : ICreate<Entity>,
       IUpdate<Entity>, IDelete<EntityId>
    {
    }
}
