using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Trabajo_final_csharp.App_Start
{
    public class ListaFacturaReal
    {
     
            private FileStream fs;          // flujo subyacente
            private BinaryWriter bw;        // flujo hacia el fichero
            private BinaryReader br;        // flujo desde el fichero
            private int nregs;              // número de registros
            private int tamañoReg = 150;    // tamaño del registro en bytes

            //CONSTRUCTOR
            public ListaFacturaReal(String fichero)
            {
                abrirFichero(fichero);
            }

            public void abrirFichero(String path)
            {
                if (Directory.Exists(path))
                    throw new IOException(Path.GetFileName(path) + " no es un fichero");
                fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                bw = new BinaryWriter(fs);
                br = new BinaryReader(fs);
                this.nregs = (int)Math.Ceiling((double)fs.Length / (double)this.tamañoReg);
            }

            public void CerrarFichero() { bw.Close(); br.Close(); fs.Close(); }

        public int Registro
        {
            get { return this.nregs; }
        }

        public void agregarRegistro(FacturaReal obj)
        {
            if (EscribirRegistro(this.nregs, obj))
                this.nregs++;
        }
        public bool EscribirRegistro(int i, FacturaReal fac)
        {
            try
            {
                if (i >= 0 && i <= nregs)
                {
                    if (fac.Tamaño + 4 > tamañoReg)
                    {
                        Console.WriteLine("Tamaño de registro excedido.");
                        return false;
                    }
                    else
                    {
                        bw.BaseStream.Seek(i * this.tamañoReg, SeekOrigin.Begin);
                        bw.Write(fac.SGIdFactura);
                        bw.Write(fac.SGFechaEmi.ToString());//lo mando al dato datetime a string para poder guardarlo en el fichero
                        bw.Write(fac.SGFechaMov.ToString());
                        bw.Write(fac.SGTipo);
                        bw.Write(fac.SGMonto);
                        bw.Write(fac.SGMoneda);
                        bw.Write(fac.SGModo);
                        bw.Write(fac.SGIdNota);
                        bw.Write(fac.SGIdCheque);
                        bw.Write(fac.SGDestinatario);
                        bw.Write(fac.SGOriginante);
                        //estos son los id`s de cliente nota y cheques los gaurdo en el fichero
                        return true;
                    }
                }
                else { return false; }
            }
            catch (IOException e) { CerrarFichero(); Console.WriteLine(e.Message); return false; }
        }

        public FacturaReal LeerReg(int i)//levanta un registro mandandole la posicion
        {
            if (i >= 0 && i <= nregs)
            {
                br.BaseStream.Seek(i * tamañoReg, SeekOrigin.Begin);
                int IdFact = br.ReadInt32();
                string fechaEmision = br.ReadString();
                string fechaMov = br.ReadString();
                string tipo = br.ReadString();
                Double monto = br.ReadDouble();
                string moneda = br.ReadString();
                string modo = br.ReadString();
                int idnota = br.ReadInt32();
                int idcheque = br.ReadInt32();
                string Dest = br.ReadString();
                string Orig = br.ReadString();

                return (new FacturaReal(IdFact,Convert.ToDateTime(fechaEmision), Convert.ToDateTime(fechaMov), tipo,monto,moneda,modo,idnota,idcheque, Dest, Orig));
            }
            else { return null; }
        }
    }
}