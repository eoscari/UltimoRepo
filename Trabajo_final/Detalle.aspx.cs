using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trabajo_final.App_Start;

namespace Trabajo_final
{
    public partial class Detalle : System.Web.UI.Page
    {
        ManejoFacturaReal lista;
        private StreamReader lectura;
        private StreamWriter sw, escritura, eliminados;
        string cadena;
        string[] datos;

        protected void Page_Load(object sender, EventArgs e)
        {
            var _IdFactura = Request.QueryString["IdFactura"];
            if ((_IdFactura ?? "") != "")
            {
                DetalleNew(_IdFactura);
            }
        }

        protected void DetalleNew(string id_factura)
        {
            lista = new ManejoFacturaReal(Server.MapPath(@"~/Archivos/FacturaReal.txt"), id_factura.ToString());
            if (lista.BuscarRegistro(id_factura.ToString()))
            {
                //SuccessMessage.Text = "Encontrado: " + _IdFactura.ToString();
                try
                {
                    lectura = File.OpenText(Server.MapPath(@"~/Archivos/FacturaReal.txt"));
                    cadena = lectura.ReadLine();
                    //Response.Redirect("Detalle.aspx?Cadena=" + cadena);
                    datos = cadena.Split(';');
                    Labe1.Text = Convert.ToString(datos[1]);
                    Labe2.Text = Convert.ToString(datos[2]);
                    Labe3.Text = Convert.ToString(datos[3]);
                    Labe4.Text = Convert.ToString(datos[4]);
                    Labe5.Text = Convert.ToString(datos[5]);
                    Labe6.Text = Convert.ToString(datos[6]);
                    Labe7.Text = Convert.ToString(datos[7]);
                    Labe8.Text = Convert.ToString(datos[8]);
                    Labe9.Text = Convert.ToString(datos[9]);
                    Labe10.Text = Convert.ToString(datos[10]);
                    lectura.Close();
                }
                catch (FileNotFoundException fn)
                {
                    fn.Message.ToString();
                    if (lectura != null)
                        lectura.Close();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    if (lectura != null)
                        lectura.Close();
                }
                finally
                {
                    lectura.Close();
                }
            }else
            {
                lblMessageError.Text = "No se encontraron datos para el registro.";
                lblMessageSuccess.Text = "";
                PanelError.Visible = true;
                InfoPanel.Visible = false;
            }
        }
    }
}