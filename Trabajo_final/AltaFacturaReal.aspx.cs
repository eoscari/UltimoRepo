using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trabajo_final.App_Start;
using Trabajo_final_csharp.App_Start;

namespace Trabajo_final
{
    public partial class ABMFacturaReal : System.Web.UI.Page
    {
        private ManejoFacturaReal listaCuenta;

        protected void Page_Load(object sender, EventArgs e)
        {
            listaCuenta = new ManejoFacturaReal(Server.MapPath(@"~/Archivos/FacturaReal.bin"));
            FechaEmision.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            FechaEmision.Enabled = false;
            listaCuenta.CerrarFichero();
        }

        protected void Alta(object sender, EventArgs e)
        {
            try
            {
                listaCuenta.AbrirFichero(Server.MapPath(@"~/Archivos/FacturaReal.bin"));

                int numFactura = Convert.ToInt16(idFactura.Text);
                FechaEmision.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                DateTime EmisionFecha = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"));
                DateTime MovimientoFecha = Convert.ToDateTime(FechaMovimiento.Text);
                string tipo = Convert.ToString(Tipo.Text);
                double monto = Convert.ToDouble(Monto.Text);
                string moneda = Convert.ToString(Moneda.Text);
                string modo = Convert.ToString(ModoPago.Text);
                int idNota = Convert.ToInt16(Nota.Text);
                int idCheque = Convert.ToInt16(Cheque.Text);
                string destinatario = Convert.ToString(Destinatario.Text);
                string originante = Convert.ToString(Originante.Text);               

                FacturaReal obj = new FacturaReal(numFactura, EmisionFecha, MovimientoFecha, tipo, monto, moneda, modo, idNota, idCheque, destinatario, originante);
                if (listaCuenta.AgregarRegistro(obj))
                {
                    SuccessMessage.Text = "Se han Guardado los Datos Correctamente";
                }
                else
                {
                    ErrorMessage.Text = "Hubo un Error al Guardar, intentelo de nuevo";
                    SuccessMessage.Text = "";
                }
                //numeroReg = lista.NumReg();
                listaCuenta.CerrarFichero();


            }
            catch (System.IO.IOException er) { }


        }
    }
}