using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Respository
{
    interface IDelete<EntityId>
    {
        void Delete(EntityId entityId);
    }
}
