using System;
using System.Collections.Generic;
using System.Text;
using ETLib_MODE_JSP;

namespace DE_MutiObjective
{
    public class PositionAdjust
    {
        public static void SortingListRuleOnPosition(int NoJob, int[] NoOp, int Dimension, ref double[] Position)
        {
            int[] DimensionArray = new int[Dimension];	//Create Dimension Array to be sorted.
            for (int i = 0; i < Dimension; i++)
            {
                DimensionArray[i] = i;
            }
            Array.Sort(Position, DimensionArray);	//Sort

            //Assign integer.
            int d = 0;
            for (int j = 0; j < NoJob; j++)
            {
                for (int i = 0; i < NoOp[j]; i++)
                {
                    Position[DimensionArray[d]] = (double)j;
                    d++;
                }
            }
        }//end of method SortingListRuleOnPosition
    }
}
