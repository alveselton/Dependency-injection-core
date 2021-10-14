using System;
using Microsoft.Extensions.DependencyInjection;
using Recursos.Services;
using System.Linq;

namespace Recursos
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiploRegistro2();
            Console.WriteLine("Hello World!");
        }

        private static void RegistroInstanciaDemo()
        {
            var instancia = new MinhaInstancia { Valor = 44 };

            IServiceCollection services = new ServiceCollection();

            services.AddSingleton(instancia);

            foreach(ServiceDescriptor service in services)
            {
                if (service.ServiceType == typeof(MinhaInstancia))
                {
                    var instanciaRegistrada = (MinhaInstancia)service.ImplementationInstance;

                    Console.WriteLine("Instância Registrada: " + instanciaRegistrada.Valor);
                }
            }

            var serviceProvider = services.BuildServiceProvider();
            var minhaInstancia = serviceProvider.GetService<MinhaInstancia>();

            Console.WriteLine("Serviço Registro pelo registro de instância: " + minhaInstancia.Valor);
        }

        private static void RegistroGenerico()
        {
            Cliente cli = new Cliente();
            cli.Nome = "Elton Alves";

            IServiceCollection services = new ServiceCollection();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            var serviceProvider = services.BuildServiceProvider();

            var servico = serviceProvider.GetService<IGenericRepository<Cliente>>();

            servico.Add(cli);
        }

        private static void MultiploRegistro()
        {
            IServiceCollection servicos = new ServiceCollection();

            servicos.AddTransient<IServico, ServicoA>();
            servicos.AddTransient<IServico, ServicoB>();

            var serviceProvider = servicos.BuildServiceProvider();

            var meusServicos = serviceProvider.GetServices<IServico>().ToList();
            var meuServico = serviceProvider.GetService<IServico>();

            Console.WriteLine("----- Serviços -------");

            foreach (var servico in meusServicos)
            {
                Console.WriteLine(servico.Servico());
            }

            Console.WriteLine("----- Serviço -------");
            Console.WriteLine(meuServico.Servico());

        }

        private static void MultiploRegistro2()
        {
            IServiceCollection servicos = new ServiceCollection();

            servicos.AddTransient<IServico, ServicoA>();
            servicos.AddTransient<IServico, ServicoB>();

            servicos.AddTransient<Func<string, IServico>>(servicos => key =>
            {
                switch (key)
                {
                    case "A":
                        return servicos.GetService<ServicoA>();
                    case "B":
                        return servicos.GetService<ServicoB>();
                    default:
                        return null;
                }
            });
        }
    }
}
