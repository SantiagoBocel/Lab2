using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class cVenta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int CompareTo(object obj)
        {
            var comparable = (cVenta)obj;
            return Id.CompareTo(comparable.Id);
        }
    }
}