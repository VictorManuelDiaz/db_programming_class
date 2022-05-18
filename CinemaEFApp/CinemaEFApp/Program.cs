using System;

using CinemaEFApp.Repository;
using CinemaEFApp.Data.Models;

namespace CinemaEFApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new String('=', 100));
            Console.WriteLine("Creando nuevo género...\n");
            GenreRepository genreRep = new GenreRepository();
            genreRep.Create(new Genre
            {
                name = "Terror",
                description = "No apto para menores"
            });
            genreRep.SaveAll();
            Console.WriteLine("Registro creado...");

            Console.WriteLine(new String('=', 100));
            Console.WriteLine("Mostrando registros entidad género...\n");
            genreRep.GetAll().ForEach(item => {
                Console.WriteLine($"{item.genre_id}\t{item.name}\t{item.description}");
            });

            Console.ReadKey();
        }
    }
}



