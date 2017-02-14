using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Trabajo_final_csharp.App_Start
{
    public class ListaFacturaEvent
    {
        private FileStream fs;          // flujo subyacente
        private BinaryWriter bw;        // flujo hacia el fichero
        private BinaryReader br;        // flujo desde el fichero
        private int nregs;              // número de registros
        private int tamañoReg = 110;    // tamaño del registro en bytes

        //CONSTRUCTOR
        public ListaFacturaEvent(String fichero)
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

        public void agregarRegistro(FacturaEventual obj)
        {
            if (EscribirRegistro(this.nregs, obj))
                this.nregs++;
        }

        public bool EscribirRegistro(int i, FacturaEventual fac)
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
                        bw.Write(fac.SGFechaEmision.ToString());
                        bw.Write(fac.SGFechaDeMov.ToString());//lo mando al dato datetime a string para poder guardarlo en el fichero
                        bw.Write(fac.SGIdMoveRec);
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

        public FacturaEventual LeerReg(int i)//lee registro mandandole la posicion
        {
            if (i >= 0 && i <= nregs)
            {
                br.BaseStream.Seek(i * tamañoReg, SeekOrigin.Begin);

                string fechaEmision = br.ReadString();
                string fechaMov = br.ReadString();
                int idMovRec = br.ReadInt32();
                string Dest = br.ReadString();
                string Orig = br.ReadString();

                return (new FacturaEventual(Convert.ToDateTime(fechaEmision), Convert.ToDateTime(fechaMov), idMovRec, Dest, Orig));
            }
            else { return null; }
        }

        //BUSCA POR ID DEl movimiento y devuelve la posicion en el fichero de la factura eventual
        public int BuscarReg(int IdMovimiento)
        {
            FacturaEventual obj;
            int ide;
            int reg_i = 0;
            bool encontrado = false;

            if (IdMovimiento < 0) { return -1; }
            else
            {
                while ((reg_i < nregs) && (!encontrado))
                {
                    obj = LeerReg(reg_i);
                    ide = obj.SGIdMoveRec;
                    if (ide == IdMovimiento)
                    {
                        encontrado = true;
                    }
                    else { reg_i++; }
                }

                if (encontrado)
                {
                    return reg_i;
                }
                else
                {
                    return -1;
                }
            }
        }
    } }