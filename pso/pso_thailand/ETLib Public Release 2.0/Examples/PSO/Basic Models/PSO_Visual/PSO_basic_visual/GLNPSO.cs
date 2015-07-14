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
using System.Collections;
using ETLib_AniPSO;
namespace PSO_basic_visual
{	// PSO for minimization problem
    class spPSO : PSO
    {
        public int fx = 0;
        // this part is the problem specific code
        // Minimize f(x)
        public spPSO(int fx,int nPar, int nIter, int nNB, double dwmax, double dwmin, double dcp, double dcg, double dcl, double dcn)
            :
            base(nIter, nNB, dwmax, dwmin, dcp, dcg, dcl, dcn)
        {
            base.SetDimension(nPar, 1);
            this.fx = fx;
        }
        public override void DisplayResult(TextWriter t)
        {
            double obj = 0;
            //for (int i = 0; i < this.sSwarm.pParticle[this.sSwarm.posBest].Dimension; i++)
            obj = Function.Test_FunctionBestpos(this.fx,this.sSwarm.pParticle[this.sSwarm.posBest]);
            t.WriteLine("");
            t.WriteLine("Result:");
            t.WriteLine("-------");
            for (int i = 0; i < this.sSwarm.pParticle[this.sSwarm.posBest].Dimension; i++)
                t.WriteLine("x({0}) = {1}", i, this.sSwarm.pParticle[this.sSwarm.posBest].BestP[i]);
            t.WriteLine("f(x) = {0}", obj);
        }

        public override double Objective(Particle P)
        {
            double obj = 0;
            obj=Function.Test_Function(this.fx, P); 
            return obj;
        }

        public override void InitSwarm()
        {
            for (int i = 0; i < sSwarm.Member; i++)
            {
                for (int j = 0; j < sSwarm.pParticle[i].Dimension; j++)
                {
                    sSwarm.pParticle[i].Position[j] = -100 + 200 * rand.NextDouble();
                    sSwarm.pParticle[i].Velocity[j] = 0;
                    sSwarm.pParticle[i].BestP[j] = sSwarm.pParticle[i].Position[j];
                    sSwarm.pParticle[i].PosMin[j] = -100;
                    sSwarm.pParticle[i].PosMax[j] = 100;
                }
                sSwarm.pParticle[i].ObjectiveP = 1.7E308;
            }
            sSwarm.posBest = 0;
        }
    }

	class MainClass
	{
		public static void PSO(int fx,double[] PSOparas,out double ObjVal,out double[] Avg,out double[] index, out ArrayList Ani,out ArrayList AniS,out Particle Gb)
		{
            double BestObj=0;
            ArrayList sAni;
            ArrayList sAni2;
            ArrayList[] AvgVal;
            string oFile = "MyPSO.xls";
            //data for animation
            sAni = new ArrayList();
            sAni2 = new ArrayList();
            //parameter setting          
            int noIter  = Convert.ToInt32(PSOparas[0]);
            int noPar   = Convert.ToInt32(PSOparas[1]);
            double wMin = PSOparas[2];        
            double wMax = PSOparas[3];
            int noNB    = Convert.ToInt32(PSOparas[4]);
            double cP   = PSOparas[5];
            double cG   = PSOparas[6];
            double cL   = PSOparas[7];
            double cN   = PSOparas[8];
            int noRep   = 1;
            int rSeed   = -1; //set the random seed (-1 is set when we don't need to control the random stream)
            // end parameter setting
			// starting time and finish time using DateTime datatype
			DateTime start, finish;
			
			// elapsed time using TimeSpan datatype
			TimeSpan elapsed;
            #region Write parameter to text
            // opening output file
			TextWriter tw = new StreamWriter(oFile);
			tw.WriteLine("{0} Number of Particle  ", noPar);
			tw.WriteLine("{0} Number of Iteration ", noIter);
			tw.WriteLine("{0} Number of Neighbor  ", noNB);
			tw.WriteLine("{0} Parameter wmax      ", wMax);
			tw.WriteLine("{0} Parameter wmin      ", wMin);
			tw.WriteLine("{0} Parameter cp        ", cP);
			tw.WriteLine("{0} Parameter cg        ", cG);
			tw.WriteLine("{0} Parameter cl        ", cL);
			tw.WriteLine("{0} Parameter cn        ", cN);
			tw.WriteLine("{0} Output File Name    ", oFile);
            tw.WriteLine("Number of replications" + "\t" + "{0}", noRep);
            tw.WriteLine("");
            #endregion
            AvgVal = new ArrayList[noRep];

            Particle Gbest=new Particle(1);
			for(int i=0; i<noRep; i++)
			{
                rSeed++;
                AvgVal[i] = new ArrayList();
				Console.WriteLine("Replication {0}", i+1);
				tw.WriteLine("Replication {0}", i+1);
				// get the starting time from CPU clock
				start = DateTime.Now;
				
				// main program ...
                PSO GlobalSwarm = new spPSO(fx,noPar, noIter, noNB, wMax, wMin, cP, cG, cL, cN);
                GlobalSwarm.SetRSeed(rSeed);
                GlobalSwarm.Run(tw, true, AvgVal[i], out sAni,out sAni2);

				// get the finishing time from CPU clock
				finish = DateTime.Now;
				elapsed = finish - start;
				
				// display the elapsed time in hh:mm:ss.milli
				tw.WriteLine("{0} is the computational time", elapsed.Duration());
				tw.WriteLine("");
                Gbest = GlobalSwarm.sSwarm.pParticle[GlobalSwarm.sSwarm.posBest];
			}
            Gb = Gbest;
			tw.Close();
            ObjVal = BestObj;
            Avg = new double[AvgVal[0].Count];
            index=new double[AvgVal[0].Count];
            for (int i = 0; i < AvgVal[0].Count; i++)
            {
                Avg[i] = (double)(AvgVal[0])[i];
                index[i] = (double)i;
            }
            AniS = sAni;
            Ani = sAni2;
		}
	}
}
