using System;

namespace ServiceCollectionAndProvider.Services
{
    public class DemoService : IDemoService
    {
        public void ServicoDemo(int numero)
        {
            Console.WriteLine($"Realizando operação : {numero}");
        }
    }
}
