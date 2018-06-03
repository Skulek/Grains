using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grains
{
    public class Algorithms
    {

        public Grain[,] grains { get; set; }
        public Grain[,] temp { get; set; }
        public int ActualHeightOfLayers { get; set; }
        public NeighbourType type { get; set; }
        public BoundaryConditions bc { get; set; }
        public int ActualLayerNumber { get; set; }
        public delegate void GrowthStepCalback(bool growthStep);
        GrowthStepCalback growthStepCallback;

        public Algorithms()
        {

        }


        public Algorithms(Grain[,] grains, Grain[,] temp, int ActualHeightOFLayers, NeighbourType type, BoundaryConditions bc , int LayerNumber )
        {
            this.grains = grains;
            this.temp = temp;
            this.ActualHeightOfLayers = ActualHeightOFLayers;
            this.type = type;
            ActualLayerNumber = LayerNumber;
            this.bc = bc;
        
        }

    public void growthStep()
    {
        Parallel.For(0, ActualHeightOfLayers, i =>
        {

            for (int j = 0; j < temp.GetLength(1); j++)
            {

                if (temp[i, j].isEmpty)
                {
                    int counterWinner = 0;
                    List<Grain> neighbours = Neighborhood.GetNeighbours(temp[i, j], temp, i, j, type,bc, temp.GetLength(1), ActualHeightOfLayers);
                    Grain winner = temp[i, j];
                    foreach (Grain item in neighbours)
                    {
                        if (item.ID != 0 &&  item.numberOfLayer ==ActualLayerNumber)
                        {

                            int counter = 0;
                            foreach (Grain itemNext in neighbours)
                            {
                                if (item.ID == itemNext.ID)
                                {
                                    counter++;
                                }

                                if (counter > counterWinner)
                                {
                                    counterWinner = counter;
                                    winner = item;
                                }
                            }
                        }

                    }
                    if (!winner.isEmpty)
                    {
                        grains[i, j] = new Grain(winner);
                    }
                }
            }
        });
    }

        //public bool checkIfHighest(int j)
        //{
        //    for(int i = ActualHeightOfLayers-1; i<ActualHeightOfLayers;i++)
        //    {
        //        if (!temp[i, j].isEmpty)
        //            return false;
        //        else
        //            return true;
        //    }
        //    return true;
        //}
           
    }
}
