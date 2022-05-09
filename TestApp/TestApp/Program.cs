using System;
using TestApp.Respository;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Transact transact = new Transact();
            //transact.Create();
            transact.CreateWithParams("Casa nueva", "299822", 1);
            Console.WriteLine("Registro insertado");
            Console.ReadKey();
        }
    }
}
