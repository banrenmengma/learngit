////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//ET-Lib Object Library for Evolutionary Techniques                                                               //
//Copyright (C) 2010 Kachitvichyanukul, V., T. J. Ai, and S. Nguyen                                               //  
//This program is free software; you can redistribute it and/or modify it under the terms of the GNU General      //
//Public License as published by the Free Software Foundation; either version 2 of the License, or (at your       //
//option) any later version.                                                                                      //
//This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the      // 
//implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License    //
//for more details.                                                                                               //  
//For a copy of the GNU General Public License write to                                                           //  
//Free Software Foundation, Inc.,                                                                                 //  
//51 Franklin Street, Fifth Floor,                                                                                //
//Boston, MA 02110-1301 USA.                                                                                      //
//                                                                                                                //
//For further information on ET-Lib please contact via electronic mail                                            //
//Voratas Kachitvichyanukul (voratas@ait.ac.th)                                                                   //
//Industrial and Manufacturing Engineering                                                                        //  
//Asian Institute of Technology                                                                                   //
//THAILAND, 12120                                                                                                 //
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Text;

namespace PSO_JSP
{
    public class PositionAdjust
    {
        public static void SortingListRuleOnPosition(int NoJob, int[] NoOp, int Dimension, ref double[] Position, ref int[] DimensionArray)
        {           
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
