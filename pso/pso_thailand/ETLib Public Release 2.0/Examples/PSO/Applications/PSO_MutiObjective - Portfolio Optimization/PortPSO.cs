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
using ETLib_M3PSO;

namespace PSO_MutiObjective
{	// MOPSO for minimization problem
	class spPSO : M3PSO
	{
        public Portfolio port;
        public spPSO(int nPar, int nIter, int nNB, double dwmax, double dwmin, 
            double dcp, double dcg, double dcl, double dcn, int maxE, int moveStr, 
            ArrayList pm,double te,double be, double gap,Portfolio port)
            :
			base(nIter, nNB, dwmax, dwmin, dcp, dcg, dcl, dcn,maxE,moveStr,pm)
		{
            //define problem
            this.port = port;
            int dimension = port.numAssets;
            int nObj = 2;
            bool constr = false; 
            
            if (constr) nObj++;
			if (moveStr==6) base.SetParameters(nPar, dimension,nObj+1,constr,te,be,gap);
            else base.SetParameters(nPar, dimension, nObj, constr, te, be, gap);
            //number of particles, dimension, 
            //number of objective (+1 if ms6 is used, and +1 more if there are constraints in the model
            //and constraint activator (true if there are any constrains in the model         
		}
		public override void DisplayResult(TextWriter t)
		{
            t.WriteLine("No. NonDom: " + "\t" + "{0}",ElististP.Count);
            for (int i = 0; i < this.ElististP.Count; i++)
            {
                for (int o = 0; o < ((Particle)this.ElististP[0]).NoObj; o++)
                    t.Write(((Particle)this.ElististP[i]).Objective[o].ToString() + "\t");
                t.WriteLine();
            }
			t.WriteLine("");
			t.WriteLine("Result:");
			t.WriteLine("-------");		
		}
		public override double[] Objective(Particle p)
		{
            double[] obj=new double[p.NoObj];
            port.CBREvaluate_Portfolio(p,obj);
			return obj;
		}	
		public override void InitSwarm()
		{
			for(int i=0; i<sSwarm.Member; i++)
			{
                for (int j = 0; j < sSwarm.pParticle[i].Dimension; j++)
                {
                    sSwarm.pParticle[i].Position[j] =rand.NextDouble();
                    sSwarm.pParticle[i].Velocity[j] = 0;
                    sSwarm.pParticle[i].BestP[j] = sSwarm.pParticle[i].Position[j];
                    sSwarm.pParticle[i].PosMin[j] = 0;
                    sSwarm.pParticle[i].PosMax[j] =1;
                }
                //set particle type
                if (sSwarm.movingStrategy == 5)
                {
                    int ms = 0;
                    for (int k = 0; k < 5; k++)
                        if ((i > sSwarm.Member * sSwarm.particleMix[k, 0]) && (i <= sSwarm.Member * sSwarm.particleMix[k, 1])) ms = k;
                    sSwarm.pParticle[i].type = ms;
                }
                if (sSwarm.movingStrategy == 6)
                {
                    int c_obj = 0;
                    for (int k = 0; k < sSwarm.pParticle[i].NoObj; k++)
                        if ((i > sSwarm.Member * sSwarm.particleMix[k, 0]) && (i <= sSwarm.Member * sSwarm.particleMix[k, 1])) c_obj = k;   
                    if ((sSwarm.constr) && (c_obj == sSwarm.pParticle[i].NoObj - 2)) 
                        c_obj++; //adtaptive weighted objective function
                    sSwarm.pParticle[i].type = c_obj;
                }
                for (int o=0;o<sSwarm.pParticle[i].NoObj;o++)
                    sSwarm.pParticle[i].ObjectiveP[o] = 1.7E308;
			}
			sSwarm.posBest=new int[sSwarm.pParticle[0].NoObj];
		}
	}

