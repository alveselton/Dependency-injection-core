using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InjeccaoDependencia;

namespace InjeccaoDependencia
{
    public class Controller
    {
        private readonly IRecepcaoService _recepcaoService;
        public Controller(IRecepcaoService recepcaoService)
        {
            _recepcaoService = recepcaoService ??
                throw new ArgumentNullException(nameof(recepcaoService));
        }

        public string Ola(string nome) => _recepcaoService.Saudacao(nome);

    }
}
