using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Respository
{
    interface IUpdate<Entity>
    {
        Entity Update(Entity entity);
    }
}