	class MainClass
	{
        public static void PSO(double[] PSOparas, int strategy, bool aniEnable,out double[] index, out ArrayList Pareto, out ArrayList Ani, out ArrayList AniS, out ArrayList Average)
		{
            // modification = criterion to join unexplored group is the range > 0.01*maxrange (excel)
            // personal best is replaced if it is dominated or non-dominated (50%)
            // trap=100 steps
            Portfolio portfolio = new Portfolio();
            DataInput.ReadfromFile(out portfolio);
            #region Animation Storage
            ArrayList PFront;
            ArrayList sAni;
            ArrayList sAni2;
            ArrayList[] AvgVal;
            ArrayList pMix = new ArrayList();
            string oFile = "MyPSO_strategy" + strategy.ToString() + ".xls";
            
            PFront = new ArrayList();
            sAni = new ArrayList();
            sAni2 = new ArrayList();
            #endregion
            #region set MOPSO paratmeters
            //parameter setting
            int noIter = Convert.ToInt32(PSOparas[0]);
            int noPar = Convert.ToInt32(PSOparas[1]);
            double wMin = PSOparas[2];
            double wMax = PSOparas[3];
            int noNB = Convert.ToInt32(PSOparas[4]);
            double cP = PSOparas[5];
            double cG = PSOparas[6];
            double cL = PSOparas[7];
            double cN = PSOparas[8];

            int maxE = Convert.ToInt32(PSOparas[9]);
            double TopEp = PSOparas[10]/100;
            double BotEp = PSOparas[11]/100;
            double GapUnexplore = PSOparas[12]/100;

            int moveStrategy = strategy;
            bool multiSwarm = false;
            int rSeed = (int)PSOparas[17];
            int noRep = (int)PSOparas[18];
            // end parameter setting
            
            if (moveStrategy == 6)
            {
                pMix.Add(0); pMix.Add((double)PSOparas[13] / 100);
                pMix.Add(1); pMix.Add((double)PSOparas[14] / 100);
                pMix.Add(2); pMix.Add((double)PSOparas[15] / 100);
            }
            if (moveStrategy == 5)
            {
                pMix.Add(0); pMix.Add((double)PSOparas[13] / 100);
                pMix.Add(1); pMix.Add((double)PSOparas[14] / 100);
                pMix.Add(2); pMix.Add((double)PSOparas[15] / 100);
                pMix.Add(3); pMix.Add((double)PSOparas[16] / 100);
            }
            #endregion
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
            
			for(int i=0; i<noRep; i++)
			{
                rSeed++;
                AvgVal[i] = new ArrayList();
				Console.WriteLine("Replication {0}", i+1);
				tw.WriteLine("Replication {0}", i+1);
				// get the starting time from CPU clock
				start = DateTime.Now;			
				// main program ...
                M3PSO GlobalSwarm = new spPSO(noPar, noIter, noNB, wMax, wMin, cP, cG, cL, cN, maxE, moveStrategy,pMix,TopEp,BotEp,GapUnexplore,portfolio);
                GlobalSwarm.SetRSeed(rSeed);
                #region code for parallel swarms
                if (multiSwarm == true)
                {
                    M3PSO Sw1 = new spPSO(noPar, noIter, noNB, wMax, wMin, cP, cG, cL, cN, maxE, 5, pMix, TopEp, BotEp, GapUnexplore,portfolio);
                    Sw1.Run(tw, true,aniEnable, AvgVal[i],out sAni,out sAni2);
                    //recruit elite members from Sw1
                    GlobalSwarm.RecruitElite(Sw1.ElististP);

                    //PSO Sw2 = new spPSO(noPar, noIter, noNB, wMax, wMin, cP, cG, cL, cN, maxE, 0, pMix);
                    //Sw2.Run(tw, true, AvgVal[i]);
                    //recruit elite members from Sw2
                    //GlobalSwarm.RecruitElite(Sw2.ElististP);

                    //PSO Sw3 = new spPSO(noPar, noIter, noNB, wMax, wMin, 1, 1, 1, 1, maxE, 2,pMix);
                    //Sw3.Run(tw, true, AvgVal[i]);
                    //recruit elite members from Sw3
                    //GlobalSwarm.RecruitElite(Sw3.ElististP);

                    GlobalSwarm.SortEliteP(1,true);
                }
                #endregion
                GlobalSwarm.Run(tw, true, aniEnable, AvgVal[i], out sAni, out sAni2);
				// get the finishing time from CPU clock
				finish = DateTime.Now;
				elapsed = finish - start;			
				// display the elapsed time in hh:mm:ss.milli
				tw.WriteLine("{0} is the computational time", elapsed.Duration());
				tw.WriteLine("");
                if (i == 0) PFront = GlobalSwarm.ElististP;
			}  
			tw.Close();
            #region Finalize animation data
            Average = new ArrayList();
            index=new double[AvgVal[0].Count];
            for (int i = 0; i < AvgVal[0].Count; i++)
            {
                index[i] = (double)i;
            }
            for (int o = 0; o < ((double[])(AvgVal[0])[0]).Length; o++)
            {
                double[]  Avg = new double[AvgVal[0].Count];
                for (int i = 0; i < AvgVal[0].Count; i++)
                {
                    Avg[i] = Math.Pow(-1, 1 + o) * (double)(((double[])(AvgVal[0])[i])[o]);
                }
                Average.Add(Avg);
            }
            Pareto = PFront;
            Ani = sAni;
            AniS = sAni2;
            #endregion
        }
	}
}
