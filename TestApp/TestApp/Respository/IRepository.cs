using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Respository
{
    interface IRepository<Entity, EntityId> : ICreate<Entity>, IRead<Entity,
        EntityId>, IUpdate<Entity>, IDelete<EntityId>
    {

    }
}
