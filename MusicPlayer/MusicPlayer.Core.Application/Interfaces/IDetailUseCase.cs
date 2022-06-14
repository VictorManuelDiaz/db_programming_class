using System;
using System.Collections.Generic;
using System.Text;

using MusicPlayer.Core.Domain.Interfaces;

namespace MusicPlayer.Core.Application.Interfaces
{
    public interface IDetailUseCase<Entity, EntityId> : ICreate<Entity>
    {
        void Cancel(EntityId entityId);
    }
}

