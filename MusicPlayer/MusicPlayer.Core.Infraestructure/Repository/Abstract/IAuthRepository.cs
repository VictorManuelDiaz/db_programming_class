using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.Core.Infraestructure.Repository.Abstract
{
    public interface IAuthRepository <Entity, Key>
    {
       Entity Login(Entity entity);
       string GetToken (Entity entity, Key key);
    }
}







