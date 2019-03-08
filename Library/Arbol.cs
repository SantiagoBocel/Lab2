using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Arbol<T> : Interfaz<T> where T: IComparable
    {
        static Nodo<T> rArbol;
       
        public void Agregar(Nodo<T> raiz, T dato)
        {
            if (rArbol == null)
            {
                var nuevo = new Nodo<T>(dato);
                rArbol = nuevo;
            }
            else
            {
                var nuevo = new Nodo<T>(dato);
                bool validar = nuevo.dato.CompareTo(rArbol.dato) > 0;//devuelve 

                if (validar == false)
                {
                    Agregar(raiz.hijoIzq, dato);
                }
                else
                {
                    Agregar(raiz.hijoIzq, dato);

                }
            }
        }
        public void Auxiliar()
        {
            throw new NotImplementedException();
        }

        public void Buscar(T nodo)
        {
            throw new NotImplementedException();
        }
    }
}
