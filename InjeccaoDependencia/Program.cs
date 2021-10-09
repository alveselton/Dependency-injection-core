using System;

namespace InjeccaoDependencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new Controller(new RecepcaoService());
            string resultado = controller.Ola("Elton Alves");

            Console.WriteLine(resultado);
        }
    }
}
