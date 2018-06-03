using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grains
{
    public static class RandomHelper
    {
        static  Random  rand = new Random();

        public static int Next()
        {
            int next = rand.Next();
            return next;
        }

        public static int Next(int val)
        {
            int next = rand.Next(val);
            return next;
        }

        public static int Next(int min, int max)
        {
            int next = rand.Next(min, max);
            return next;
        }

        public static double Next(double min, double max)
        {
            double next = rand.NextDouble() * (max - min) + min;
            return next;
        }
    }
}
