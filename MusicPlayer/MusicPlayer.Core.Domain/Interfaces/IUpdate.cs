using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.Core.Domain.Interfaces
{
    public interface IUpdate<Entity>
    {
        Entity Update(Entity entity);
    }
}
