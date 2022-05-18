using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaEFApp.Repository.Interfaces
{
    interface IDelete<EntityId>
    {
        void Delete(EntityId entityId);
    }
}
