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
using ETLib_M3PSO;

namespace PSO_MutiObjective
{
    class Portfolio
    {
        public Asset[] A;
        public int numAssets;
        public double[,] CoV;
        public int K; //cardinality constraint
        public Portfolio()
        {
        }
        public Portfolio(int number_Assets)
        {
            A = new Asset[number_Assets];
            numAssets = number_Assets;
            CoV = new double[number_Assets, number_Assets];
            K = this.numAssets;
        }
        public void setLimitAssests(int K)
        {
            this.K = K;
        }
        public double[] Evaluate_Portfolio(Particle P, double[] objPort)
        {
            //double[] objPort //0: expected return of portfolio; 1: risk of portfolio
            //calculate expected return of the portfolio
            for (int i = 0; i < P.Dimension; i++)
            {
                objPort[0] -= P.Position[i] * A[i].EXPECTED_RETURN;
                objPort[2] += P.Position[i];
            }
            //calculate the risk of the portfolio
            for (int i = 0; i < P.Dimension; i++)
            {
                for (int j = 0; j < P.Dimension; j++)
                {
                    objPort[1] += P.Position[i] * P.Position[j] * CoV[i, j];
                }
            }
            P.inFeasible = 0;
            if (objPort[2] > 1)
            {
                objPort[2] = 1;
                P.inFeasible = 1;
            }
            return objPort;
        }
        public double[] REvaluate_Portfolio(Particle P, double[] objPort)
        {
            //double[] objPort //0: expected return of portfolio; 1: risk of portfolio
            //check constraint
            P.Position[0] = 0.4;
            P.Position[1] = 0.2;
            P.Position[2] = 0.8;
            P.Position[3] = 0.6;
            double sumW = 0;
            for (int i = 0; i < P.Dimension; i++)
            {
                sumW += P.Position[i];
            }
            if (sumW == 0) //if no assets are invested, all assets will be recieved the same share
            {
                for (int i = 0; i < P.Dimension; i++)
                {
                    P.Position[i] = 1 / (double)P.Dimension;
                }
            }
            else
            {
                if (sumW != 1) //repair solution
                {
                    for (int i = 0; i < P.Dimension; i++)
                    {
                        P.Position[i] = P.Position[i] / sumW;
                    }
                }
            }
            //calculate expected return of the portfolio
            for (int i = 0; i < P.Dimension; i++)
            {
                objPort[0] -= P.Position[i] * A[i].EXPECTED_RETURN;
            }
            //calculate the risk of the portfolio
            for (int i = 0; i < P.Dimension; i++)
            {
                for (int j = 0; j < P.Dimension; j++)
                {
                    objPort[1] += P.Position[i] * P.Position[j] * CoV[i, j];
                }
            }
            return objPort;
        } //repair decoding
        public double[] CBREvaluate_Portfolio(Particle P, double[] objPort) //repair + cardinality + buy-in threshold
        {
            K = 10;
            //double[] objPort //0: expected return of portfolio; 1: risk of portfolio
            //sorting the decision vector to get the first K assets
            double[] w = new double[P.Dimension];
            int[] indexA = new int[P.Dimension];
            for (int i = 0; i < P.Dimension; i++)
            {
                w[i] = -P.Position[i];
                indexA[i] = i;
            }
            Array.Sort(w, indexA);
            double sumW = 0;
            double lbsum = 0;
            //check cardinality constraint and repair the decision vector
            for (int i = 0; i < P.Dimension; i++)
            {
                if (i < K)
                {
                    sumW += P.Position[indexA[i]];
                    lbsum += A[indexA[i]].LOWERBOUND;
                }
                else
                {
                    P.Position[indexA[i]] = 0;
                }
            }
            if (sumW == 0) //if no assets are invested, all assets will be recieved the same share
            {
                for (int i = 0; i < K; i++)
                {
                    P.Position[indexA[i]] = 1 / (double)K;
                }
            }
            else
            {
                for (int i = 0; i < K; i++)
                {
                    P.Position[indexA[i]] =A[indexA[i]].LOWERBOUND+(1-lbsum)*(P.Position[indexA[i]] / sumW);
                }
            }
            //check threshold constraint and repair the decision vector

            //calculate expected return of the portfolio
            for (int i = 0; i < P.Dimension; i++)
            {
                objPort[0] -= P.Position[i] * A[i].EXPECTED_RETURN;
            }
            //calculate the risk of the portfolio
            for (int i = 0; i < P.Dimension; i++)
            {
                for (int j = 0; j < P.Dimension; j++)
                {
                    objPort[1] += P.Position[i] * P.Position[j] * CoV[i, j];
                }
            }
            return objPort;
        }
        public void  getPortfolio(double[] P)
        { 
        
        }
    }
    class Asset
    { 
        private double expectedReturn;
        private double stDev;
        private double lowerBound=0;
        private double upperBound=1;

        public Asset(double expectedReturn, double stdev, double lowerbound,double upperbound)
        {
            this.expectedReturn = expectedReturn;
            this.lowerBound = lowerbound;
            this.upperBound = upperbound;
            this.stDev = stdev;
        }
        public Asset(Asset A)
        {
            this.expectedReturn = A.expectedReturn;
            this.lowerBound = A.lowerBound;
            this.upperBound = A.upperBound;
            this.stDev = A.stDev;
        }
        public double EXPECTED_RETURN
        {
            get { return this.expectedReturn; }
            set { this.expectedReturn = value; }
        }
        public double LOWERBOUND
        {
            get { return this.lowerBound; }
            set { this.lowerBound = value; }
        }
        public double UPPERBOUND
        {
            get { return this.upperBound; }
            set { this.upperBound = value; }
        }
        public double STDEV
        {
            get { return this.stDev; }
            set { this.stDev = value; }
        }
    }
}
