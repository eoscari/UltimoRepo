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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ListaMostrar = new List<FacturaReal>();
                lista = new ManejoFacturaReal(Server.MapPath(@"~/Archivos/FacturaReal.bin"));
                for (int i = 0; i < lista.NumReg(); i++)
                {
                    facturaReal = lista.LeerRegistro(i);
                    int IdFactura = facturaReal.SGIdFactura;
                    DateTime fechaEmision = facturaReal.SGFechaEmi;
                    DateTime fechaMovimiento = facturaReal.SGFechaMov;
                    string Tipo = facturaReal.SGTipo;
                    double Monto = facturaReal.SGMonto;
                    string Modo = facturaReal.SGModo;
                    int IdNota = facturaReal.SGIdNota;
                    int IdCheque = facturaReal.SGIdCheque;
                    string Destinatario = facturaReal.SGDestinatario;
                    string Originante = facturaReal.SGOriginante;
                    ListaMostrar.Add(new FacturaReal { IdFactura = facturaReal.IdFactura, fechaEmision = facturaReal.fechaEmision, fechaMovimiento = facturaReal.fechaMovimiento, Tipo = facturaReal.Tipo, Monto = facturaReal.Monto, Moneda = facturaReal.Moneda, Modo = facturaReal.Modo, IdNota = facturaReal.IdNota, IdCheque = facturaReal.IdCheque, Destinatario = facturaReal.Destinatario, Originante = facturaReal.Originante });
                    //int IdFactura, DateTime fechaEmsion, DateTime fechaMovimiento, string Tipo, Double Monto, string Moneda, string Modo, int IdNota, int IdCheque, string Destinatario, string Originante                
                }
            }
            catch (IOException er) { lista.CerrarFichero(); ErrorMessage.Text = er.Message; }
            catch (Exception ex) { lista.CerrarFichero(); ErrorMessage.Text = ex.Message; }
            finally { lista.CerrarFichero(); }
            //finally { lista.CerrarFichero(); }
        }
    }
}