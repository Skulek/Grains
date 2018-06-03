using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grains
{
    public static class Neighborhood
    { 

        public static List<Grain> GetNeighbours(Grain coord, Grain[,] grains, int i , int j, NeighbourType neighbourType, BoundaryConditions bc , int width, int height)
        {

            List<Grain> GrainNeighbour = new List<Grain>();
            int iprev = 0;
            int inext = 0;
            int jprev = 0;
            int jnext = 0;

            switch (bc)
            {
                case BoundaryConditions.Absorbing:
                    nonPeriodic(ref iprev, ref jprev, ref inext, ref jnext, i, j, width, height);
                    break;
                case BoundaryConditions.Periodic:
                    CheckIfEdge(ref iprev, ref jprev, ref inext, ref jnext, i, j, width, height);
                    break;
                default:
                    break;
            }
         

            if(neighbourType == NeighbourType.HeksagonalneLosowe)
            {
                ThreadSafeRandom tsr = new ThreadSafeRandom();
               int pom = tsr.Next();
                if( pom >50)
                {
                    neighbourType = NeighbourType.HeksagonalneLewe;
                }
                else
                {
                    neighbourType = NeighbourType.HeksagonalnePrawe;
                }
            }

            else if (neighbourType ==  NeighbourType.PentagonalneLosowe)
            {
                ThreadSafeRandom tsr = new ThreadSafeRandom();
                int pom = tsr.Next();
                if (pom > 50)
                {
                    neighbourType = NeighbourType.PentagonalnePrawe;
                }
                else
                {
                    neighbourType = NeighbourType.PentagonalneLewe;
                }
            }
            

            switch (neighbourType)
            {



                #region Moore
                case NeighbourType.Moore:

                    if (grains[iprev, jprev].isEmpty == false ) { GrainNeighbour.Add(grains[iprev, jprev]); }
                    if (grains[iprev, j].isEmpty == false) { GrainNeighbour.Add(grains[iprev, j]); }
                    if (grains[iprev, jnext].isEmpty == false) { GrainNeighbour.Add(grains[iprev, jnext]); }
                    if (grains[i, jprev].isEmpty == false) { GrainNeighbour.Add(grains[i, jprev]); }
                    if (grains[i, jnext].isEmpty == false) { GrainNeighbour.Add(grains[i, jnext]); }
                    if (grains[inext, jprev].isEmpty == false) { GrainNeighbour.Add(grains[inext, jprev]); }
                    if (grains[inext, j].isEmpty == false) { GrainNeighbour.Add(grains[inext, j]); }
                    if (grains[inext, jnext].isEmpty == false) { GrainNeighbour.Add(grains[inext, jnext]); }
                    break;

                #endregion

                #region MyRegion
                case NeighbourType.VonNeumann:
                    if (grains[iprev, j].isEmpty == false) { GrainNeighbour.Add(grains[iprev, j]); }
                    if (grains[i, jprev].isEmpty == false) { GrainNeighbour.Add(grains[i, jprev]); }
                    if (grains[i, jnext].isEmpty == false) { GrainNeighbour.Add(grains[i, jnext]); }
                    if (grains[inext, j].isEmpty == false) { GrainNeighbour.Add(grains[inext, j]); }
                    break;

                #endregion
                case NeighbourType.HeksagonalneLewe:
                    if (grains[iprev, jprev].isEmpty == false) { GrainNeighbour.Add(grains[iprev, jprev]); }
                    if (grains[iprev, j].isEmpty == false) { GrainNeighbour.Add(grains[iprev, j]); }
                    if (grains[i, jprev].isEmpty == false) { GrainNeighbour.Add(grains[i, jprev]); }
                    if (grains[i, jnext].isEmpty == false) { GrainNeighbour.Add(grains[i, jnext]); }
                    if (grains[inext, j].isEmpty == false) { GrainNeighbour.Add(grains[inext, j]); }
                    if (grains[inext, jnext].isEmpty == false) { GrainNeighbour.Add(grains[inext, jnext]); }
                    break;
                case NeighbourType.HeksagonalnePrawe:


                   
                    if (grains[iprev, j].isEmpty == false) { GrainNeighbour.Add(grains[iprev, j]); }
                    if (grains[iprev, jnext].isEmpty == false) { GrainNeighbour.Add(grains[iprev, jnext]); }
                    if (grains[i, jprev].isEmpty == false) { GrainNeighbour.Add(grains[i, jprev]);  }
                    if (grains[i, jnext].isEmpty == false) { GrainNeighbour.Add(grains[i, jnext]); }
                    if (grains[inext, jprev].isEmpty == false) { GrainNeighbour.Add(grains[inext, jprev]);  }
                    if (grains[inext, j].isEmpty == false) { GrainNeighbour.Add(grains[inext, j]);  }

                    break;
                case NeighbourType.PentagonalneLewe:
                    if (grains[inext, jnext].isEmpty == false) { GrainNeighbour.Add(grains[inext, jnext]); }
                    if (grains[iprev, jnext].isEmpty == false) { GrainNeighbour.Add(grains[iprev, jnext]); }
                    if (grains[i, jnext].isEmpty == false) { GrainNeighbour.Add(grains[i, jnext]); }
                    if (grains[iprev, j].isEmpty == false) { GrainNeighbour.Add(grains[iprev, j]); }
                    if (grains[inext, j].isEmpty == false) { GrainNeighbour.Add(grains[i, jprev]); }

              
                    break;

                case NeighbourType.PentagonalnePrawe:
                    if (grains[inext, jprev].isEmpty == false) { GrainNeighbour.Add(grains[inext, jprev]); }
                    if (grains[iprev, jprev].isEmpty == false) { GrainNeighbour.Add(grains[iprev, jprev]); }
                    if (grains[i, jprev].isEmpty == false) { GrainNeighbour.Add(grains[i, jprev]); }
                    if (grains[iprev, j].isEmpty == false) { GrainNeighbour.Add(grains[iprev, j]); }
                    if (grains[inext, j].isEmpty == false) { GrainNeighbour.Add(grains[i, jprev]); }
      
                    break;
                //     break;
                default:
                    break;
            }
            return GrainNeighbour;
        }

        private static void nonPeriodic(ref int iprev, ref int jprev, ref int inext, ref int jnext , int i , int j , int width , int height)
        {
            if (i - 1 < 0)
                iprev = i;
            else
                iprev = i - 1;

            if ((i + 1) > (height - 1))
                inext = i;
            else
                inext = i + 1;

            if (j - 1 < 0)
                jprev = j;
            else
                jprev = j - 1;

            if (j + 1 > width - 1)
                jnext = j;
            else
                jnext = j + 1;
        }




        private static void CheckIfEdge(ref int iprev, ref int jprev, ref int inext, ref int jnext, int i ,int j , int width , int height)
        {
            
            if (i - 1 < 0)
                iprev = i;
            else
                iprev = i - 1;

            if ((i + 1) > (height - 1))
                inext = i;
            else
                inext = i + 1;

            if (j - 1 < 0)
                jprev = width - 1;
            else
                jprev = j - 1;

            if (j + 1 > width - 1)
                jnext = 0;
            else
                jnext = j + 1;
        }

        public static bool haveNeighborhood (Grain [,]grains , int i , int j )
        {
            List<Grain> GrainNeighbour = new List<Grain>();
            int iprev = 0;
            int inext = 0;
            int jprev = 0;
            int jnext = 0;

            nonPeriodic(ref iprev, ref jprev, ref inext, ref jnext, i, j, grains.GetLength(1), grains.GetLength(0));




            
            if (grains[iprev, j].ID > 0) { return true; }
            else { return false; }
          
            
        }

    }
    
}
