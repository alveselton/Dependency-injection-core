using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InjeccaoDependencia;

namespace InjeccaoDependencia
{
    public class RecepcaoService : IRecepcaoService
    {
        public string Saudacao(string nome) => $"Olá, {nome}";

    }
}
