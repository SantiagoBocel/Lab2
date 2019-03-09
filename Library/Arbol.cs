using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Arbol<T> : Interfaz<T> where T: IComparable
    {
        static Nodo<T> raiz;
       
        public Arbol() // contructor
        {
            raiz=null;
        }

        public void Agregar(string identificador)
        {

            var nuevo = new Nodo<T>(identificador);

            if (raiz == null)
            {
                
                raiz = nuevo;
            }
            else
            {
                AgregarNodo(raiz, nuevo);
            }
        }

        public Nodo<T> AgregarNodo(Nodo<T> actual, Nodo<T> nuevo)
        {
            if (nuevo.dato.CompareTo(actual.dato) < 0)
            {
                if (actual.hijoIzq == null)
                {
                    actual.hijoIzq = nuevo;
                    return actual;
                }
                else
                {
                    actual.hijoIzq = AgregarNodo(actual.hijoIzq,nuevo);
                    return actual;
                }
            }
            else if (nuevo.dato.CompareTo(actual.dato) > 0)
            {
                if (actual.hijoDer == null)
                {
                    actual.hijoDer = nuevo;
                    return actual;
                }
                else
                {
                    actual.hijoDer = AgregarNodo(actual.hijoDer, nuevo);
                    return actual;
                }
            } else
            {
                return null;
            }
        }

        public void Buscar(T nodo)
        {
            throw new NotImplementedException();
        }

        public void inOrden()
        {
            if (raiz != null)
            {
                PreOrden(raiz.hijoIzq);
                // mostrar dato
                PreOrden(raiz.hijoDer);
            }
        }

        public void PosTOrden()
        {
            if (raiz != null)
            {
                PreOrden(raiz.hijoIzq);
                PreOrden(raiz.hijoDer);
                // mostrar dato
            }
        }

        public void PreOrden(Nodo<T> raiz)
        {
            if (raiz != null)
            {
                // mostrar dato
                PreOrden(raiz.hijoIzq);
                PreOrden(raiz.hijoDer);
            }
        }
    }
}
