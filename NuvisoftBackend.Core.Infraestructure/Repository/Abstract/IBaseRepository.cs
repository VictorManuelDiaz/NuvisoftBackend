using NuvisoftBackend.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuvisoftBackend.Core.Infraestructure.Repository.Abstract
{
    public interface IBaseRepository<Entity, EntityId> : ICreate<Entity>,
        IRead<Entity, EntityId>, IUpdate<Entity>, IDelete<EntityId>, ITransaction
    {
    }
}
