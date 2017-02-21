 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Trabajo_final_csharp.App_Start
{

    public class ManejaCuenta
    {
        private FileStream fs;
        private StreamReader lectura;
        private StreamWriter sw, escritura, eliminados;
        bool encontrado;
        private string cadena;
        private int idFactura;
        static string[] campos;

        public ManejaCuenta(string Nom, string elim)
        {
            AbrirFichero(Nom, elim);
        }
        public void AbrirFichero(string fichero, string eliminado)
        {
            escritura = File.AppendText(fichero);
            eliminados = File.AppendText(eliminado);
            eliminados.Close();
            escritura.Close();
        }

        public void CerrarFichero() { eliminados.Close(); escritura.Close(); }

        //public bool EscribirRegistro()
        //{
        //    try
        //    {
                
        //    }
        //    catch (IOException e) { CerrarFichero(); Console.WriteLine(e.Message); return false; }
        //}
        //public bool AgregarRegistro(Cuenta cuenta)
        //{
        //    if (EscribirRegistro(this.NR, cuenta))
        //    {
        //        this.NR++;
        //        return true;
        //    }

        //    return false;
        //}

        //public int NumReg()
        //{
        //    return this.NR;
        //}

        //public Cuenta LeerRegistro(int i)//lee registro mandandole la posicion en el fichero
        //{
        //    try
        //    {
        //        if (i >= 0 && i < NumReg())
        //        {
        //            br.BaseStream.Seek(i * this.TR, SeekOrigin.Begin);
        //            double fondoDol = br.ReadDouble();
        //            double fondoPe = br.ReadDouble();
        //            double DepositoBan = br.ReadDouble();

        //            double CheCob = br.ReadDouble();


        //            return (new Cuenta(fondoDol, fondoPe, DepositoBan, CheCob));
        //        }
        //        else { return null; }
        //    }
        //    catch (IOException e) { CerrarFichero(); return null; }
        //}

        //public bool ModificarReg(int pos)
        //{
        //    try
        //    {
        //        Cuenta nuevaCuenta = LeerRegistro(pos);
        //        EscribirRegistro(pos, nuevaCuenta); return true;
        //    }
        //    catch (IOException e) { CerrarFichero(); return false; }
        //}
    }
}