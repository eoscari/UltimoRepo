using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Trabajo_final_csharp.App_Start;

namespace Trabajo_final.App_Start
{
    public class ManejoFacturaReal
    {
        //ATRIBUTOS
        private FileStream fs;
        private StreamReader lectura;
        private StreamWriter sw, escritura, eliminados;
        FileInfo info;
        string path { get; set; }
        bool encontrado;
        private string cadena;
        string[] campos;

        //CONSTRUCTOR
        public ManejoFacturaReal(string fichero, string eliminado)
        {
            path = fichero;
            escritura = File.AppendText(fichero);
            eliminados = File.AppendText(eliminado);
            info = new FileInfo(fichero);
            eliminados.Close();
            escritura.Close();
        }
        public int cuenta_lineas(int cont, string fichero)
        {
            //lectura = File.OpenText(fichero);
            //cadena = lectura.ReadLine();
            //while (cadena != null)
            //{
            //    cont++;
            //    cadena = lectura.ReadLine();
            //}
            //lectura.Close();
            //return cont;

            int cantidad = File.ReadAllLines(fichero).Length;
            return cantidad;
        }

        public bool BuscarRegistro(string idFactura)
        {
            encontrado = false;
            try
            {
                if(path != null)
                {
                    lectura = File.OpenText(path);
                    cadena = lectura.ReadLine();
                    //Buscamos para ver si existe el id
                    while (cadena != null)
                    {
                        campos = cadena.Split(';');
                        if (campos[0].Trim().Equals(idFactura))
                        {
                            encontrado = true;
                            break;
                        }
                        cadena = lectura.ReadLine();
                    }
                    lectura.Close();
                }
                
                //escritura = File.AppendText("facturaReal.txt");
                //if (encontrado == true)
                //{

                //    Console.Write("Usuario: " + campos[1]);
                //    Console.Write("Estado: " + campos[2]);
                //    campos[2] = "NL";
                //    Console.Write("Nombre del Remitente :" + campos[3]);
                //    Console.Write("Nombre del destinatario: ");
                //    string destinatario = Console.ReadLine();
                //    Console.Write("Cuerpo del mensaje: ");
                //    string cuerpo = Console.ReadLine();
                //    //Escribiendo los datos en el archivo
                //    escritura.WriteLine(campos[0] + "- " + campos[1] + "- " + campos[2] + "- " + campos[3] + "- " + destinatario + "- " + cuerpo + "- " + campos[6]);
                //    Console.WriteLine("*******************************");
                //    Console.WriteLine("Cargado correctamente");
                //    Console.WriteLine("*******************************");
                //}
                //else
                //{
                //    Console.WriteLine("*************************************");
                //    Console.WriteLine("No existe el usuario " + usuario);
                //    Console.WriteLine("Desea Ingresa otro nombre de usuario? ");

                //}
                //escritura.Close();
                return encontrado;
            }
            catch (FileNotFoundException fn)
            {
                fn.Message.ToString();
                return false;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                return false;
            }
            finally
            {
                lectura.Close();
                escritura.Close();
            }
        }

        //Creando el método bajas
        public void Eliminar(string fichero, string eliminado, string idFactura)
        {
            encontrado = false;
            try
            {
                lectura = File.OpenText(fichero);
                eliminados = File.CreateText(eliminado);
                //Console.WriteLine("Ingrese su nombre de usuario: ");
                //usuario = Console.ReadLine();
                //usuario = usuario.ToUpper();
                string cadena = lectura.ReadLine();
                while (cadena != null)
                {
                    campos = cadena.Split('-');
                    if (campos[1].Trim().Equals(idFactura))
                    {
                        //encontrado = true;
                        //Console.WriteLine("******************************");
                        //Console.WriteLine("Dirección del Remitente : " + campos[2]);
                        //Console.WriteLine("Dirección del destinatario : " + campos[3]);
                        //Console.WriteLine("Cuerpo del mensaje : " + campos[4]);
                        //Console.WriteLine("******************************");
                        //Console.WriteLine("Realmente deseas eliminarlo (SI/NO)?...");
                        //respuesta = Console.ReadLine();
                        //respuesta = respuesta.ToUpper();

                        //if (!respuesta.Equals("SI"))
                        //{
                        //    eliminados.WriteLine(cadena);
                        //}
                    }
                    else
                    {
                        eliminados.WriteLine(cadena);
                    }
                    cadena = lectura.ReadLine();
                }

                if (encontrado == false)
                {
                    Console.WriteLine("*************************");
                    Console.WriteLine("El usuario no se encuentra en la BD");
                    Console.WriteLine("*************************");
                }
                //else if (respuesta.Equals("SI"))
                //{
                //    Console.WriteLine("**************************");
                //    Console.WriteLine("*** Artículo eliminado ***");
                //    Console.WriteLine("**************************");
                //}
                else
                {
                    Console.WriteLine("******************************************");
                    Console.WriteLine("*** Operación de eliminación cancelada ***");
                    Console.WriteLine("******************************************");
                }
                lectura.Close();
                eliminados.Close();

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
                escritura.Close();
            }
        }


