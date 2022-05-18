using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaEFApp.Repository.Interfaces
{
    interface IUpdate<Entity>
    {
        Entity Update(Entity entity);
    }
}
