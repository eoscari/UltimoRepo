using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trabajo_final_csharp.App_Start;

namespace Trabajo_final_csharp.App_Start
{
    public class TipoNotas
    {
        private int idNota;
        private int IdFactura;
        private String tipo;
        private double monto;
        private DateTime fecha;//fecha de cobro o pago y esta a 30 dias
        //private String fecha;

        //CONSTRUCTOR

        //public TipoNotas()
        //{
        //}

        public TipoNotas(int id,int IF, String tip, double mon, DateTime fec)
        {
            this.idNota = id;
            this.IdFactura = IF;
            this.tipo = tip;
            this.monto = mon;
            this.fecha = fec;
        }

        //PROPERTIES

        public int IdNota
        {
            set { this.idNota = value; }
            get { return this.idNota; }
        }

        public int SGIdFact {
            set { this.IdFactura = value; }
            get { return IdFactura; }
        }

        public String Tipo
        {
            set { this.tipo = value; }
            get { return this.tipo; }
        }

        public double Monto
        {
            set { this.monto = value; }
            get { return this.monto; }
        }

        public DateTime Fecha
        {
            set { this.fecha = value; }
            get { return this.fecha; }
        }
        public string FormatoFecha(DateTime fe)
        {
            return fe.ToString("dd/MM/yyyy");
        }


        public int Tamaño //tamaño del registro Notas
        {
            // Longitud en bytes de los atributos (un long = 8 bytes)
            get { return 4 + Tipo.Length * 2 + 16 + (FormatoFecha(fecha).Length * 2)+8; }
        }
    }
}