using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class Factura: cVenta
    {
        public string NIT { get; set; }
        public string Direccion { get; set; }
        public double Pagar { get; set; }
    }
}