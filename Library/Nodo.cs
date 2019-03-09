using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Nodo <T>
    {
        public string dato { get; set; }
        public Nodo<T> hijoDer { get; set; }
        public Nodo<T> hijoIzq { get; set; }

        public Nodo(string DATO)
        {
            dato = DATO;
            hijoDer = null;
            hijoIzq = null;
        }
    }

}
