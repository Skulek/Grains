using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grains
{
    static class MathHelper
    {

        public static double Check(int gri, int grj, int pomi, int pomj)
        {
            double i = Math.Pow(gri - pomi, 2);
            double j = Math.Pow(grj - pomj, 2);
            double odl = Math.Sqrt(i + j);
            return odl;
        }
    }
}
