using System;
using System.IO;

namespace Entidades
{
    public static class Archivo
    {
        static string path;

        static Archivo ()
        {
            path = AppDomain.CurrentDomain.BaseDirectory;
            path += @"\Archivos";
        }

        public static void Escribir (string datos, string nombre)
        {
            string completa = path + @"\" + nombre + ".txt";

            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (StreamWriter sw = new StreamWriter(completa, true))
                {
                    sw.WriteLine(datos);
                }
            }
            catch (Exception)
            {
                throw new Exception($"Error en el archivo {completa}");
            }
        }
    }
}
