using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Trabajo_final_csharp.App_Start
{
    public class ListaMovRecurrente
    {

        private FileStream fs;          // flujo subyacente
        private BinaryWriter bw;        // flujo hacia el fichero
        private BinaryReader br;        // flujo desde el fichero
        private int nregs;              // número de registros
        private int tamañoReg = 115;    // tamaño del registro en bytes

        //CONSTRUCTOR
        public ListaMovRecurrente(String fichero)
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

        public void agregarRegistro(MovimientoRecurrente obj)
        {
            if (EscribirRegistro(this.nregs, obj))
                this.nregs++;
        }

        public bool EscribirRegistro(int i, MovimientoRecurrente fac)
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
                        bw.Write(fac.SGFechaIni.ToString());
                        bw.Write(fac.SGFrecuenciaFact);
                        bw.Write(fac.SGPlazoEje);
                        bw.Write(fac.SGIdRecurrente);
                       
                        return true;
                    }
                }
                else { return false; }
            }
            catch (IOException e) { CerrarFichero(); Console.WriteLine(e.Message); return false; }
        }

        public MovimientoRecurrente LeerReg(int i)//lee registro mandandole la posicion
        {
            if (i >= 0 && i <= nregs)
            {
                br.BaseStream.Seek(i * tamañoReg, SeekOrigin.Begin);

                string fechaInicio = br.ReadString();
                int frecFactu = br.ReadInt32();
                int plazo = br.ReadInt32();
                int IdRecu = br.ReadInt32();

                return (new MovimientoRecurrente(Convert.ToDateTime(fechaInicio),frecFactu,plazo,IdRecu));
            }
            else { return null; }
        }

        //BUSCA POR ID DEl movimiento devuelve la posicion en el fichero de la factura eventual
        public int BuscarReg(int IdMovimiento)
        {
            MovimientoRecurrente obj;
            int ide;
            int reg_i = 0;
            bool encontrado = false;

            if (IdMovimiento < 0) { return -1; }
            else
            {
                while ((reg_i < nregs) && (!encontrado))
                {
                    obj = LeerReg(reg_i);
                    ide = obj.SGIdRecurrente;
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
    }
}