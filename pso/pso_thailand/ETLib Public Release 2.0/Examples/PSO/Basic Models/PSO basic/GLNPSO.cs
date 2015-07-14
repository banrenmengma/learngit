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
using ETLib_GLNPSO;
namespace PSO_basic
{	// PSO for minimization problem
	class spPSO : PSO
	{	// this part is the problem specific code
		// Minimize f(x) = 0.001x^2 + 2*Sin(x), -100<=x<=100
		public spPSO(int nPar, int nIter, int nNB, double dwmax, double dwmin, double dcp, double dcg, double dcl, double dcn):
			base(nIter, nNB, dwmax, dwmin, dcp, dcg, dcl, dcn)
		{	
			base.SetDimension(nPar, 1); //set the swarm size and dimension of each particle
		}
		public override void DisplayResult(TextWriter t)
		{
			t.WriteLine("");
			t.WriteLine("Result:");
			t.WriteLine("-------");
            //write the position of the best particle
			for(int i=0; i<this.sSwarm.pParticle[this.sSwarm.posBest].Dimension; i++)
				t.WriteLine("x({0}) = {1}", i, this.sSwarm.pParticle[this.sSwarm.posBest].BestP[i]);
            t.WriteLine("f(x) = {0}", this.sSwarm.pParticle[this.sSwarm.posBest].ObjectiveP);			
		}

		public override double Objective(Particle P)
		{
			double obj = 0;
            //evaluate the objective value corresponding to the position of the Particle
            for (int i = 0; i < P.Dimension; i++)
                obj += 0.001 * Math.Pow(P.Position[i], 2) + 2 * Math.Sin(P.Position[i]);
			return obj;
		}
	
		public override void InitSwarm()
		{
			for(int i=0; i<sSwarm.Member; i++)
			{
                for (int j = 0; j < sSwarm.pParticle[i].Dimension; j++)
                {
                    sSwarm.pParticle[i].Position[j] = -100+200*rand.NextDouble(); //generate random number from 0 to 1
                    sSwarm.pParticle[i].Velocity[j] = 0;
                    sSwarm.pParticle[i].BestP[j] = sSwarm.pParticle[i].Position[j];
                    sSwarm.pParticle[i].PosMin[j] = -100;  //set the lower bound of a position
                    sSwarm.pParticle[i].PosMax[j] =  100;  //set the upper bound of a position
                }
                sSwarm.pParticle[i].ObjectiveP = 1.7E308;   //initialize the personal best objective value
			}
			sSwarm.posBest = 0;
		}
	}
	class MainClass
	{
		public static void Main(string[] args)
		{   
            //set the PSO's parameters
            int noPar = 10;
            int noIter = 200;
            int noNB = 5;
            double wMax = 0.9;
            double wMin = 0.4;
            double cP = 2;
            double cG = 2;
            double cL = 0;
            double cN = 0;
            string oFile = "MyPSO.xls";
            int noRep = 30; //number of replications
			// starting time and finish time using DateTime datatype
			DateTime start, finish;
			
			// elapsed time using TimeSpan datatype
			TimeSpan elapsed;

			// opening output file
			TextWriter tw = new StreamWriter(oFile);
            tw.WriteLine("Number of Particle  \t {0} ", noPar);
            tw.WriteLine("Number of Iteration \t {0} ", noIter);
            tw.WriteLine("Number of Neighbor  \t {0} ", noNB);
            tw.WriteLine("Parameter wmax      \t {0} ", wMax);
            tw.WriteLine("Parameter wmin      \t {0} ", wMin);
            tw.WriteLine("Parameter cp        \t {0} ", cP);
            tw.WriteLine("Parameter cg        \t {0} ", cG);
            tw.WriteLine("Parameter cl        \t {0} ", cL);
            tw.WriteLine("Parameter cn        \t {0} ", cN);
            tw.WriteLine("Output File Name {0} ", oFile);
			tw.WriteLine("");			

			for(int i=0; i<noRep; i++)
			{
				tw.WriteLine("Replication {0}", i+1);
                tw.WriteLine("Iteration \t global best index \t best objective value \t dispersion index \t average obj \t min obj \t max obj");
				// get the starting time from CPU clock
				start = DateTime.Now;
				
				// main program ...
				PSO myPSO = new spPSO(noPar, noIter, noNB, wMax, wMin, cP, cG, cL, cN);
                Console.WriteLine("Replication {0}", i + 1);
                myPSO.Run(tw, true);
				
				myPSO.DisplayResult(tw);
				
				// get the finishing time from CPU clock
				finish = DateTime.Now;
				elapsed = finish - start;
				
				// display the elapsed time in hh:mm:ss.milli
				tw.WriteLine("{0} is the computational time", elapsed.Duration());
				tw.WriteLine("");
			}
			tw.Close();
            Console.ReadKey();
		}
	}
}
