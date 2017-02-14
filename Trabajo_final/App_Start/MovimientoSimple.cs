using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabajo_final_csharp.App_Start
{
    public class MovimientoSimple
    {
        private string TipoMovimiento;//si es cobro o pago
        private string Moneda;
        private Double Monto;
        private int IdFactura;
        private Double TipoDeCambio;

        //CONSTRUCTORES
        public MovimientoSimple(){}

        public MovimientoSimple(string TM, string mone, Double M, int IF, Double TC)
        {
            this.TipoMovimiento = TM;
            this.Moneda = mone;
            this.Monto = M;
            this.IdFactura = IF;
            this.TipoDeCambio = TC;
        }
        public string SGTipoMov
        {
            get { return TipoMovimiento; }
            set { TipoMovimiento = value; }
        }
        public string SGMoneda
        {
            get { return Moneda; }
            set { Moneda = value; }
        }
        public Double SGMonto
        {
            get { return Monto; }
            set { Monto = value; }
        }
        public int SGIdFactura
        {
            get { return IdFactura; }
            set { IdFactura = value; }
        }
        public Double SGTipoCambio
        {
            get { return TipoDeCambio; }
            set { TipoDeCambio = value; }
        }
       
        public int Tamaño //tamaño del registro Persona
        {
            // Longitud en bytes de los atributos (un long = 8 bytes)
            get { return (SGTipoMov.Length*2+SGMoneda.Length*2+16+8 ); }
        }
    }
}