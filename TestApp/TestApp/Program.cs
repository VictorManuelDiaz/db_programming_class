using System;

using TestApp.Respository;
using TestApp.Entities;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*Transact transact = new Transact();
            transact.Create();
            transact.CreateWithParams("Casa nueva", "299822", 1);
            Console.WriteLine("Registro insertado");*/

            MusicianRepository musicians = new MusicianRepository();
            
            Console.WriteLine("Creando un nuevo músico...");
            musicians.Create(new Musician()
            {
                inss_number = "122222",
                first_name = "Jhon",
                last_name = "Doe",
                salary = 500,
                tb_address_id = 1,
                created_by = 1,
                updated_by = 1
            });

            Console.WriteLine("Mostrando listado de músicos...");
            Console.WriteLine("--------------------------------------------------------------");
            musicians.GetAll().ForEach(item => {
                Console.WriteLine($"{item.inss_number}\t{item.first_name}\t{item.last_name}");
            });
            Console.ReadKey();
        }
    }
}
