using NuvisoftBackend.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Infraestructure.Repository.Abstract
{
    public interface IAuxiliaryRepository<Entity, EntityId> : ICreate<Entity>,
        IUpdate<Entity>, IDelete<EntityId>, ITransaction
    {
    }
}
