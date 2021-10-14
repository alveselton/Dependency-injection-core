using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursos.Services
{

    public interface IGenericRepository<T>
    {
        public void Add(T obj);
    }
}

