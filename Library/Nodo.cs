using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Nodo <T>
    {
        public T dato { get; set; }
        public Nodo<T> hijoDer { get; set; }
        public Nodo<T> hijoIzq { get; set; }

        public Nodo(T DATO)
        {
            dato = DATO;
            hijoDer = null;
            hijoIzq = null;
        }
    }

}
