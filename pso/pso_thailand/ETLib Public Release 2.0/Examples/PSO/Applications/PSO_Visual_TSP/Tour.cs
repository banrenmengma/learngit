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

namespace PSO_basic_visual_TSP
{
    class Tour
    {
        public  Location[] loc;
        public int NumLocs;
        public double[,] DistanceMatrix;
        public Tour()
        { 
        
        }
        public Tour(int number_locations)
        {
            loc = new Location[number_locations];
            NumLocs=number_locations;
            DistanceMatrix = new double[number_locations, number_locations];
        }
        public void Calculate_Matrix_Distance()
        {
            for (int i = 0; i < NumLocs - 1; i++)
            {
                for (int j = i+1; j < NumLocs; j++)
                {
                    DistanceMatrix[i, j] = Math.Sqrt(Math.Pow(this.loc[i].X - this.loc[j].X, 2) + Math.Pow(this.loc[i].Y - this.loc[j].Y, 2));
                    DistanceMatrix[j, i] = DistanceMatrix[i, j];
                }
            }
        }
        public double Tour_distance(Particle P)
        {
            double[] pr=new double[P.Dimension];
            int[] rk=new int[P.Dimension];
            for (int i=0;i<P.Dimension;i++)
            {
                rk[i]=i+1;
                pr[i]=P.Position[i];
            }
            Array.Sort(pr,rk);
            double tour_dis=0;
            tour_dis+=DistanceMatrix[0,rk[0]];
            for (int i=0;i<P.Dimension-1;i++)
            {
                tour_dis += DistanceMatrix[rk[i], rk[i + 1]];
            }
            tour_dis += DistanceMatrix[rk[P.Dimension - 1], 0];
            return tour_dis;
        }
        public int[] getTour(double[] P)
        {
            double[] pr = new double[P.Length];
            int[] rk = new int[P.Length];
            for (int i = 0; i < P.Length; i++)
            {
                rk[i] = i + 1;
                pr[i] = P[i];
            }
            Array.Sort(pr, rk);
            return rk;
        }
    }
    class Location
    {
        private double x;
        private double y;
        public Location(double xx, double yy)
        {
            this.x = xx;
            this.y = yy;
        }
        public Location(Location L)
        {
            this.x = L.X;
            this.y = L.Y;
        }
        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
    }
}
