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
        public Library.Arbol<int> Arbol = new Library.Arbol<int>();
        public List<Farmaco> Lista = new List<Farmaco>();
        public bool flag=true;

        public void CustomSplit()
        {
            if (Instance.flag)
            {
                StreamReader objReader = new StreamReader("D:\\Estructurass\\Lab2\\Lab2\\obj\\Debug\\Datos.txt");
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
                        objeto.id = int.Parse(datos[0]);
                        objeto.Nombre = datos[1];
                        objeto.Descrip = datos[2];
                        objeto.Casa = datos[3];
                        objeto.Precio = datos[4];
                        objeto.Exis = int.Parse(datos[5]);
                        Lista.Add(objeto);
                    Arbol.Agregar(objeto.Nombre);
                }
                Instance.flag = false;
                objReader.Close();
            }
        }
    }
}