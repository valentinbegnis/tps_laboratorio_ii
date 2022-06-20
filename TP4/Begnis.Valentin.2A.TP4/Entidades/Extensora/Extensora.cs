using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Extensora
    {
        public static bool CantidadCaracteresValida(this string texto)
        {
            if (!string.IsNullOrEmpty(texto) && texto.Length <= 50)
            { 
                return true;
            }
            return false;
        }
    }
}
