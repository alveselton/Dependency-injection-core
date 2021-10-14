using System;
using Microsoft.Extensions.DependencyInjection;
using TempoVidaServico.Services;

namespace TempoVidaServico
{
    class Program
    {
        static void Main(string[] args)
        {
            Exemplo02();
        }

        private static void Exemplo01()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<TransientOperacao>();
            services.AddScoped<ScopedOperacao>();
            services.AddSingleton<SingletonOperacao>();

            var serviceProvider = services.BuildServiceProvider();

            Console.WriteLine("-------- Primeiro Request --------\n");

            var transientService = serviceProvider.GetService<TransientOperacao>();
            var scopedService = serviceProvider.GetService<ScopedOperacao>();
            var singletonService = serviceProvider.GetService<SingletonOperacao>();

            Console.WriteLine();
            Console.WriteLine("-------- Segundo Request --------\n");

            var transientService2 = serviceProvider.GetService<TransientOperacao>();
            var scopedService2 = serviceProvider.GetService<ScopedOperacao>();
            var singletonService2 = serviceProvider.GetService<SingletonOperacao>();

            Console.WriteLine();
            Console.WriteLine(new String('-', 33));
            Console.ReadLine();
        }

        private static void Exemplo02()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<TransientOperacao>();
            services.AddScoped<ScopedOperacao>();
            services.AddSingleton<SingletonOperacao>();

            var serviceProvider = services.BuildServiceProvider();

            Console.WriteLine();
            Console.WriteLine("-------- Primeiro Request --------");

            using (var scope = serviceProvider.CreateScope())
            {
                var transientService = scope.ServiceProvider.GetService<TransientOperacao>();
                var scopedService = scope.ServiceProvider.GetService<ScopedOperacao>();
                var singletonService = scope.ServiceProvider.GetService<SingletonOperacao>();
            }

            Console.WriteLine();
            Console.WriteLine("-------- Segundo Request --------");

            using (var scope = serviceProvider.CreateScope())
            {
                var transientService = scope.ServiceProvider.GetService<TransientOperacao>();
                var scopedService = scope.ServiceProvider.GetService<ScopedOperacao>();
                var singletonService = scope.ServiceProvider.GetService<SingletonOperacao>();
            }
            Console.WriteLine();
            Console.WriteLine("-----------------------------");
        }
    }
}
