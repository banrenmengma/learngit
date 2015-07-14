/* --------------------------------------------------------------------------------------------------------
  MOPSO.cs
  Nguyen Phan Bach Su 09-Feb-2010
  High Performance Computing Group,
  Industrial and Systems Engineering (ISE),
  Asian Institute of Technology (AIT)

 DESCRIPTION:
   Multi-strategy Multi-Learning-Term Multi-Objective PSO (M3PSO) is an optimization library which
was developed from the single objective GLNPSO library (Ai, T. J., 2009) to handle multi-objective 
optimization problems. Both M3PSO library and GLNPSO library were developed at Department of Industrial 
and Systems Engineering (ISE), Asian Institute of Technology (AIT), Thailand. The purpose of these libraries 
is to provide the researchers and students who are working on various optimization problems with a
general effective tool based on Particle Swarm Optimization algorithm.  
 * 
   This file contains the formulations of several optimization problems including the initialization,
objective evaluation, and parameters' setting methods.
------------------------------------------------------------------------------------------------------------ */
using System;
using System.IO;
using System.Collections;
using ETLib_M3PSO;
namespace PSO_MutiObjective
{	// MOPSO for minimization problem 
	class spPSO : M3PSO
	{
        public int fx;
        public spPSO(int fx, int nPar, int nIter, int nNB, double dwmax, double dwmin, 
            double dcp, double dcg, double dcl, double dcn, int maxE, int moveStr, ArrayList pm,double te,double be, double gap)
            :
			base(nIter, nNB, dwmax, dwmin, dcp, dcg, dcl, dcn,maxE,moveStr,pm)
		{
            //define problem
            #region define problem
            this.fx = fx;
            int dimension=0;
            bool constr = false;
            if (fx == 0) dimension = 1;
            if (fx == 1) dimension = 3;
            if (fx == 2) dimension = 30;
            if (fx == 3) dimension = 30;
            if (fx == 4) dimension = 30;
            if (fx == 5) dimension = 10;
            if (fx == 6) dimension = 10;
            if (fx == 7) dimension = 2;
            if (fx == 8) dimension = 2;
            if (fx == 9) dimension = 2;
            if (fx == 10) dimension = 4;
            if (fx >= 7) constr = true;
            int nObj=2;          
            #endregion
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
                for (int j = 0; j < ((Particle)this.ElististP[i]).Dimension; j++)
                    t.Write(((Particle)this.ElististP[i]).Position[j].ToString() + "\t");
                t.WriteLine();
            }
			t.WriteLine("");
			t.WriteLine("Result:");
			t.WriteLine("-------");		
		}
		public override double[] Objective(Particle p)
		{
            double[] obj=new double[p.NoObj];
            if (fx == 0) Function.SCH_Function(p, obj);    //dim =1 , range [-1000,1000], opt_range_x[0,2]
            if (fx == 1) Function.KUR_Function(p, obj);    //dim 3 , range [-5,5]
            if (fx == 2) Function.ZDT1_Function(p, obj);   //dim =30, range[0,1], opt_range_x[1] in [0,1] and other x =0
            if (fx == 3) Function.ZDT2_Function(p, obj);  //dim =30, range[0,1], opt_range_x[1] in [0,1] and other x =0
            if (fx == 4) Function.ZDT3_Function(p, obj);   //dim = 30, range [0,1], opt_range_x[1] in [0,1] and other x =0
            if (fx == 5) Function.ZDT4_Function(p, obj);   //*dim =10, x1 in [0,1] and others in [-5,5], optimal range is similar to ZDT2
            if (fx == 6) Function.ZDT6_Function(p, obj);   //dim =10, range[0,1], opt_range_x[1] in [0,1] and other x =0
            if (fx == 7) Function.CONSTR_Function(p, obj); //dim =2, x1_range[0.1,1],x2_range[0,5]
            if (fx == 8) Function.SRN_Function(p, obj);    //dim =2, range[-20,20],
            if (fx == 9) Function.TNK_Function(p, obj);    //dim =2, range[0,PI],
            if (fx == 10) Function.IBeamFunction(p, obj);    //dim =2, range[0,PI],
			return obj;
		}	
		public override void InitSwarm()
		{
            #region initialize swarm
            double u1 = 0; double l1 = 0;
            double u2 = 0; double l2 = 0;
            bool secondbound = false;
            if (fx == 0)
            {
                u1 = 1000;
                l1 = -1000;
            }
            if (fx == 1)
            {
                u1 = 5;
                l1 = -5;
            }
            if (((fx >= 2) && (fx <= 4)) || (fx == 6))
            {
                u1 = 1;
                l1 = 0;
            }
            if (fx == 5)
            {
                u1 = 5;
                l1 = -5;
                u2 = 1;
                l2 = 0;
                secondbound = true;
            }
            if (fx == 7)
            {
                u1 = 5;
                l1 = 0;
                u2 = 1;
                l2 = .1;
                secondbound = true;
            }
            if (fx == 8)
            {
                u1 = 20;
                l1 = -20;
            }
            if (fx == 9)
            {
                u1 = Math.PI;
                l1 = 0;
            }
            #endregion
            if (fx < 10)
            {
                for (int i = 0; i < sSwarm.Member; i++)
                {
                    for (int j = 0; j < sSwarm.pParticle[i].Dimension; j++)
                    {
                        sSwarm.pParticle[i].Position[j] = l1 + (u1 - l1) * rand.NextDouble();
                        sSwarm.pParticle[i].Velocity[j] = 0;
                        sSwarm.pParticle[i].BestP[j] = sSwarm.pParticle[i].Position[j];
                        sSwarm.pParticle[i].PosMin[j] = l1;
                        sSwarm.pParticle[i].PosMax[j] = u1;
                    }
                    if (secondbound)
                    {
                        sSwarm.pParticle[i].Position[0] = l2 + (u2 - l2) * rand.NextDouble();
                        sSwarm.pParticle[i].Velocity[0] = 0;
                        sSwarm.pParticle[i].BestP[0] = sSwarm.pParticle[i].Position[0];
                        sSwarm.pParticle[i].PosMin[0] = l2;
                        sSwarm.pParticle[i].PosMax[0] = u2;
                    }
                    //*/
                    for (int o = 0; o < sSwarm.pParticle[i].NoObj; o++)
                        sSwarm.pParticle[i].ObjectiveP[o] = 1.7E308;
                }
            }
            else
            {//ibeam problem
                double[] ll = new double[4];
                double[] uu = new double[4];
                ll[0] = 10; uu[0] = 80;
                ll[1] = 10; uu[1] = 50;
                ll[2] = 0.9; uu[2] = 5;
                ll[3] = 0.9; uu[3] = 5;
                for (int i = 0; i < sSwarm.Member; i++)
                {
                    for (int j = 0; j < sSwarm.pParticle[i].Dimension; j++)
                    {
                        sSwarm.pParticle[i].Position[j] = ll[j] + (uu[j] - ll[j]) * rand.NextDouble();
                        sSwarm.pParticle[i].Velocity[j] = 0;
                        sSwarm.pParticle[i].BestP[j] = sSwarm.pParticle[i].Position[j];
                        sSwarm.pParticle[i].PosMin[j] = ll[j];
                        sSwarm.pParticle[i].PosMax[j] = uu[j];
                    }
                    for (int o = 0; o < sSwarm.pParticle[i].NoObj; o++)
                        sSwarm.pParticle[i].ObjectiveP[o] = 1.7E308;
                }
            }
			sSwarm.posBest=new int[sSwarm.pParticle[0].NoObj];
		}
	}

	class MainClass
	{
        public static void PSO(int fx,double[] PSOparas, int strategy, bool aniEnable, out double[] index, out ArrayList Pareto, out ArrayList Ani, out ArrayList AniS, out ArrayList Average)
        {
            // modification = criterion to join unexplored group is the range > 0.01*maxrange (excel)
            // personal best is replaced if it is dominated or non-dominated (50%)
            // trap=100 steps
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
            double TopEp = PSOparas[10] / 100;
            double BotEp = PSOparas[11] / 100;
            double GapUnexplore = PSOparas[12] / 100;

            int moveStrategy = strategy;

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

            for (int i = 0; i < noRep; i++)
            {
                rSeed++;
                AvgVal[i] = new ArrayList();
                Console.WriteLine("Replication {0}", i + 1);
                tw.WriteLine("Replication {0}", i + 1);
                // get the starting time from CPU clock
                start = DateTime.Now;
                // main program ...
                M3PSO GlobalSwarm = new spPSO(fx,noPar, noIter, noNB, wMax, wMin, cP, cG, cL, cN, maxE, moveStrategy, pMix, TopEp, BotEp, GapUnexplore);
                GlobalSwarm.SetRSeed(rSeed);
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
            index = new double[AvgVal[0].Count];
            for (int i = 0; i < AvgVal[0].Count; i++)
            {
                index[i] = (double)i;
            }
            for (int o = 0; o < ((double[])(AvgVal[0])[0]).Length; o++)
            {
                double[] Avg = new double[AvgVal[0].Count];
                for (int i = 0; i < AvgVal[0].Count; i++)
                {
                    Avg[i] = (double)(((double[])(AvgVal[0])[i])[o]);
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
