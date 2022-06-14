using System;
using System.Collections.Generic;
using System.Text;

using MusicPlayer.Core.Domain.Models;
using MusicPlayer.Core.Application.Interfaces;

using MusicPlayer.Core.Infraestructure.Repository.Abstract;

namespace MusicPlayer.Core.Application.UseCases
{
    public class SongUseCase : IBaseUseCase<Song, Guid>
    {
        private readonly IBaseRepository<Song, Guid> repository;

        public SongUseCase(IBaseRepository<Song, Guid> repository)
        {
            this.repository = repository;
        }

        public Song Create(Song entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                entity.length = TimeSpan.Parse(entity.length_str);
                repository.saveAllChanges();
                return result;
            }
            else
                throw new Exception("Error. La canción no puede ser nula");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.saveAllChanges();
        }

        public List<Song> GetAll()
        {
            return repository.GetAll();
        }

        public Song GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Song Update(Song entity)
        {
            entity.length = TimeSpan.Parse(entity.length_str);
            repository.Update(entity);
            repository.saveAllChanges();
            return entity;
        }
    }
}
