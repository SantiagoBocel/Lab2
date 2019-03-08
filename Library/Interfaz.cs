using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    interface Interfaz<T>
    {
        void Agregar(Nodo<T> raiz, T dato);
        void Buscar(T nodo);
       void Auxiliar();
    }
}
