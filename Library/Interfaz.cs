using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    interface Interfaz<T>
    {
        void Agregar(string dato);
        Nodo<T> eAgregar(Nodo<T> actual, Nodo<T> nuevo);
        string Buscar(string nodo);
        string eBuscar(Nodo<T> raiz,string nodo);
        void inOrden();
        void PreOrden(Nodo<T> raiz);
        void PosTOrden();
    }
}
