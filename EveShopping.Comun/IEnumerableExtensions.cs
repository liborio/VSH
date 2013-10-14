using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections.Generic
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> CopyToList<T>(IEnumerable<T> original)
        {
            List<T> lista = new List<T>();
            foreach (var item in original)
            {
                lista.Add(item);
            }
            return lista;
        }
    }
}
