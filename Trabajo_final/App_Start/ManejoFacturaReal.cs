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
        private int TR = 180;
        private FileStream fs;
        private BinaryWriter bw;
        private BinaryReader br;
        private int nregs;

        public ManejoFacturaReal(string Nom)
        {
            AbrirFichero(Nom);
        }
        public void AbrirFichero(string fichero)
        {
            if (Directory.Exists(fichero))
                throw new IOException(Path.GetFileName(fichero) + " no es un fichero.");
            this.fs = new FileStream(fichero, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            this.bw = new BinaryWriter(fs);
            this.br = new BinaryReader(fs);
            this.nregs = (int)Math.Ceiling((double)fs.Length / (double)this.TR);
        }

        public void CerrarFichero()
        {
            if(fs != null && bw != null && br != null)
            {
                fs.Close(); bw.Close(); br.Close();
            }            
        }

        public bool EscribirRegistro(int i, FacturaReal facturaReal)
        {
            try
            {
                if (i >= 0 && i <= nregs)
                {
                    if (facturaReal.Tamaño + 4 > TR)
                    {
                        Console.WriteLine("Tamaño de registro excedido.");
                        return false;
                    }
                    else
                    {
                        bw.BaseStream.Seek(i * this.TR, SeekOrigin.Begin);
                        bw.Write(facturaReal.SGIdFactura);
                        bw.Write(facturaReal.SGIdCheque);
                        bw.Write(facturaReal.SGIdNota);
                        bw.Write(facturaReal.SGDestinatario);
                        bw.Write(facturaReal.SGModo);
                        bw.Write(facturaReal.SGMoneda);
                        bw.Write(facturaReal.SGMonto);
                        bw.Write(facturaReal.SGOriginante);
                        bw.Write(facturaReal.SGTipo);
                        bw.Write(Convert.ToString(facturaReal.SGFechaMov));
                        bw.Write(Convert.ToString(facturaReal.SGFechaEmi));
                        return true;
                    }
                }
                else { return false; }
            }
            catch (IOException e) {
                CerrarFichero();
                Console.WriteLine(e.Message);
                return false;
            }catch(Exception ex)
            {
                CerrarFichero();
                return false;
            }
        }
        public bool AgregarRegistro(FacturaReal factura)
        {
            if (EscribirRegistro(this.nregs, factura))
            {
                this.nregs++;
                return true;
            }

            return false;
        }

        public int NumReg()
        {
            return this.nregs;
        }

        public FacturaReal LeerRegistro(int i)//lee registro mandandole la posicion en el fichero
        {
            try
            {
                if (i >= 0 && i < NumReg())
                {
                    br.BaseStream.Seek(i * this.TR, SeekOrigin.Begin);
                    int idFactura = br.ReadInt32();
                    DateTime fechaEmision = Convert.ToDateTime(br.ReadString());
                    DateTime fechaMovimiento = Convert.ToDateTime(br.ReadString());
                    string Tipo = br.ReadString();
                    double Monto = br.ReadDouble();
                    string Moneda = br.ReadString();
                    string Modo = br.ReadString();
                    int idNota = br.ReadInt32();
                    int idCheque = br.ReadInt32();
                    string destinatario = br.ReadString();
                    string originante = br.ReadString();                

                    return (new FacturaReal(idFactura, Convert.ToDateTime(fechaEmision), Convert.ToDateTime(fechaMovimiento), Tipo, Monto, Moneda, Modo, idNota, idCheque, destinatario, originante));
                }
                else { return null; }
            }
            catch (IOException e) { CerrarFichero(); return null; }
        }

        public bool ModificarReg(int pos)
        {
            try
            {
                FacturaReal nuevaFactura = LeerRegistro(pos);
                EscribirRegistro(pos, nuevaFactura); return true;
            }
            catch (IOException e) { CerrarFichero(); return false; }
        }
    }
}