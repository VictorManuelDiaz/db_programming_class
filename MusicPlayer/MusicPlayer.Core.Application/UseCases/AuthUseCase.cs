using System;
using System.Collections.Generic;
using System.Text;
using MusicPlayer.Core.Application.Interfaces;
using MusicPlayer.Core.Domain.Models;
using MusicPlayer.Core.Infraestructure.Repository.Abstract;

using Newtonsoft.Json;

namespace MusicPlayer.Core.Application.UseCases
{
    public class AuthUseCase : IAuthUseCase
    {
        private readonly IAuthRepository<User, string> repository;
        public AuthUseCase(IAuthRepository<User, string> repository)
        {
            this.repository = repository;
        }
        public string Login(User user, string key)
        {
            var currentUser = repository.Login(user);
            if (currentUser == null)
            {
                return null;
            }
            var token = repository.GetToken(user, key);
            string result = JsonConvert.SerializeObject(new
            {
                token,
                user = currentUser
            });
            return result;
        }
    }
}


