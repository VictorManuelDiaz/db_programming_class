using System;

using CinemaEFApp.Repository;
using CinemaEFApp.Data.Models;

namespace CinemaEFApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenreRepository genreRep = new GenreRepository();

            Console.WriteLine(new String('=', 100));
            Console.WriteLine("Creando nuevo género...\n");
            genreRep.Create(new Genre
            {
                name = "Terror",
                description = "No apto para menores"
            });
            genreRep.SaveAll();
            Console.WriteLine("Registro creado...");


            Console.WriteLine(new String('=', 100));
            Console.WriteLine("Seleccionando género por id...\n");
            var genre = genreRep.GetById(Guid.Parse("2A78100C-033F-4C29-860D-04BAD9992852"));
            Console.WriteLine($"Género seleccionado...\n{genre.genre_id}\t{genre.name}\t{genre.description}");

            Console.WriteLine(new String('=', 100));
            genre.name = "Romance";
            Console.WriteLine("Actualizando género por id...\n");
            genreRep.Update(genre);
            genreRep.SaveAll();
            Console.WriteLine("Registro actualizado...");

            Console.WriteLine(new String('=', 100));
            Console.WriteLine("Eliminando género por id...\n");
            genreRep.Delete(Guid.Parse("A0C3C230-0ADF-4FF6-BEA3-DAC12F9DC088"));
            genreRep.SaveAll();
            Console.WriteLine("Registro eliminado...");

            Console.WriteLine(new String('=', 100));
            Console.WriteLine("Mostrando registros entidad género...\n");
            genreRep.GetAll().ForEach(item => {
                Console.WriteLine($"{item.genre_id}\t{item.name}\t{item.description}");
            });
            Console.ReadKey();
        }
    }
}



