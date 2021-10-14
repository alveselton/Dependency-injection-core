using System;
using ServiceCollectionAndProvider.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceCollectionAndProvider
{
    class Program
    {
        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            // Equivalente ao que fazemos no método ConfigureServices 
            RegisterServices();

            Console.WriteLine("Iniciando Aplicação");

            //realiza a operação
            var teste = _serviceProvider.GetService<ITesteService>();
            teste.ServicoTeste();
            DisposeServices();

            Console.WriteLine("Operação Concluída");
            Console.ReadLine();
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();
            collection.AddScoped<IDemoService, DemoService>();
            collection.AddScoped<ITesteService, TesteService>();

            _serviceProvider = collection.BuildServiceProvider();
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }

            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
