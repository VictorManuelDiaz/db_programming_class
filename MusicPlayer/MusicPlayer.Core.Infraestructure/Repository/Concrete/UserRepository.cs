using System;
using System.Collections.Generic;
using System.Text;

using MusicPlayer.Core.Domain.Models;
using MusicPlayer.Core.Infraestructure.Repository.Abstract;
using MusicPlayer.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace MusicPlayer.Core.Infraestructure.Repository.Concrete
{
    public class UserRepository : IBaseRepository<User, Guid>
    {
        private PlaylistDB db;
        public UserRepository(PlaylistDB db)
        {
            this.db = db;
        }
        public User Create(User user)
        {
            user.user_id = Guid.NewGuid();
            //Define nuevo identificador único
            db.Users.Add(user);
            return user;
        }

        public void Delete(Guid entityId)
        {
            var selectedUser = db.Users
                .Where(u => u.user_id == entityId).FirstOrDefault();
            //Selecciona el usuario a través del Id
            if (selectedUser != null)
            //Verifica si el usuario existe
                db.Users.Remove(selectedUser);
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public User GetById(Guid entityId)
        {
            var selectedUser = db.Users
                .Where(u => u.user_id == entityId).FirstOrDefault();
            return selectedUser;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public User Update(User user)
        {
            var selectedUser = db.Users
                .Where(u => u.user_id == user.user_id)
                .FirstOrDefault();
            //Selecciona el usuario por Id desde la BD
            if (selectedUser != null)
                //Verifica que el usuario existe
            {
                selectedUser.name = user.name;
                selectedUser.last_name = user.last_name;
                selectedUser.email = user.email;
                selectedUser.password = user.password;
                selectedUser.is_active = user.is_active;
                selectedUser.updated_at = DateTime.Now;
                //Modifica los datos del usuario con los valores del parámetro

                db.Entry(selectedUser).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
                //Enmarcar el estado del usuario como modificado
            }
            return selectedUser;
        }
    }
}


