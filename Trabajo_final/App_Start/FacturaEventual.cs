using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Trabajo_final_csharp.App_Start
{
    public class FacturaEventual
    {
        private DateTime FechaDeEmision;
        private DateTime FechaDeMovimiento;
        private int IdMovimientoRec;
        private string Destinatario;
        private string Originante;


        public FacturaEventual() { }

        public FacturaEventual(DateTime FE, DateTime FM, int IM,String des,string ori)
        {
            this.FechaDeEmision = FE ;
            this.FechaDeMovimiento=FM;
            this.IdMovimientoRec=IM;
            this.Destinatario = des;
            this.Originante = ori;
        }

        public DateTime SGFechaEmision
        {
            get { return FechaDeEmision; }
            set { FechaDeEmision = value; }
        }

        public DateTime SGFechaDeMov
        {
            get { return FechaDeMovimiento; }
            set { FechaDeMovimiento = value; }
        }

        public int SGIdMoveRec
        {
            get { return IdMovimientoRec; }
            set { IdMovimientoRec = value; }
        }

        public String SGDestinatario
        {
            get { return Destinatario; }
            set { Destinatario = value; }
        }

        public String SGOriginante
        {
            get { return Originante; }
            set { Originante = value; }
        }

        public string FormatoFecha(DateTime fe)
        {
            return fe.ToString("dd/MM/yyyy");
        }

        public int Tamaño //tamaño del registro Persona
        {
            // Longitud en bytes de los atributos (un long = 8 bytes)
            get { return (FormatoFecha(SGFechaEmision).Length * 2 + FormatoFecha(FechaDeMovimiento).Length * 2 +(Destinatario.Length*2)+(Originante.Length*2)+8); }
        }
    }
}