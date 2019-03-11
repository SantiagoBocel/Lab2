using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Nodo <T>
    {
        public string Nombre { get; set; }
        public Nodo<T> hijoDer;
        public Nodo<T> hijoIzq;
        public int FactorBalance;
        public Nodo<T> Padre { get; internal set; }

        public Nodo(string DATO)
        {
            Nombre = DATO;
            hijoDer = null;
            hijoIzq = null;
        }
    }

}
