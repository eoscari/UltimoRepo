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

        protected void Detalle(object sender, EventArgs e)
        {
            
           if( lista.BuscarRegistro(Server.MapPath(@"~/Archivos/FacturaReal.txt"), idFactura.Text))
            {
                SuccessMessage.Text = "Encontrado: "+ idFactura.Text;
            }
            else
            {
                ErrorMessage.Text = "No encontrado: "+ idFactura.Text;
            }

        }

        protected void Editar(object sender, EventArgs e)
        {

        }

        protected void Eliminar(object sender, EventArgs e)
        {

        }

        string[] campos;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ListaMostrar = new List<FacturaReal>();
                lista = new ManejoFacturaReal(Server.MapPath(@"~/Archivos/FacturaReal.txt"), Server.MapPath(@"~/Archivos/Eliminados.txt"));
                lectura = File.OpenText(Server.MapPath(@"~/Archivos/FacturaReal.txt"));
                cadena = lectura.ReadLine();
                while(cadena != null)
                {
                    campos = cadena.Split(';');
                    //for(int i=0; i < campos.Length; i++)
                    //{
                    int IdFactura = Convert.ToInt32(campos[0]);
                    DateTime fechaEmision = Convert.ToDateTime(campos[1]);
                    DateTime fechaMovimiento = Convert.ToDateTime(campos[2]);
                    string Tipo = campos[3];
                    double Monto = Convert.ToDouble(campos[4]);
                    string Moneda = campos[5];
                    string Modo = campos[6];
                    int IdNota = Convert.ToInt32(campos[7]);
                    int IdCheque = Convert.ToInt32(campos[8]);
                    string Destinatario = campos[9];
                    string Originante = campos[10];
                    ListaMostrar.Add(new FacturaReal
                    {
                        IdFactura = Convert.ToInt32(campos[0]),
                        fechaEmision = Convert.ToDateTime(campos[1]),
                        fechaMovimiento = Convert.ToDateTime(campos[2]),
                        Tipo = campos[3],
                        Monto = Convert.ToDouble(campos[4]),
                        Moneda = campos[5],
                        Modo = campos[6],
                        IdNota = Convert.ToInt32(campos[7]),
                        IdCheque = Convert.ToInt32(campos[8]),
                        Destinatario = campos[9],
                        Originante = campos[10]
                    });
                    cadena = lectura.ReadLine();
                }
            lectura.Close();
                //ListaMostrar.Add(new FacturaReal { IdFactura = idFactura, fechaEmision = facturaReal.fechaEmision, fechaMovimiento = facturaReal.fechaMovimiento, Tipo = facturaReal.Tipo, 
                //Monto = facturaReal.Monto, Moneda = facturaReal.Moneda, Modo = facturaReal.Modo, IdNota = facturaReal.IdNota, IdCheque = facturaReal.IdCheque, 
                //Destinatario = facturaReal.Destinatario, Originante = facturaReal.Originante });                    
                //}
            }catch(FileNotFoundException fn)
            {
                fn.Message.ToString();
                if (lectura != null)
                    lectura.Close();
            }
            catch (Exception ex) {
                ex.Message.ToString();
                if(lectura != null)
                    lectura.Close();
            }
            finally
            {
                lectura.Close();
            }
            //catch (IOException er) { lista.CerrarFichero(); ErrorMessage.Text = er.Message; }
            //catch (Exception ex) { lista.CerrarFichero(); ErrorMessage.Text = ex.Message; }
            //finally { lista.CerrarFichero(); }
            //finally { lista.CerrarFichero(); }catch(FileNotFoundException exc) { }		ex.Message	"El proceso no puede obtener acceso al archivo 'c:\\users\\oscar\\documents\\visual studio 2015\\Projects\\Trabajo_final\\Trabajo_final\\Archivos\\FacturaReal.bin' porque está siendo utilizado en otro proceso."	string

        }
    }
}