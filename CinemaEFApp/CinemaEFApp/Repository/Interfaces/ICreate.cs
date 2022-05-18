using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaEFApp.Repository.Interfaces
{
    interface ICreate<Entity>
    {
        Entity Create(Entity entity);
    }
}
