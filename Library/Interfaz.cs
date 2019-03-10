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
        Nodo<T> AgregarNodo(Nodo<T> actual, Nodo<T> nuevo);
        void Buscar(T nodo);
        void inOrden();
        void PreOrden(Nodo<T> raiz);
        void PosTOrden();
    }
}
