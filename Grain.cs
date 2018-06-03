using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grains
{
    public class Grain
    {
        public int ID { get; set; }
        public int numberOfLayer { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        

        public bool isEmpty
        {
            get { return this.ID == 0 ? true : false; }
        }

        public Grain()
        {
            X = -1;
            Y = -1;
            ID = 0;
            numberOfLayer = 0;
           
            
        }

        public Grain(int x , int y)
        {
            X = x;
            Y = y;
            ID = 0;
            numberOfLayer = 0;
           
        }
      

        public Grain(Grain previousGrain)
        {
            ID = previousGrain.ID;
            numberOfLayer = previousGrain.numberOfLayer;
            X = X;
            Y = Y;
         
           
        }

       
    }

    
}
