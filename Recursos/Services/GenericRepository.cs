using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursos.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public void Add(T obj)
        {
            Console.WriteLine("Adicionando objeto");
        }
    }
}
