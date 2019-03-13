using Lab2.Models;
using Library;
using System.Collections.Generic;
using System.IO;


namespace Lab2.Singleton
{
    public class Data
    {
        private static Data _instance = null;
        public static Data Instance
        {
            get
            {
                if (_instance == null) _instance = new Data();
                return _instance;
            }
        }
        int poslista=0; 
        public string busqueda = "";
        public Library.Arbol<int> Arbol = new Library.Arbol<int>();
        public List<Factura> Factura = new List<Factura>();
        public List<Farmaco> pos = new List<Farmaco>();
        public List<cVenta> lVentas = new List<cVenta>();
        public bool flag=true;

        public double Pagar()
        {
            double totalapagar = 0;

            for (int i = 0; i < lVentas.Count; i++)
            {
                totalapagar = totalapagar +lVentas[i].Precio;
            }
            return totalapagar;
        }
        public void CustomSplit()
        {
            if (Instance.flag)
            {
                StreamReader objReader = new StreamReader("D:\\Estructurass\\Lab2\\Lab2\\Lab2\\obj\\Debug\\Datos.txt");
                string leerlineas = objReader.ReadLine();
              
                
                while (leerlineas != null)
                {
                    string[] datos= new string[6];
                    int n=0;
                    Farmaco objeto = new Farmaco();
                    
                    while (leerlineas != null)
                    {
                        int s1 = leerlineas.IndexOf(',');
                        int s2 = leerlineas.IndexOf('"');
                        if (s2 == -1) s2 = s1 + 1;
                        if (s1<s2 )
                        {//coma cerca
                            if (s1==-1)
                            {
                                datos[n] = leerlineas;
                                break;
                            }
                            else
                            {
                            string lel = leerlineas.Substring(0,s1);
                            leerlineas = leerlineas.Remove(0,s1+1);
                            datos[n] = lel;
                            }
                        }
                        else
                        {//comilla cerca
                            leerlineas = leerlineas.Remove(0, s2 + 1);
                            s2 = leerlineas.IndexOf('"');
                            string lel = leerlineas.Substring(0, s2);
                            leerlineas = leerlineas.Remove(0, s2 + 2);
                            datos[n] = lel;
                        }
                        n++;
                    }
                    leerlineas = objReader.ReadLine(); //Instance.Arbol.Agregar(raiz, objeto.id);
                        objeto.Id = int.Parse(datos[0]);
                        objeto.Nombre = datos[1];
                        objeto.Descrip = datos[2];
                        objeto.Casa = datos[3];
                        objeto.Precio = datos[4];
                        objeto.Exis = int.Parse(datos[5]);
                        pos.Add(objeto);
                    Arbol.Agregar(objeto.Nombre);
                }
                Instance.flag = false;
                objReader.Close();
            }
        }
        public Farmaco Buscar(int pos,string nombre)
        {
            Farmaco resultado = new Farmaco();
            string encuentra = Arbol.Buscar(nombre);
            if (encuentra=="" || encuentra == null)
            {
                encuentra = nombre;
            }
            if (this.pos[pos].Nombre== encuentra)
            {
                resultado = this.pos[pos];
                return resultado;
            }
                pos++;
             encuentra = Arbol.Buscar(nombre);
            return Buscar(pos, nombre);
        }
        public void Venta(int pos, string nombre)
        {
            cVenta Elemento = new cVenta();
            if (this.pos[pos].Nombre == nombre)
            {
               Elemento.Nombre= this.pos[pos].Nombre;
                this.pos[pos].Exis--;
               Elemento.Id = this.pos[pos].Id;
                string aux = this.pos[pos].Precio.Remove(0,1);
                Elemento.Precio = double.Parse(aux);
                lVentas.Add(Elemento);
                return ;
            }
            pos++;
            Venta(pos, nombre);
        }
        public void Quitar(int pos, string nombre)
            //// cambiar la poscicion  
        {
            cVenta Elemento = new cVenta();
            int indice = 0;
            if (this.pos[pos].Nombre == nombre)
            {
                ////////////////////////////////
                lVentas.RemoveAt(indice);                
                this.pos[pos].Exis++;
                return;
            }
            indice++;
            pos++;
            Quitar(pos, nombre);
        }

    }
}