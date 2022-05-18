using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Respository
{
    public interface IRead<Entity, EntityId>
    {
        Entity GetById(EntityId entityId);
        /*Define un método del tipo entidad para seleccionar un registro por su id*/

        List<Entity> GetAll();
        /*Define un método que retorna una lista de registros*/
    }
}
