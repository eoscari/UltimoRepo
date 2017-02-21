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
        string ficheroFactura;
        string ficheroEliminados;
        int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            ficheroFactura = Server.MapPath(@"~/Archivos/FacturaReal.txt");
            ficheroEliminados = Server.MapPath(@"~/Archivos/facturaRealEliminados.txt");
            listaCuenta = new ManejoFacturaReal(ficheroFactura, ficheroEliminados);
            FechaEmision.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            FechaEmision.Enabled = false;
        }

        protected void Alta(object sender, EventArgs e)
        {
            try
            {
                int numFactura = listaCuenta.return_ultima_posicion(id);
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
                if (!listaCuenta.EscribirRegistro(obj, numFactura, ficheroFactura))
                {
                    lblMessageSuccess.Text = "Se guardaron los Datos Correctamente";
                    lblMessageError.Text = "";
                    InfoPanel.Visible = true;
                }
                else
                {
                    lblMessageError.Text = "Hubo un Error al Guardar, intentelo de nuevo";
                    lblMessageSuccess.Text = "";
                }
                //numeroReg = lista.NumReg();


            }
            catch (System.IO.IOException er) { }


        }
    }
}