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
using System.IO;

namespace PSO_MutiObjective
{
    class DataInput
    {
        public static void ReadfromFile(out Portfolio port)
        {
            //Reading input data from a file
            char[] Dividers = { ',', ' ', '\t' };
            StreamReader InputSR;
            DataInput.OpenFile(out InputSR);
            ReadLocation(InputSR, Dividers, out port);
            InputSR.Close();
            //Ending for reading input data from a file
        }
        public static void OpenFile(out StreamReader InputSR)
        {
            FileStream InputFS = File.Open("Example.txt", FileMode.Open, FileAccess.Read);
            InputSR = new StreamReader(InputFS);
        }
        public static void ReadLocation(StreamReader InputSR, char[] Dividers, out Portfolio port)
        {
            string InputLine = InputSR.ReadLine();
            port = new Portfolio(Int32.Parse(InputLine));
            for (int i = 0; i < port.numAssets; i++)	//Read,Split,Convert to number
            {
                InputLine = InputSR.ReadLine();
                string[] sInputSplit = InputLine.Split(Dividers);
                port.A[i] = new Asset(Double.Parse(sInputSplit[1]), Double.Parse(sInputSplit[2]),0.01,1);
            }
            do
            {
                InputLine = InputSR.ReadLine();
                if (InputLine == "") break;
                string[] sInputSplit = InputLine.Split(Dividers);
                int i = Int32.Parse(sInputSplit[1])-1;
                int j = Int32.Parse(sInputSplit[2])-1;
                double cr = Double.Parse(sInputSplit[3]);
                port.CoV[i, j] = port.CoV[j, i] = cr * port.A[i].STDEV * port.A[j].STDEV;
            }
            while (!InputSR.EndOfStream) ;
        }
    }
}
