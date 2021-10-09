using NaoInjeccaoDependencia;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new Controller();
            string resultado = controller.Ola("Elton Alves");
            Console.WriteLine(resultado);
            Console.ReadLine();
        }
    }
}
