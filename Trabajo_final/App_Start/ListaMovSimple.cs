using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Trabajo_final_csharp.App_Start
{
    public class ListaMovSimple
    {
        private FileStream fs;          // flujo subyacente
        private BinaryWriter bw;        // flujo hacia el fichero
        private BinaryReader br;        // flujo desde el fichero
        private int nregs;              // número de registros
        private int tamañoReg = 100;    // tamaño del registro en bytes

        //CONSTRUCTOR
        public ListaMovSimple(String fichero)
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

        public void agregarRegistro(MovimientoSimple obj)
        {
            if (EscribirRegistro(this.nregs, obj))
                this.nregs++;
        }

        public bool EscribirRegistro(int i, MovimientoSimple fac)
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
                        bw.Write(fac.SGTipoMov);
                        bw.Write(fac.SGMoneda);
                        bw.Write(fac.SGMonto);
                        bw.Write(fac.SGIdFactura);
                        bw.Write(fac.SGTipoCambio);
                        
                        return true;
                    }
                }
                else { return false; }
            }
            catch (IOException e) { CerrarFichero(); Console.WriteLine(e.Message); return false; }
        }

        public MovimientoSimple LeerReg(int i)//lee registro mandandole la posicion
        {
            if (i >= 0 && i <= nregs)
            {
                br.BaseStream.Seek(i * tamañoReg, SeekOrigin.Begin);

                string TM = br.ReadString();
                string moneda = br.ReadString();
                Double monto = br.ReadDouble();
                int IF = br.ReadInt16();
                Double TC = br.ReadDouble();

                return (new MovimientoSimple(TM,moneda,monto,IF,TC));
            }
            else { return null; }
        }

        //BUSCA POR ID DE la factura y devuelve la posicion en el fichero 
        public int BuscarReg(int Idfac)
        {
            MovimientoSimple obj;
            int ide;
            int reg_i = 0;
            bool encontrado = false;

            if (Idfac < 0) { return -1; }
            else
            {
                while ((reg_i < nregs) && (!encontrado))
                {
                    obj = LeerReg(reg_i);
                    ide = obj.SGIdFactura;
                    if (ide == Idfac)
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
    }
}