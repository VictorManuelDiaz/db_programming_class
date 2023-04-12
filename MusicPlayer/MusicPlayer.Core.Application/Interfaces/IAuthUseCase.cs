using System;
using System.Collections.Generic;
using System.Text;
using MusicPlayer.Core.Domain.Models;

namespace MusicPlayer.Core.Application.Interfaces
{
    public interface IAuthUseCase
    {
        string Login(User user, string key);
    }
}





