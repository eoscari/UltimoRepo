using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabajo_final_csharp.App_Start
{
    public class FacturaReal
    {
        public int IdFactura;
        public DateTime fechaEmision;
        public DateTime fechaMovimiento;
        public string Tipo;//si es cobro o pago
        public Double Monto;
        public string Moneda;//dolar o peso
        public string Modo;//modo de pago si es efectivo con cheques 
        public int IdNota;
        public int IdCheque;
        public string Destinatario;
        public string Originante;

        //CONSTRUCTORES
        public FacturaReal() { }

        public FacturaReal(int IdFactura, DateTime fechaEmision, DateTime fechaMovimiento, string Tipo, Double Monto, string Moneda, string Modo, int IdNota, int IdCheque, string Destinatario, string Originante)
        {
            this.IdFactura = IdFactura;
            this.fechaEmision = fechaEmision;
            this.fechaMovimiento = fechaMovimiento;
            this.Tipo = Tipo;
            this.Monto = Monto;
            this.Moneda = Moneda;
            this.Modo = Modo;
            this.IdNota = IdNota;
            this.IdCheque = IdCheque;
            this.Destinatario = Destinatario;
            this.Originante = Originante;
        }
        public int SGIdFactura
        {
            get { return IdFactura; }
            set { IdFactura = value; }
        }

        public DateTime SGFechaEmi
        {
            get { return fechaEmision; }
            set { fechaEmision = value; }
        }

        public DateTime SGFechaMov
        {
            get { return fechaMovimiento; }
            set { fechaMovimiento = value; }
        }
        public string SGTipo
        {
            get { return Tipo; }
            set { Tipo = value; }
        }
        public Double SGMonto
        {
            get { return Monto; }
            set { Monto = value; }
        }
        public string SGMoneda
        {
            get { return Moneda; }
            set { Moneda = value; }
        }
        public string SGModo
        {
            get { return Modo; }
            set { Modo = value; }
        }
        public int SGIdNota
        {
            get { return IdNota; }
            set { IdNota = value; }
        }
        public int SGIdCheque
        {
            get { return IdCheque; }
            set { IdCheque= value; }
        }
        public string SGDestinatario
        {
            get { return Destinatario; }
            set { Destinatario = value; }
        }
        public string SGOriginante
        {
            get { return Originante; }
            set { Originante = value; }
        }
        public string FormatoFecha(DateTime fe)
        {
            return fe.ToString("dd/MM/yyyy");
        }
        public int Tamaño
        {
            get { return (8 + FormatoFecha(SGFechaEmi).Length * 2 + FormatoFecha(SGFechaMov).Length * 2 + SGTipo.Length*2 + 16 + SGMoneda.Length*2 + SGModo.Length*2 + 8 + 8 + SGDestinatario.Length*2 + SGOriginante.Length*2); }
        }
    }
}