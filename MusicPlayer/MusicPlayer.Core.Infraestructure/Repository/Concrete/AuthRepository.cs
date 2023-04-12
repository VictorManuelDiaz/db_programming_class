using System;
using System.Collections.Generic;
using System.Text;

using MusicPlayer.Core.Domain.Models;
using MusicPlayer.Core.Infraestructure.Repository.Abstract;

using MusicPlayer.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MusicPlayer.Core.Infraestructure.Repository.Concrete
{
    public class AuthRepository : IAuthRepository<User, string>
    {
        private PlaylistDB db;
        public AuthRepository(PlaylistDB db)
        {
            this.db = db;
        }
        public string GetToken(User entity, string key)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            /*Crea clave secreta de cifrado a partir de la cadena
            definida en las configuraciones de la API*/
            var tokenDescriptor = new SecurityTokenDescriptor
            //Define los atributos relacionados con el token
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, entity.name)
                }),
                //Crea el encabezado con datos del usurario
                Expires = DateTime.UtcNow.AddHours(1),
                //Añade plazo de expiración del token
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                )
                //Define la firma, utilizando la clave secreta para cifrar
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public User Login(User entity)
        {
            var currentUser = db.Users
                .Where(u => u.name == entity.name &&
                    u.password == entity.password
                ).FirstOrDefault();
            return currentUser;
        }
    }
}



