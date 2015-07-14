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
using ETLib_AniPSO;

namespace PSO_basic_visual
{
    
    class Function
    {
        public static double Test_Function(int function,Particle P) 
        {
            double x = 0;
            if (function == 0) x = 0.001 * Math.Pow(P.Position[0], 2) + 2 * Math.Sin(P.Position[0]);
            if (function == 1) x = Math.Pow(P.Position[0], 2);
            if (function == 2) x = 0.5 * Math.Pow(P.Position[0], 4) - 2 * P.Position[0];
            return x;
        }
        public static double Test_FunctionBestpos(int function, Particle P)
        {
            double x = 0;
            if (function == 0) x = 0.001 * Math.Pow(P.BestP[0], 2) + 2 * Math.Sin(P.BestP[0]);
            if (function == 1) x = Math.Pow(P.BestP[0], 2);
            if (function == 2) x = 0.5 * Math.Pow(P.BestP[0], 4) - 2 * P.BestP[0];
            return x;
        }
        public static double Test_Function(int function, double P)
        {
            double x = 0;
            if (function == 0) x = 0.001 * Math.Pow(P, 2) + 2 * Math.Sin(P);
            if (function == 1) x = Math.Pow(P, 2);
            if (function == 2) x = 0.5*Math.Pow(P, 4) - 2 * P;
            return x;
        }
        public static string Get_Function_Text(int function)
        {
            string f="";
            if (function == 0) f = "0.001 * x^2 + 2 * Sin(x)";
            if (function == 1) f = "x^2";
            if (function == 2) f = "0.5*x^4-2x";
            return f;
        }
        public static int numF()
        {
            return 3;
        }
    }
}
