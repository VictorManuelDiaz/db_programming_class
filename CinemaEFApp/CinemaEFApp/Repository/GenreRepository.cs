using System;
using System.Collections.Generic;
using System.Text;

using CinemaEFApp.Data.Models;
using CinemaEFApp.Repository.Interfaces;
using CinemaEFApp.Data.Contexts;

using System.Linq;

namespace CinemaEFApp.Repository
{
    class GenreRepository : IBase<Genre, Guid>
    {
        private CinemaDB db = new CinemaDB();
        public Genre Create(Genre entity)
        {
            entity.genre_id = Guid.NewGuid();

            db.genres.Add(entity);

            return entity;
        }

        public void Delete(Guid entityId)
        {
            db.genres.Remove(new Genre() { genre_id = entityId});
        }

        public List<Genre> GetAll()
        {
            return db.genres.ToList();
        }

        public Genre GetById(Guid entityId)
        {
            var selectedGenre = db.genres.Where(g => g.genre_id == entityId).FirstOrDefault();
            return selectedGenre;
        }

        public Genre Update(Genre entity)
        {
            db.genres.Update(entity);
            return entity;
        }

        public void SaveAll()
        {
            db.SaveChanges();
        }
    }
}

