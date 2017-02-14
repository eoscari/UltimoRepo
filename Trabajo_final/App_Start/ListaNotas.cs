using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;


namespace Trabajo_final_csharp.App_Start
{
    public class ListaNotas
    {
        private FileStream fs, fst;
        private BinaryWriter bw, bwt;
        private BinaryReader br, brt;
        private int nregs;
        private int tamañoReg = 100;

        public ListaNotas(String fichero)
        {
            AbrirFichero(fichero);
        }

        public int Nregs
        {
            get { return nregs; }
        }
        public void AbrirFichero(String path)
        {
            if (Directory.Exists(path))
                throw new IOException(Path.GetFileName(path) + " no es un fichero");
            fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            bw = new BinaryWriter(fs);
            br = new BinaryReader(fs);
            nregs = (int)Math.Ceiling((double)fs.Length / (double)tamañoReg);
        }
        public bool AgregarRegistro(TipoNotas obj) //agrega un registro al ultimo
        {
            if (EscribirRegistro(nregs, obj))
            {
                nregs++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EscribirRegistro(int i, TipoNotas obj)
        {
            try
            {
                if (i >= 0 && i <= nregs)
                {
                    if (obj.Tamaño + 4 > tamañoReg)
                    {
                        Console.WriteLine("Tamaño de registro excedido.");
                        return false;
                    }
                    else
                    {
                        bw.BaseStream.Seek(i * tamañoReg, SeekOrigin.Begin);
                        bw.Write(obj.IdNota);
                        bw.Write(obj.Tipo);
                        bw.Write(Formato(obj.Fecha));
                        bw.Write(obj.Monto);
                        return true;
                    }
                }
                else { return false; }
            }
            catch (IOException e) { CerrarFichero(); Console.WriteLine(e.Message); return false; }
        }

        public void CerrarFichero()
        {
            bw.Close();
            br.Close();
            fs.Close();
        }
        public int NúmeroDeRegs() //devuelve número de registros
        {
            return nregs;
        }
        public string Formato(DateTime dia)
        {
            return dia.ToString("dd/MM/yyyy");
        }

        public TipoNotas LeerReg(int i)
        {
            if (i >= 0 && i <= nregs)
            {
                br.BaseStream.Seek(i * tamañoReg, SeekOrigin.Begin);
                int idnota = br.ReadInt32();
                int idFactura = br.ReadInt16();
                String tipo = br.ReadString();
                String fecha = br.ReadString();
                double monto = br.ReadDouble();

                return (new TipoNotas(idnota, idFactura, tipo, monto, Convert.ToDateTime(fecha)));
                //int id,int IF, String tip, double mon, DateTime fec
            }
            else
            {
                return null;
            }
        }
        //busca Nota por id y devuelve su posicion
        public int BuscarNota(int idnota)
        {
            TipoNotas obj;
            int num;
            int reg_i = 0;
            bool encontrado = false;

            if (idnota < 0)
            {
                return -1;
            }
            else
            {
                while ((reg_i < nregs) && (!encontrado))
                {
                    obj = LeerReg(reg_i);
                    num = obj.IdNota;
                    if (num == idnota)
                    { encontrado = true; }
                    else
                        reg_i++;
                }
                if (encontrado) { return reg_i; }
                else
                { return -1; }
            }
        }
        //elimina cheque pasando numero de id
        public void EliminarNota(int idnota, String fichero)
        {
            int regi = 0;
            int regist = 0;
            int pos = BuscarNota(idnota);
            fst = new FileStream("Tempo.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            bwt = new BinaryWriter(fst);
            brt = new BinaryReader(fst);
            while (regi < nregs)
            {
                if (regist != pos)
                {
                    TipoNotas nota1 = LeerReg(regist);
                    bwt.BaseStream.Seek(regi * tamañoReg, SeekOrigin.Begin);
                    bwt.Write(nota1.IdNota);
                    bwt.Write(nota1.Tipo);
                    bwt.Write(nota1.Fecha.ToString());
                    bwt.Write(nota1.Monto);
                    regist++;
                    regi++;
                }
                else
                {
                    regist++;
                    TipoNotas nota1 = LeerReg(regist);
                    bwt.BaseStream.Seek(regi * tamañoReg, SeekOrigin.Begin);
                    bwt.Write(nota1.IdNota);
                    bwt.Write(nota1.Tipo);
                    bwt.Write(nota1.Fecha.ToString());
                    bwt.Write(nota1.Monto);

                    regist++; regi++;
                }
            }
            nregs--;
            CerrarFichero();
            fst.Close();
            bwt.Close();
            brt.Close();
            File.Delete(fichero);
            File.Move("Tempo.bin", fichero);
            AbrirFichero(fichero);
        }
    }
}