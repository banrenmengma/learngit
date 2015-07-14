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
using System.IO;


namespace PSO_basic_visual_TSP
{
    class DataInput
    {
        public static void ReadfromFile(out Tour TSPtour)
        {
            //Reading input data from a file
            char[] Dividers = { ',', ' ','\t' };
            StreamReader InputSR;
            DataInput.OpenFile(out InputSR);
            ReadLocation(InputSR,Dividers,out TSPtour);
            InputSR.Close();
            //Ending for reading input data from a file
        }
        public static void OpenFile(out StreamReader InputSR)
        {
            FileStream InputFS = File.Open("Locations.txt", FileMode.Open, FileAccess.Read);
            InputSR = new StreamReader(InputFS);
        }
        public static void ReadLocation(StreamReader InputSR, char[] Dividers, out Tour tspTour)
        {
            string InputLine = InputSR.ReadLine();
            tspTour = new Tour(Int32.Parse(InputLine));
            for (int j = 0; j < tspTour.NumLocs; j++)	//Read,Split,Convert to number
            {
                InputLine = InputSR.ReadLine();
                string[] sInputSplit = InputLine.Split(Dividers);
                tspTour.loc[j] = new Location(Double.Parse(sInputSplit[0]), Double.Parse(sInputSplit[1]));
            }

        }

    }
}
