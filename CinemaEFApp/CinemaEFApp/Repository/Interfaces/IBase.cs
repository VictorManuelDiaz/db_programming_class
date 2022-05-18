using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaEFApp.Repository.Interfaces
{
    interface IBase<Entity, EntityId> : ICreate<Entity>, IRead<Entity,
        EntityId>, IUpdate<Entity>, IDelete<EntityId>
    {

    }
}
