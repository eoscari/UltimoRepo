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
        public List<FacturaReal> ListaDetalle { get; set; }
        FacturaReal facturaReal;
        private StreamReader lectura;
        private StreamWriter sw, escritura, eliminados;
        string cadena;

        protected void Detalle(object sender, EventArgs e)
        {
            
           //if( lista.BuscarRegistro(Server.MapPath(@"~/Archivos/FacturaReal.txt"), idFactura.Text))
           // {
           //     SuccessMessage.Text = "Encontrado: "+ idFactura.Text;
           // }
           // else
           // {
           //     ErrorMessage.Text = "No encontrado: "+ idFactura.Text;
           // }

        }      

        protected void Editar(object sender, EventArgs e)
        {

        }

        //Creando el método bajas
        public void Eliminar(string idFactura)
        {
            bool encontrado = false;
            try
            {
                lista = new ManejoFacturaReal(Server.MapPath(@"~/Archivos/FacturaReal.txt"), Server.MapPath(@"~/Archivos/Eliminados.txt"));
                lectura = File.OpenText(Server.MapPath(@"~/Archivos/FacturaReal.txt"));
                eliminados = File.CreateText(Server.MapPath(@"~/Archivos/Eliminados.txt"));
                string cadena = lectura.ReadLine();
                while (cadena != null && encontrado == false)
                {
                    campos = cadena.Split(';');
                    if (!lista.BuscarRegistro(idFactura))
                    {
                        encontrado = true;
                        eliminados.WriteLine(cadena);
                        lblMessageError.Text = "";
                        lblMessageSuccess.Text = "Eliminado satisfactoriamente.";
                        PanelError.Visible = false;
                        InfoPanel.Visible = true;
                        //carga_lista();
                    }
                    //else
                    //{
                        
                    //}
                    cadena = lectura.ReadLine();
                }

                //if (encontrado == false)
                //{
                //    Console.WriteLine("*************************");
                //    Console.WriteLine("El usuario " + usuario + " no se encuentra en la BD");
                //    Console.WriteLine("*************************");
                //}
                //else if (respuesta.Equals("SI"))
                //{
                //    Console.WriteLine("**************************");
                //    Console.WriteLine("*** Artículo eliminado ***");
                //    Console.WriteLine("**************************");
                //}
                //else
                //{
                //    Console.WriteLine("******************************************");
                //    Console.WriteLine("*** Operación de eliminación cancelada ***");
                //    Console.WriteLine("******************************************");
                //}
                lectura.Close();
                eliminados.Close();
                File.Delete(Server.MapPath(@"~/Archivos/FacturaReal.txt"));
                File.Move(Server.MapPath(@"~/Archivos/Eliminados.txt"), Server.MapPath(@"~/Archivos/FacturaReal.txt"));

            }
            catch (FileNotFoundException fn)
            {
                Console.WriteLine("*************************");
                Console.WriteLine("Error!! " + fn.Message);
                Console.WriteLine("*************************");
            }
            catch (Exception e)
            {
                Console.WriteLine("*************************");
                Console.WriteLine("Error!! " + e.Message);
                Console.WriteLine("*************************");
            }
            finally
            {
                lectura.Close();
                //escritura.Close();
            }
        }

        string[] campos;

        protected void Page_Load(object sender, EventArgs e)
        {
            var _IdFactura = Request.QueryString["IdFactura"];
            if ((_IdFactura ?? "") != "")
            {
                Eliminar(_IdFactura);
            }

            carga_lista();
        }

        private void carga_lista()
        {
            try
            {
                

                ListaMostrar = new List<FacturaReal>();
                lista = new ManejoFacturaReal(Server.MapPath(@"~/Archivos/FacturaReal.txt"), Server.MapPath(@"~/Archivos/Eliminados.txt"));
                lectura = File.OpenText(Server.MapPath(@"~/Archivos/FacturaReal.txt"));
                cadena = lectura.ReadLine();
                while (cadena != null)
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
                if (lectura != null)
                    lectura.Close();
            }
        }
    }
}