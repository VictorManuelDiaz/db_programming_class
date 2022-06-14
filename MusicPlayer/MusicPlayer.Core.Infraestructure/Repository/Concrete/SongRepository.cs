using System;
using System.Collections.Generic;
using System.Text;

using MusicPlayer.Core.Domain.Models;
using MusicPlayer.Core.Infraestructure.Repository.Abstract;
using MusicPlayer.Adaptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace MusicPlayer.Core.Infraestructure.Repository.Concrete
{
    public class SongRepository : IBaseRepository<Song, Guid>
    {
        private PlaylistDB db;
        public SongRepository(PlaylistDB db)
        {
            this.db = db;
        }

        public Song Create(Song song)
        {
            song.song_id = Guid.NewGuid();
            song.created_at = DateTime.Now;
            song.updated_at = DateTime.Now;
            db.Songs.Add(song);
            return song;
        }

        public void Delete(Guid entityId)
        {
            var selectedSong = db.Songs
               .Where(s => s.song_id == entityId).FirstOrDefault();
            
            if (selectedSong != null)
                db.Songs.Remove(selectedSong);
        }

        public List<Song> GetAll()
        {
            return db.Songs.ToList();
        }

        public Song GetById(Guid entityId)
        {
            var selectedSong = db.Songs
                .Where(s => s.song_id == entityId).FirstOrDefault();
            return selectedSong;
        }

        public void saveAllChanges()
        {
            db.SaveChanges();
        }

        public Song Update(Song entity)
        {
            var selectedSong = db.Songs
               .Where(s => s.song_id == entity.song_id)
               .FirstOrDefault();
            
            if (selectedSong != null)
            {
                selectedSong.title = entity.title;
                selectedSong.image = entity.image;
                selectedSong.length = entity.length;
                selectedSong.artist = entity.artist;
                selectedSong.album = entity.album;
                selectedSong.updated_at = DateTime.Now;

                db.Entry(selectedSong).State =
                    Microsoft.EntityFrameworkCore.EntityState.Modified;
                //Enmarcar el estado del usuario como modificado
            }
            return selectedSong;
        }
    }
}