        //Creando consultas de bandeja de entrada
        public bool EscribirRegistro(FacturaReal factura, int idcheque, int idnota,string fichero)
        {
            encontrado = false;
            try
            {
                lectura = File.OpenText(fichero);
                cadena = lectura.ReadLine();
                while (cadena != null)
                {
                    campos = cadena.Split(';');
                    if (Convert.ToInt32(campos[7]).Equals(idcheque) || Convert.ToInt32(campos[8]).Equals(idnota))
                    {
                        encontrado = true;
                        break;
                    }
                    cadena = lectura.ReadLine();
                }
                lectura.Close();
                escritura = File.AppendText(fichero);
                if (encontrado != true)
                {
                    string idFactura = Convert.ToString(factura.SGIdFactura);
                    string emisionFecha = Convert.ToString(factura.SGFechaEmi);
                    string movimientoFecha = Convert.ToString(factura.SGFechaMov);
                    string tipo = Convert.ToString(factura.SGTipo);
                    string monto = Convert.ToString(factura.SGMonto);
                    string moneda = Convert.ToString(factura.SGMoneda);
                    string modo = Convert.ToString(factura.SGModo);
                    string idNota = Convert.ToString(factura.SGIdNota);
                    string idCheque = Convert.ToString(factura.SGIdCheque);
                    string destinatario = Convert.ToString(factura.SGDestinatario);
                    string originante = Convert.ToString(factura.SGOriginante);
                    escritura.WriteLine(idFactura + ";" + emisionFecha + ";" + movimientoFecha + ";" + tipo + ";" + monto + ";" + moneda + ";" + modo + ";" + idNota + ";" + idCheque + ";" + destinatario + ";" + originante);
                    //numFactura, EmisionFecha, MovimientoFecha, tipo, monto, moneda, modo, idNota, idCheque, destinatario, originante
                }
                escritura.Close();
                return encontrado;
            }
            catch (FileNotFoundException fn)
            {
                fn.Message.ToString();
                return false;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                return false;
            }
            finally
            {
                //escritura.Close();
                lectura.Close();
            }
        }

        //Creando consultas de bandeja de eliminados
        //public void LeerEliminado()
        //{
        //    encontrado = false;
        //    try
        //    {
        //        lectura = File.OpenText("eliminados.txt");
        //        Console.Write("Ingrese su nombre de usuario: ");
        //        usuario = Console.ReadLine();
        //        usuario.ToUpper();
        //        cadena = lectura.ReadLine();
        //        while (cadena != null)
        //        {
        //            campos = cadena.Split('-');
        //            if (campos[1].Trim().Equals(usuario))
        //            {
        //                encontrado = true;
        //                Console.WriteLine("******************************");
        //                Console.WriteLine("*****Datos encontrados *****");
        //                Console.WriteLine();
        //                Console.WriteLine("Dirección del remitente : " + campos[3]);
        //                Console.WriteLine("Dirección del destinatario : " + campos[4]);
        //                Console.WriteLine("Cuerpo del mensaje : " + campos[5]);
        //                Console.WriteLine();
        //                Console.WriteLine("******************************");
        //            }
        //            cadena = lectura.ReadLine();
        //        }
        //        if (encontrado == false)
        //        {
        //            Console.WriteLine("******************************************");
        //            Console.WriteLine("*** No hay artículos con ese código " + usuario + " ***");
        //            Console.WriteLine("******************************************");
        //        }
        //        lectura.Close();
        //    }
        //    catch (FileNotFoundException fn)
        //    {
        //        Console.WriteLine("*************************");
        //        Console.WriteLine("Error!! " + fn.Message);
        //        Console.WriteLine("*************************");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("*************************");
        //        Console.WriteLine("Error!! " + e.Message);
        //        Console.WriteLine("*************************");
        //    }
        //    finally
        //    {
        //        lectura.Close();
        //    }
        //}

        //Creando el método consulta general
       public int return_ultima_posicion(int idfactura)
        {
            return Convert.ToInt32(info.Length);
        }

        public void consultamails()
        {
            encontrado = false;
            try
            {
                lectura = File.OpenText("mails.txt");
                cadena = lectura.ReadLine();
                while (cadena != null)
                {
                    encontrado = true;
                    campos = cadena.Split('-');
                    Console.WriteLine("******************************");
                    Console.WriteLine("*****Datos encontrados *****");
                    Console.WriteLine();
                    Console.WriteLine("Fecha : " + campos[0].Trim());
                    Console.WriteLine("Usuario : " + campos[1].Trim());
                    Console.WriteLine("Estado : " + campos[2].Trim());
                    Console.WriteLine("Dirección del remitente : " + campos[3].Trim());
                    Console.WriteLine("Dirección del destinatario : " + campos[4].Trim());
                    Console.WriteLine("Cuerpo del mensaje : " + campos[5].Trim());
                    Console.WriteLine();
                    Console.WriteLine("******************************");
                    cadena = lectura.ReadLine();
                }
                if (encontrado == false)
                {
                    Console.WriteLine("********************************");
                    Console.WriteLine("No artículos en la base de datos");
                    Console.WriteLine("********************************");
                }
                lectura.Close();
            }
            catch (FileNotFoundException fn)
            {
                fn.Message.ToString();
            }
            catch (Exception e)
            {
                e.Message.ToString();          
            }
            finally
            {
                lectura.Close();
            }
        }

        public String PasarLinea(FacturaReal facturaReal)
        {
            String l = "";
            l = l + facturaReal.SGIdFactura + "-" + facturaReal.SGFechaEmi + "-" + facturaReal.SGFechaEmi + "-" + facturaReal.SGTipo + "-";
            l = l + facturaReal.SGMonto + "-" + facturaReal.SGMoneda +"-" + facturaReal.SGModo + "-" + facturaReal;
            //int IdFactura, DateTime fechaEmision, DateTime fechaMovimiento, string Tipo, Double Monto, string Moneda, string Modo, int IdNota, int IdCheque, string Destinatario, string Originante
            return l;
        }
    }
}