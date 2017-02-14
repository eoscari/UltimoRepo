using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trabajo_final_csharp.App_Start
{
    public class Cuenta

    {
        private double FondoDolares;
        private double FondoPesos;
        private double DepBancario;//cantidad de dinero en la cuenta bancaria
                                   //de aqui saque el numero de la cuenta bancaria porque no es necesario no voy a hacer transacciones banacarias solo me interesa el monto 
        private double ChequesCobrados;
        // private DateTime Fecha;


        public Cuenta() { }

        public Cuenta(double FD, double FP, double DB, double CC)
        {
            this.FondoDolares = FD;
            this.FondoPesos = FP;
            this.DepBancario = DB;
            this.ChequesCobrados = CC;
            //this.Fecha = fe;
        }


        public double SGFondosDolares
        {
            get { return FondoDolares; }
            set { FondoDolares = value; }
        }

        public double SGFondoPesos
        {
            get { return FondoPesos; }
            set { FondoPesos = value; }
        }
        public double SGDepBanc
        {
            get { return DepBancario; }
            set { DepBancario = value; }
        }
        public double SGCheqCobrados
        {
            get { return ChequesCobrados; }
            set { ChequesCobrados = value; }
        }

        public int TamCuenta
        {
            get { return ((5 * 16) + 16); }
        }
    }
}