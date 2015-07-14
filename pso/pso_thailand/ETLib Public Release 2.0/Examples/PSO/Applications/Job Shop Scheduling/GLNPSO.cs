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
using ETLib_ADVANCEDPSO;
namespace PSO_JSP
{	// PSO for minimization problem
	class spPSO : PSO
	{
        public JSPdata JD;
		public spPSO(int nPar, int nIter, int nNB, double dwmax, double dwmin, double dcp, double dcg, double dcl, double dcn, int dim, JSPdata jd,int sRi,int Rii,int sLS,int LSi):
			base(nIter, nNB, dwmax, dwmin, dcp, dcg, dcl, dcn,dim,sRi,Rii,sLS,LSi)
		{	
			base.SetDimension(nPar, dim);
            JD = new JSPdata(jd.NoJob, jd.NoMc, jd.NoOp, jd.Job,jd.NoOpPerMc,jd.Machine);
		}
		public override void DisplayResult(TextWriter t)
		{
			t.WriteLine("");
			t.WriteLine("Result:");
			t.WriteLine("-------");
			for(int i=0; i<this.sSwarm.pParticle[this.sSwarm.posBest].Dimension; i++)
				t.WriteLine("x({0}) = \t {1}", i, this.sSwarm.pParticle[this.sSwarm.posBest].BestP[i]);
            t.WriteLine("f(x) = {0}", this.sSwarm.pParticle[this.sSwarm.posBest].ObjectiveP);			
		}

		public override double Objective(Particle P)
		{
			double obj = 0;
            obj = FitnessValue.FitnessValueScheduleGJSP(JD.NoJob, JD.NoMc, JD.NoOp, P.Position, JD.Job, P.Dimension, JD.NoOpPerMc, JD.Machine,JD);
			return obj;
		}
	
		public override void InitSwarm()
		{
            for (int i = initFrom; i < sSwarm.Member; i++)
			{
                for (int j = 0; j < sSwarm.pParticle[i].Dimension; j++)
                {
                    sSwarm.pParticle[i].Position[j] = rand.NextDouble();
                    sSwarm.pParticle[i].Velocity[j] = 0;
                    sSwarm.pParticle[i].BestP[j] = sSwarm.pParticle[i].Position[j];
                    sSwarm.pParticle[i].PosMin[j] = 0;
                    sSwarm.pParticle[i].PosMax[j] = 1;
                }
                sSwarm.pParticle[i].ObjectiveP = +1E18;
                
			}
			sSwarm.posBest = 0;
		}
        public override void ReInitSwarm()
        {            
           for (int i = 0; i < sSwarm.Member; i++)
            {
                if (i != sSwarm.posBest)
                {
                    for (int j = 0; j < sSwarm.pParticle[i].Dimension; j++)
                    {                       
                        sSwarm.pParticle[i].Position[j] = rand.NextDouble();
                        sSwarm.pParticle[i].Velocity[j] = 0;
                        sSwarm.pParticle[i].BestP[j] = sSwarm.pParticle[i].Position[j];
                        sSwarm.pParticle[i].PosMin[j] = 0;
                        sSwarm.pParticle[i].PosMax[j] = 1;
                    }                    
                    sSwarm.pParticle[i].ObjectiveP = +1E18;
                }
            }
        }
        public override void LocalSearchParticle(Particle P, ref Random RandomNum)
        {
            P.Position = LocalSearch.InterExchangeCirticalPath(JD.NoJob, JD.NoMc, JD.NoOp, JD.NoOpPerMc,
                    P.Dimension, P.BestP, P.ObjectiveP, JD.Machine, JD.Job, ref rand,ref JD);
            P.Objective = Objective(P);
        }
	}

	class MainClass
    {
        public static void Main(string[] args)
		{
            #region Read input from file
            int NoJob;
            int NoMc;
            int[] NoOp;
            job[] Job;
            ReadInput.ReadfromFile(out NoJob, out NoMc, out NoOp, out Job);
            #endregion
            #region calculateDimension
            int[] NoOpPerMc = new int[NoMc];
            machine[] Machine = new machine[NoMc];
            ReadInput.MachineInfo(NoJob, NoOp, ref NoOpPerMc, Job);
            JSPdata JD = new JSPdata(NoJob, NoMc, NoOp, Job, NoOpPerMc, Machine);
            int Dimension = 0; //To calculate Dimension = Sum of all NoOp 
            for (int j = 0; j < NoJob; j++)
            {
                Dimension += NoOp[j];
            }
            #endregion
            #region set PSO's parameters
            int noPar = 50;
            int noIter = 1000;
            int noNB = 5;
            double wMax = 0.9;
            double wMin = 0.4;
            double cP = 1.6;
            double cG = 0;
            double cL = 1.6;
            double cN = 0;

            string oFile = "MyPSO.xls";
           
            double MigrateProp = 0.1;
            bool multiSwarm = false;
            int noSwarm = 5;

            int startReinit = 1000000;
            int ReInitIterval = 1000;
            int startLS = 100000;
            int LSinterval = 100;
            #endregion
            
            //Number of replication
            int noRep = 30;
			// starting time and finish time using DateTime datatype
			DateTime start, finish;
			// elapsed time using TimeSpan datatype

			TimeSpan elapsed;
            #region createoutputFile
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
			tw.WriteLine("");
            #endregion

            for (int i=0; i<noRep; i++)
			{
				tw.WriteLine("Replication {0}", i+1);
				// get the starting time from CPU clock
				start = DateTime.Now;
				
				// main program ...
                PSO[] subSwarm=new PSO[noSwarm-1];
                #region Activate sub-swarms
                if (multiSwarm)
                {
                    for (int s = 0; s < noSwarm - 1; s++)
                    {
                        Console.WriteLine("Start swarm {0}", s);
                        subSwarm[s] = new spPSO(noPar, noIter, noNB, wMax, wMin, cP, cG, cL, cN, Dimension, JD,startReinit,ReInitIterval,startLS,LSinterval);
                        if (s != 0) subSwarm[s].Migrate(subSwarm[s - 1].sSwarm, subSwarm[s].sSwarm, MigrateProp);
                        subSwarm[s].Run(tw, true);

                        subSwarm[s].DisplayResult(tw);
                        Console.WriteLine("Obj {0} ", subSwarm[s].sSwarm.pParticle[subSwarm[s].sSwarm.posBest].ObjectiveP);
                    }
                }
                #endregion
                PSO globalSwarm = new spPSO(noPar, noIter, noNB, wMax, wMin, cP, cG, cL, cN, Dimension, JD, startReinit, ReInitIterval, startLS, LSinterval);
                Console.WriteLine("Start final swarm");
                Console.WriteLine("Replication {0}", i + 1);
                if (multiSwarm)
                {
                    for (int s = 0; s < noSwarm - 1; s++)
                        globalSwarm.MigrateBest(subSwarm[s].sSwarm, globalSwarm.sSwarm, 1 / ((double)noSwarm - 1));
                }
				globalSwarm.Run(tw, true);
               
                globalSwarm.DisplayResult(tw);
                Console.WriteLine("Obj {0} ", globalSwarm.sSwarm.pParticle[globalSwarm.sSwarm.posBest].ObjectiveP);
                // get the finishing time from CPU clock
                #region createreport
                finish = DateTime.Now;
				elapsed = finish - start;
			
				// display the elapsed time in hh:mm:ss.milli
				tw.WriteLine("{0} is the computational time", elapsed.Duration());
                Console.WriteLine("{0} is the computational time", elapsed.Duration());
				tw.WriteLine("");
                #endregion
            }
            Console.ReadKey();
            tw.Close();
		}

    }
}
