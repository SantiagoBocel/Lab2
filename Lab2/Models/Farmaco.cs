using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class Farmaco : IComparable
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Descrip { get; set; }
        public string Casa { get; set; }
        public string Precio { get; set; }
        public int Exis { get; set; }
        public int CompareTo(object obj)
        {
            var comparable = (Farmaco)obj;
            return id.CompareTo(comparable.id);
        }
    }
}