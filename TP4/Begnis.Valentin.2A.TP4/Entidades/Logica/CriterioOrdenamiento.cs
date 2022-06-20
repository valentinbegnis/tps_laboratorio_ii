using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class CriterioOrdenamiento
    {
        public static int OrdenarMenorAMayor(float n1, float n2)
        {
            if (n1 == 0 || n2 == 0)
            {
                return 0;
            }

            return n1.CompareTo(n2);
        }
    }
}
