using System;
using System.Collections.Generic;
using System.Text;

using MusicPlayer.Core.Domain.Interfaces;

namespace MusicPlayer.Core.Application.Interfaces
{
    public interface IBaseUseCase<Entity, EntityId> : ICreate<Entity>,
        IRead<Entity, EntityId>, IUpdate<Entity>, IDelete<EntityId>
    {
    }
}

