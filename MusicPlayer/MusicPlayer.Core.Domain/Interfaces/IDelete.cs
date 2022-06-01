using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.Core.Domain.Interfaces
{
    public interface IDelete<EntityId>
    {
        void Delete(EntityId entityId);
    }
}
