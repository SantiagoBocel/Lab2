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
            Nodo<T> siguiente = raiz;
            if (nuevo.dato.CompareTo(actual.dato) < 0)// delegdo  :3
            {
                if (actual.hijoIzq == null)
                {
                    siguiente.hijoIzq = new Nodo<T>(nuevo.dato);
                    siguiente.hijoIzq.Padre = siguiente;
                    Equilibrar(siguiente, true, true); //Es izquierdo = true, es nuevo true;
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
                    siguiente.hijoDer= new Nodo<T>(nuevo.dato);
                    siguiente.hijoDer.Padre = siguiente;
                    Equilibrar(siguiente, false, true); //es Izquierdo = false, es nuevo = true;
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

        internal void Equilibrar(Nodo<T> nodo, bool esIzquierdo, bool esNuevo)
        {
            bool bandera = false; //al terminar de recorrer una rama si no es necesario rotar entonces se convierte en verdadero.
            // Recorrer camino inverso actualizando valores de FE:
           
            while ((nodo != null) && !bandera)
            {
                bool hizoRotacion = false; //Al inicio digo que no se rotó

                if (esNuevo)
                {
                    if (esIzquierdo)
                        nodo.FactorBalance--; // Estamos añidiendo
                    else
                        nodo.FactorBalance++;
                }
                else
                {
                    if (nodo.FactorBalance == 0)
                        bandera = true;

                    if (esIzquierdo)
                        nodo.FactorBalance++; // Borrando un nodo
                    else
                        nodo.FactorBalance--;
                }

                if (nodo.FactorBalance == 0)
                    bandera = true; // La altura de el arbol que empieza en nodo no ha variado, salir de Equilibrar

                //Si existe algún desbalance en esta porción de código se realizan las rotaciones
                else if (nodo.FactorBalance == -2)
                { // Rotación a la derecha doble o simple según sea el caso y salir.
                    if (nodo.hijoIzq.FactorBalance == 1)
                    {
                        RDD(nodo); // Rotación doble
                        hizoRotacion = true;
                    }
                    else
                    {
                        RSD(nodo); // Rotación simple
                        hizoRotacion = true;
                    }
                    bandera = true;
                }
                else if (nodo.FactorBalance == 2)
                {  // Rotar a la izquierda doble o simple según sea el caso y salir.
                    if (nodo.hijoDer.FactorBalance == -1)
                    {
                        RDI(nodo); // Rotación doble
                        hizoRotacion = true;
                    }
                    else
                    {
                        RSI(nodo); // Rotación simple
                        hizoRotacion = true;
                    }
                    bandera = true;
                }

                if ((hizoRotacion) && (nodo.Padre != null) && (!esNuevo))
                    nodo = nodo.Padre;

                if (nodo.Padre != null)
                {
                    if (nodo.Padre.hijoDer == nodo)
                        esIzquierdo = false;
                    else
                        esIzquierdo = true;

                    if ((!esNuevo) && (nodo.FactorBalance == 0))
                        bandera = false;

                }

                nodo = nodo.Padre; // Calcular Factor de balance, siguiente nodo del camino ossea el padre.
            }
        }

        private void RSI(Nodo<T> nodo)
        {
            //Punteros necesarios para realizar la rotación.
            Nodo<T> Padre = nodo.Padre; //Padre del arbol desbalanceado
            Nodo<T> P = nodo; //Arbol desbalanceado con FE 2
            Nodo<T> Q = P.hijoDer;
            Nodo<T> B = Q.hijoIzq; //Nodo con altura igual a el hijo izquierdo de P

            //Si el padre del nodo desequilibrado no es null verifico si el nodo desequilibrado es el derecho
            //o el izquierdo, si el padre es null, significa que es la raiz.
            if (Padre != null)
            {
                if (Padre.hijoDer == P)
                    Padre.hijoDer = Q;
                else
                    Padre.hijoIzq = Q;
            }
            else
            {
                raiz = Q as Nodo<T>;
                raiz.Padre = null; //para que siga funcionando el padre de la raiz debe ser nulo.
            }

            //Reconstruyo el padre, 
            P.hijoDer = B;
            Q.hijoIzq = P;

            //Asignando nuevos padres
            P.Padre = Q;
            if (B != null)
                B.Padre = P;
            Q.Padre = Padre;

            //Ajusto valores del Factor de Balance
            if (Q.FactorBalance == 0)
            {
                P.FactorBalance = 1;
                Q.FactorBalance = -1;
            }
            else
            {
                P.FactorBalance = 0;
                Q.FactorBalance = 0;
            }
        }

        private void RDI(Nodo<T> nodo)
        {
            //Punteros necesarios para realizar la rotación
            Nodo<T> Padre = nodo.Padre;
            Nodo<T> P = nodo;
            Nodo<T> Q = nodo.hijoDer;
            Nodo<T> R = Q.hijoIzq;
            Nodo<T> B = R.hijoIzq;
            Nodo<T> C = R.hijoDer;

            //Si el padre del nodo desequilibrado no es null verifico si el nodo desequilibrado es el derecho
            //o el izquierdo, si el padre es null, significa que es la raiz.
            if (Padre != null)
            {
                if (Padre.hijoDer == P)
                    Padre.hijoDer = R;
                else
                    Padre.hijoIzq = R;
            }
            else
            {
                raiz = R as Nodo<T>;
                raiz.Padre = null; //para que siga funcionando el padre de la raiz debe ser nulo.
            }

            // Recontrucción del árbol 
            P.hijoDer = B;
            Q.hijoIzq = C;
            R.hijoIzq = P;
            R.hijoDer = Q;

            //Actualizando a los padres
            R.Padre = Padre;
            P.Padre = Q.Padre = R;
            if (B != null)
                B.Padre = P;
            if (C != null)
                C.Padre = Q;


            // Ajustar valores de Factores de Balance
            switch (R.FactorBalance)
            {
                case -1:
                    {
                        P.FactorBalance = 0;
                        Q.FactorBalance = 1;
                    }
                    break;

                case 0:
                    {
                        P.FactorBalance = 0;
                        Q.FactorBalance = 0;
                    }
                    break;

                case 1:
                    {
                        P.FactorBalance = -1;
                        Q.FactorBalance = 0;
                    }
                    break;
            }
            R.FactorBalance = 0;
        }

        private void RSD(Nodo<T> nodo)
        {
            //Punteros necesarios para realizar la rotación.
            Nodo<T> Padre = nodo.Padre; //Parde el árbol desequilibrado.
            Nodo<T> P = nodo; //Nodo desequilibrado
            Nodo<T> Q = P.hijoIzq;
            Nodo<T> B = Q.hijoDer; //Nodo con altura igual al hijo derecho de P

            //Si el padre del nodo desequilibrado nho es null verifico si el nodo desequilibrado es el derecho
            //o el izquierdo, si el padre es null, significa que es la raiz.
            if (Padre != null)
            {
                if (Padre.hijoDer == P)
                    Padre.hijoDer = Q;
                else
                    Padre.hijoIzq = Q;
            }
            else
            {
                raiz = Q as Nodo<T>;
                raiz.Padre = null; //para que siga funcionando el padre de la raiz debe ser nulo.
            }

            //Reconstruyo el arbol
            P.hijoIzq = B;
            Q.hijoDer = P;

            //Actualizando los nuevos padres
            P.Padre = Q;
            if (B != null)
                B.Padre = P;
            Q.Padre = Padre;


            //Ajuste de valores del factor de balance
            if (Q.FactorBalance == 0)
            {
                P.FactorBalance = -1;
                Q.FactorBalance = 1;

            }
            else
            {
                P.FactorBalance = 0;
                Q.FactorBalance = 0;
            }

        }

        private void RDD(Nodo<T> nodo)
        {
            //Punteros necesarios para realizar la rotación
            Nodo<T> Padre = nodo.Padre;
            Nodo<T> P = nodo;
            Nodo<T> Q = P.hijoIzq;
            Nodo<T> R = Q.hijoDer;
            Nodo<T> B = R.hijoIzq;
            Nodo<T> C = R.hijoDer;

            //Si el padre del nodo desequilibrado no es null verifico si el nodo desequilibrado es el derecho
            //o el izquierdo, si el padre es null, significa que es la raiz.
            if (Padre != null)
            {
                if (Padre.hijoDer == P)
                    Padre.hijoDer = R;
                else
                    Padre.hijoIzq = R;
            }
            else
            {
                raiz = R as Nodo<T>;
                raiz.Padre = null; //para que siga funcionando el padre de la raiz debe ser nulo.
            }

            // Reconstruir árbol:
            Q.hijoDer = B;
            P.hijoIzq = C;
            R.hijoIzq = Q;
            R.hijoDer = P;

            // Reasignar padres:
            R.Padre = Padre;
            P.Padre = Q.Padre = R;
            if (B != null)
                B.Padre = Q;
            if (C != null)
                C.Padre = P;


            // Ajustar valores de FE:
            switch (R.FactorBalance)
            {
                case -1:
                    {
                        Q.FactorBalance = 0;
                        P.FactorBalance = 1;
                    }
                    break;

                case 0:
                    {
                        Q.FactorBalance = 0;
                        P.FactorBalance = 0;
                    }
                    break;

                case 1:
                    {
                        Q.FactorBalance = -1;
                        P.FactorBalance = 0;
                    }
                    break;
            }
            R.FactorBalance = 0;
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
