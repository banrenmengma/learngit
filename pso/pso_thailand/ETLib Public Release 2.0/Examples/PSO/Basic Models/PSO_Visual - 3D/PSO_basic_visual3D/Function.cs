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
            for (int i = 0; i < P.Dimension;i++ )
            {
                if (function == 0) x += 0.001 * Math.Pow(P.Position[i], 2) + 2 * Math.Sin(P.Position[i]);
                if (function == 1) x += Math.Pow(P.Position[i], 2);
                if (function == 2) x += 0.5 * Math.Pow(P.Position[i], 4) - 2 * P.Position[i];
            }
            if (function == 3) x += 3 * Math.Pow((1 - P.Position[0]), 2) * Math.Exp(-P.Position[0] * P.Position[0] -
                                    (P.Position[1] + 1) * (P.Position[1] + 1)) - 10 * (0.2 * P.Position[0] - Math.Pow(P.Position[0], 3) -
                                    Math.Pow(P.Position[1], 5)) * Math.Exp(-P.Position[0] * P.Position[0] - P.Position[1] * P.Position[1]) -
                                    1 / 3 * Math.Exp(-(P.Position[0] + 1) * (P.Position[0] + 1) - P.Position[1] * P.Position[1]);
            if (function == 4)
            { 
                int nPeak=2;
                double[] a = { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };
                double[] b = { 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1 ,0.1};
                double[] xp = { -20,0,20,10,30,50,15,-30,-10,40};
                double[] yp = { -20,0,-20,15,10,-25,-50,30,30,60};
                for (int i = 0; i < nPeak; i++)
                {
                    x -= b[i] / (1 + (Math.Pow(P.Position[0] - xp[i], 2) + Math.Pow(P.Position[1] - yp[i], 2))/a[i]);
                }
            }
            return x;
        }
        public static double Test_FunctionBestpos(int function, Particle P)
        {
            double x = 0;
            for (int i = 0; i < P.Dimension; i++)
            {
                if (function == 0) x += 0.001 * Math.Pow(P.BestP[i], 2) + 2 * Math.Sin(P.BestP[i]);
                if (function == 1) x += Math.Pow(P.BestP[i], 2);
                if (function == 2) x += 0.5 * Math.Pow(P.BestP[i], 4) - 2 * P.BestP[i];
            }
            if (function == 3) x += 3 * Math.Pow((1 - P.BestP[0]), 2) * Math.Exp(-P.BestP[0] * P.BestP[0] -
                                        (P.BestP[1] + 1) * (P.BestP[1] + 1)) - 10 * (0.2 * P.BestP[0] - Math.Pow(P.BestP[0], 3) -
                                        Math.Pow(P.BestP[1], 5)) * Math.Exp(-P.BestP[0] * P.BestP[0] - P.BestP[1] * P.BestP[1]) -
                                        1 / 3 * Math.Exp(-(P.BestP[0] + 1) * (P.BestP[0] + 1) - P.BestP[1] * P.BestP[1]);
            if (function == 4)
            {
                int nPeak = 2;
                double[] a = { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };
                double[] b = { 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1 };
                double[] xp = { -20, 0, 20, 10, 30, 50, 15, -30, -10, 40 };
                double[] yp = { -20, 0, -20, 15, 10, -25, -50, 30, 30, 60 };
                for (int i = 0; i < nPeak; i++)
                {
                    x -= b[i] / (1 + (Math.Pow(P.BestP[0] - xp[i], 2) + Math.Pow(P.BestP[1] - yp[i], 2)) / a[i]);
                }
            } 
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
        public static double Test_Function(int function, double[] P)
        {
            double x = 0;
            for (int i = 0; i < P.Length; i++)
            {
                if (function == 0) x += 0.001 * Math.Pow(P[i], 2) + 2 * Math.Sin(P[i]);
                if (function == 1) x += Math.Pow(P[i], 2);
                if (function == 2) x += 0.5 * Math.Pow(P[i], 4) - 2 * P[i];
            }
            if (function == 3) x += 3 * Math.Pow((1 - P[0]), 2) * Math.Exp(-P[0] * P[0] -
                                    (P[1] + 1) * (P[1] + 1)) - 10 * (0.2 * P[0] - Math.Pow(P[0], 3) -
                                     Math.Pow(P[1], 5)) * Math.Exp(-P[0] * P[0] - P[1] * P[1]) -
                                     1 / 3 * Math.Exp(-(P[0] + 1) * (P[0] + 1) - P[1] * P[1]);
            if (function == 4)
            {
                int nPeak = 2;
                double[] a = { 3,3, 3, 3, 3, 3, 3, 3, 3, 3 };
                double[] b = { 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1 };
                double[] xp = { -20, 0, 20, 10, 30, 50, 15, -30, -10, 40 };
                double[] yp = { -20, 0, -20, 15, 10, -25, -50, 30, 30, 60 };
                for (int i = 0; i < nPeak; i++)
                {
                    x -= b[i] / (1 + (Math.Pow(P[0] - xp[i], 2) + Math.Pow(P[1] - yp[i], 2)) / a[i]);
                }
            } 
            return x;
        }
        public static string Get_Function_Text(int function)
        {
            string f="";
            if (function == 0) f = "0.001 * x^2 + 2 * Sin(x)";
            if (function == 1) f = "x^2";
            if (function == 2) f = "0.5*x^4-2x";
            if (function == 3) f = "muti_model";
            if (function == 4) f = "six_hump";
            return f;
        }
        public static int numF()
        {
            return 5;
        }
        public static double lowerP(int function)
        {
            double l=0;
            if (function == 0) l = -10;
            if (function == 1) l = -100;
            if (function == 2) l = -100;
            if (function == 3) l = -2;
            if (function == 4) l = -60;
            return l;
        }
        public static double upperP(int function)
        {
            double l = 0;
            if (function == 0) l = 10;
            if (function == 1) l = 100;
            if (function == 2) l = 100;
            if (function == 3) l = 2;
            if (function == 4) l = 60;
            return l;
        }
    }
}
