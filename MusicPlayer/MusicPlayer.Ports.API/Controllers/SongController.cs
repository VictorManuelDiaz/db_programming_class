using Microsoft.AspNetCore.Mvc;

using MusicPlayer.Adaptors.SQLServerDataAccess.Contexts;
using MusicPlayer.Core.Application.UseCases;
using MusicPlayer.Core.Infraestructure.Repository.Concrete;

using MusicPlayer.Core.Domain.Models;
using System.Collections.Generic;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicPlayer.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        public SongUseCase CreateService()
        {
            PlaylistDB db = new PlaylistDB();
            SongRepository repository = new SongRepository(db);
            SongUseCase service = new SongUseCase(repository);

            return service;
        }

        // GET: api/<SongController>
        [HttpGet]
        public ActionResult<IEnumerable<Song>> Get()
        {
            SongUseCase service = CreateService();
            return Ok(service.GetAll());
        }

        // GET api/<SongController>/5
        [HttpGet("{id}")]
        public ActionResult<Song> Get(Guid id)
        {
            SongUseCase service = CreateService();

            return Ok(service.GetById(id));
        }

        // POST api/<SongController>
        [HttpPost]
        public ActionResult<Song> Post([FromBody] Song song)
        {
            SongUseCase service = CreateService();

            var result = service.Create(song);

            return Ok(result);
        }

        // PUT api/<SongController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Song song)
        {
            SongUseCase service = CreateService();
            song.song_id = id;
            service.Update(song);

            return Ok("Editado exitosamente");
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            SongUseCase service = CreateService();
            service.Delete(id);
            return Ok("Eliminado exitosamente");
        }
    }
}
