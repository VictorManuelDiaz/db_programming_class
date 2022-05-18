using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Respository
{
    interface ICreate<Entity>
        /*Recibe como argumento genérico un objeto del tipo Entity*/
    {
        Entity Create(Entity entity);
        /*Define un método para crear un nuevo registro*/
    }
}
