 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Trabajo_final_csharp.App_Start
{

    public class ManejaCuenta
    {
        private int TR = 100;
        private int NR;
        private FileStream fs;
        private BinaryWriter bw;
        private BinaryReader br;
        private int nregs;

        public ManejaCuenta(string Nom)
        {
            AbrirFichero(Nom);
        }
        public void AbrirFichero(string fichero)
        {
            if (Directory.Exists(fichero))
                throw new IOException(Path.GetFileName(fichero) + " no es un fichero");
            fs = new FileStream(fichero, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            bw = new BinaryWriter(fs);
            br = new BinaryReader(fs);
            nregs = (int)Math.Ceiling((double)fs.Length / (double)TR);
        }

        public void CerrarFichero() { fs.Close(); bw.Close(); br.Close(); }

        public bool EscribirRegistro(int i, Cuenta cuent)
        {
            try
            {
                if (i >= 0 && i <= NR)
                {
                    if (cuent.TamCuenta + 4 > TR)
                    {
                        Console.WriteLine("Tamaño de registro excedido.");
                        return false;
                    }
                    else
                    {
                        bw.BaseStream.Seek(i * this.TR, SeekOrigin.Begin);
                        bw.Write(cuent.SGFondosDolares);
                        bw.Write(cuent.SGFondoPesos);
                        bw.Write(cuent.SGDepBanc);
                        bw.Write(cuent.SGCheqCobrados);
                        return true;
                    }
                }
                else { return false; }
            }
            catch (IOException e) { CerrarFichero(); Console.WriteLine(e.Message); return false; }
        }
        public bool AgregarRegistro(Cuenta cuenta)
        {
            if (EscribirRegistro(this.NR, cuenta))
            {
                this.NR++;
                return true;
            }

            return false;
        }

        public int NumReg()
        {
            return this.NR;
        }

        public Cuenta LeerRegistro(int i)//lee registro mandandole la posicion en el fichero
        {
            try
            {
                if (i >= 0 && i < NumReg())
                {
                    br.BaseStream.Seek(i * this.TR, SeekOrigin.Begin);
                    double fondoDol = br.ReadDouble();
                    double fondoPe = br.ReadDouble();
                    double DepositoBan = br.ReadDouble();

                    double CheCob = br.ReadDouble();


                    return (new Cuenta(fondoDol, fondoPe, DepositoBan, CheCob));
                }
                else { return null; }
            }
            catch (IOException e) { CerrarFichero(); return null; }
        }

        public bool ModificarReg(int pos)
        {
            try
            {
                Cuenta nuevaCuenta = LeerRegistro(pos);
                EscribirRegistro(pos, nuevaCuenta); return true;
            }
            catch (IOException e) { CerrarFichero(); return false; }
        }
    }
}