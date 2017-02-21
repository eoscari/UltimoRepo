using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trabajo_final.App_Start;
using Trabajo_final_csharp.App_Start;

namespace Trabajo_final
{
    public partial class GridFacturareal : System.Web.UI.Page
    {
        ManejoFacturaReal lista;
        public List<FacturaReal> ListaMostrar { get; set; }
        FacturaReal facturaReal;
        private StreamReader lectura;
        private StreamWriter sw, escritura, eliminados;
        string cadena;
        string[] campos;

        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
                ListaMostrar = new List<FacturaReal>();
                lista = new ManejoFacturaReal(Server.MapPath(@"~/Archivos/FacturaReal.bin"), Server.MapPath(@"~/Archivos/Eliminados.bin"));
                lectura = File.OpenText(Server.MapPath(@"~/Archivos/FacturaReal.bin"));
                cadena = lectura.ReadLine();
                while(cadena != null)
                {
                    campos = cadena.Split('-');
                    for(int i=0; i < campos.Length; i++)
                    {
                        //int idFactura = Convert.ToInt32(campos[0]);
                    }

                    //ListaMostrar.Add(new FacturaReal { IdFactura = idFactura, fechaEmision = facturaReal.fechaEmision, fechaMovimiento = facturaReal.fechaMovimiento, Tipo = facturaReal.Tipo, Monto = facturaReal.Monto, Moneda = facturaReal.Moneda, Modo = facturaReal.Modo, IdNota = facturaReal.IdNota, IdCheque = facturaReal.IdCheque, Destinatario = facturaReal.Destinatario, Originante = facturaReal.Originante });                    
                }
            //}
            //catch (IOException er) { lista.CerrarFichero(); ErrorMessage.Text = er.Message; }
            //catch (Exception ex) { lista.CerrarFichero(); ErrorMessage.Text = ex.Message; }
            //finally { lista.CerrarFichero(); }
            //finally { lista.CerrarFichero(); }
        }
    }
}