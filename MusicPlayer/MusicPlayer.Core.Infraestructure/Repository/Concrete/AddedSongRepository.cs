using System;
using System.Collections.Generic;
using System.Text;

using MusicPlayer.Core.Infraestructure.Repository.Abstract;
using MusicPlayer.Core.Domain.Models;
using MusicPlayer.Adaptors.SQLServerDataAccess.Contexts;

using System.Linq;

namespace MusicPlayer.Core.Infraestructure.Repository.Concrete
{
    public class AddedSongRepository : IDetailRepository<AddedSong, Guid>
    {

        private PlaylistDB db;
        public AddedSongRepository(PlaylistDB db)
        {
            this.db = db;
        }


        public void Cancel(Guid transactionId)
        {
            var selectedSongs = GetDetailsByTransaction(transactionId);

            if (selectedSongs != null)
            {
                selectedSongs.ForEach(detail => {
                    db.AddedSongs.Remove(detail);
                });
            }
            else
                throw new NullReferenceException("No se han encontrado canciones para eliminar...");
        }

        public AddedSong Create(AddedSong entity)
        {
            db.AddedSongs.Add(entity);
            return entity;
        }

        public List<AddedSong> GetDetailsByTransaction(Guid transactionId)
        {
            var selectedSongs = db.AddedSongs
                .Where(ads => ads.playlist_id == transactionId)
                .ToList();
            return selectedSongs;
        }

        public void saveAllChanges()
        {
            throw new NotImplementedException();
        }
    }
}




















