using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trabajo_final_csharp.App_Start;

namespace Trabajo_final
{
    public partial class ABMCuenta : System.Web.UI.Page
    {
        private ManejaCuenta listaCuenta;
        private int numeroReg;

        protected void Page_Load(object sender, EventArgs e)
        {
            listaCuenta = new ManejaCuenta(Server.MapPath(@"~/Archivos/Cuentas.txt"), Server.MapPath(@"~/Archivos/eliminaCuenta.txt"));
            listaCuenta.CerrarFichero();
        }

        //protected void Alta(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        listaCuenta.AbrirFichero(Server.MapPath(@"~/Archivos/Cuentas.bin"));

        //        double fondoDolares = Convert.ToDouble(FondoDolar.Text);
        //        double fondoPesos = Convert.ToDouble(FondoPeso.Text);
        //        double depBancario = Convert.ToDouble(Cuenta.Text);

        //        double chequesCobrados = Convert.ToDouble(ChequesCo.Text);

        //        Cuenta obj = new Cuenta(fondoDolares, fondoPesos, depBancario, chequesCobrados);
        //        if (listaCuenta.AgregarRegistro(obj))
        //        {
        //            SuccessMessage.Text = "Se han Guardado los Datos Correctamente";
        //            ErrorMassage.Text = "";
        //            ErrorMassage.Text = "";
        //            FondoDolar.Text = "";
        //            FondoPeso.Text = "";
        //            Cuenta.Text = "";

        //            ChequesCo.Text = "";
        //        }
        //        else
        //        {
        //            ErrorMassage.Text = "Hubo un Error al Guardar, intentelo de nuevo";
        //            SuccessMessage.Text = "";
        //        }
        //        //numeroReg = lista.NumReg();
        //        listaCuenta.CerrarFichero();


        //    }
        //    catch (System.IO.IOException er) { }


        //}
    }
}