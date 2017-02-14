using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabajo_final_csharp.App_Start
{
    public class MovimientoRecurrente
    {
        private DateTime fechaIni;
        private int FrecFact;//frecuencia con que la factura se va a realizar
        private int PlazoEjecucion;
        private int IdRecurrente;

        //constructores
        public MovimientoRecurrente() { }

        public MovimientoRecurrente(DateTime FI, int FF, int PE, int IR)
        {
            this.fechaIni = FI;
            this.FrecFact = FF;
            this.PlazoEjecucion = PE;
            this.IdRecurrente = IR;
        }
        public DateTime SGFechaIni {
        set { this.fechaIni = value; }
        get { return fechaIni; } }

        public int SGFrecuenciaFact {
        set { this.FrecFact = value; }
        get { return FrecFact; } }

        public int SGPlazoEje
        {
            set { this.PlazoEjecucion = value; }
            get { return PlazoEjecucion; }
        }
        public int SGIdRecurrente
        {
            set { this.IdRecurrente = value; }
            get { return IdRecurrente; }
        }
        public string FormatoFecha(DateTime fe)
        {
            return fe.ToString("dd/MM/yyyy");
        }
        public int Tamaño //tamaño del registro Persona
        {
            // Longitud en bytes de los atributos (un long = 8 bytes)
            get { return (FormatoFecha(SGFechaIni).Length * 2 + 8+8 + 8); }
        }
    }
}