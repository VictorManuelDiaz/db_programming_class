using System;
using System.Collections.Generic;
using System.Text;

using MusicPlayer.Core.Domain.Models;
using MusicPlayer.Core.Application.Interfaces;
using MusicPlayer.Core.Infraestructure.Repository.Abstract;

namespace MusicPlayer.Core.Application.UseCases
{
    public class AddedSongUseCase : IDetailUseCase<Playlist, Guid>
    {

        private readonly IBaseRepository<Playlist, Guid> playlistRepository;
        private readonly IDetailRepository<AddedSong, Guid> addedSongRepository;

        public AddedSongUseCase(
            IBaseRepository<Playlist, Guid> playlistRepository,
            IDetailRepository<AddedSong, Guid> addedSongRepository
        )
        {
            this.playlistRepository = playlistRepository;
            this.addedSongRepository = addedSongRepository;
        }

        public void Cancel(Guid entityId)
        {
            addedSongRepository.Cancel(entityId);
            addedSongRepository.saveAllChanges();
        }

        public Playlist Create(Playlist playlist)
        {
            var createdPlaylist = playlistRepository.Create(playlist);
            playlist.AddedSongs.ForEach(detail => {
                addedSongRepository.Create(detail);
            });
            playlistRepository.saveAllChanges();
            return createdPlaylist;
        }
    }
}

