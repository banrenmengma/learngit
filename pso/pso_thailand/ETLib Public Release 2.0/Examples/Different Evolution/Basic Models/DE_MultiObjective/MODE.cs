
using System;
using System.IO;
using System.Collections;
using ETLib_MODE;

namespace DE_MultiObjective
{	// MODE for minimization problem 
    //public delegate void setRNText( String str );

	class spDE : M3DE
	{
        public int fx;
        public spDE(int fx, int nVec, int nIter, int nNB, double Fmax, double Fmin, 
            double croRx, double croRn,  int maxE, int moveStr, ArrayList vm,double te,double be, double gap)
            :
			base(nIter, nNB, Fmax, Fmin, croRx, croRn, maxE,moveStr,vm)
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
			if (moveStr==6) base.SetParameters(nVec, dimension,nObj+1,constr,te,be,gap);
            else base.SetParameters(nVec, dimension, nObj, constr, te, be, gap);
            //number of vectors, dimension, 
            //number of objective (+1 if ms6 is used, and +1 more if there are constraints in the model
            //and constraint activator (true if there are any constrains in the model         
		}
		public override void DisplayResult(TextWriter t)
		{
            t.WriteLine("No. NonDom: " + "\t" + "{0}",ElististP.Count);
            for (int i = 0; i < this.ElististP.Count; i++)
            {
                for (int o = 0; o < ((DecisionVector)this.ElististP[0]).NoObj; o++)
                    t.Write(((DecisionVector)this.ElististP[i]).Objective[o].ToString() + "\t");
                t.WriteLine();
            }
			t.WriteLine("");
			t.WriteLine("Result:");
			t.WriteLine("-------");		
		}
		public override double[] Objective(DecisionVector p, int trial)
		{
            double[] obj=new double[p.NoObj];
           
            if (fx == 0) Function.SCH_Function(p, obj, trial);    //dim =1 , range [-1000,1000], opt_range_x[0,2]
            if (fx == 1) Function.KUR_Function(p, obj, trial);    //dim 3 , range [-5,5]
            if (fx == 2) Function.ZDT1_Function(p, obj, trial);   //dim =30, range[0,1], opt_range_x[1] in [0,1] and other x =0
            if (fx == 3) Function.ZDT2_Function(p, obj, trial);  //dim =30, range[0,1], opt_range_x[1] in [0,1] and other x =0
            if (fx == 4) Function.ZDT3_Function(p, obj, trial);   //dim = 30, range [0,1], opt_range_x[1] in [0,1] and other x =0
            if (fx == 5) Function.ZDT4_Function(p, obj, trial);   //*dim =10, x1 in [0,1] and others in [-5,5], optimal range is similar to ZDT2
            if (fx == 6) Function.ZDT6_Function(p, obj, trial);   //dim =10, range[0,1], opt_range_x[1] in [0,1] and other x =0
            if (fx == 7) Function.CONSTR_Function(p, obj, trial); //dim =2, x1_range[0.1,1],x2_range[0,5]
            if (fx == 8) Function.SRN_Function(p, obj, trial);    //dim =2, range[-20,20],
            if (fx == 9) Function.TNK_Function(p, obj, trial);    //dim =2, range[0,PI],
            if (fx == 10) Function.IBeamFunction(p, obj, trial);    //dim =2, range[0,PI],
			return obj;
		}	
		public override void InitPop()
		{
            #region initialize Population
            double u1 = 0; double l1 = 0;
            double u2 = 0; double l2 = 0;
            bool secondbound = false;
            if (fx == 0)
            {
                u1 = 10;
                l1 = -10;
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
                for (int i = 0; i < Pop.Member; i++)
                {
                    for (int j = 0; j < Pop.Vector[i].Dimension; j++)
                    {
                        Pop.Vector[i].CurrentVector[j] = l1 + (u1 - l1) * rand.NextDouble();                        
                        Pop.Vector[i].VecMin[j] = l1;
                        Pop.Vector[i].VecMax[j] = u1;
                    }
                    if (secondbound)
                    {
                        Pop.Vector[i].CurrentVector[0] = l2 + (u2 - l2) * rand.NextDouble();                        
                        Pop.Vector[i].VecMin[0] = l2;
                        Pop.Vector[i].VecMax[0] = u2;
                    }
                    //*/
                    for (int o = 0; o < Pop.Vector[i].NoObj; o++)
                        Pop.Vector[i].Objective[o] = 1.7E308;
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
                for (int i = 0; i < Pop.Member; i++)
                {
                    for (int j = 0; j < Pop.Vector[i].Dimension; j++)
                    {
                        Pop.Vector[i].CurrentVector[j] = ll[j] + (uu[j] - ll[j]) * rand.NextDouble();                       
                        Pop.Vector[i].VecMin[j] = ll[j];
                        Pop.Vector[i].VecMax[j] = uu[j];
                    }
                    for (int o = 0; o < Pop.Vector[i].NoObj; o++)
                        Pop.Vector[i].Objective[o] = 1.7E308;
                }
            }

			Pop.posBest = new int[Pop.Vector[0].NoObj]; // why ??
		}
	}

	class MainClass
	{
        public static void DE(int fx,double[] DEparas, int strategy, bool aniEnable, out double[] index, out ArrayList Pareto, out ArrayList Ani, out ArrayList AniS, out ArrayList Average /*, setRNText setRN*/ )
        {
            // modification = criterion to join unexplored group is the range > 0.01*maxrange (excel)            
            // trap=100 steps
            #region Animation Storage
            ArrayList PFront;
            ArrayList sAni;
            ArrayList sAni2;
            ArrayList[] AvgVal;
            ArrayList vMix = new ArrayList();
            string oFile = "MyDE_strategy" + strategy.ToString() + ".xls";

            PFront = new ArrayList();
            sAni = new ArrayList();
            sAni2 = new ArrayList();
            #endregion
            #region set MODE paratmeters
            //parameter setting
            int noIter = Convert.ToInt32(DEparas[0]);
            int noVec = Convert.ToInt32(DEparas[1]);
            double FMin = DEparas[2];
            double FMax = DEparas[3];
            int noNB = Convert.ToInt32(DEparas[4]);
            double COx = DEparas[5];
            double COn = DEparas[6];

            int maxE = Convert.ToInt32(DEparas[9]);
            double TopEp = DEparas[10] / 100;
            double BotEp = DEparas[11] / 100;
            double GapUnexplore = DEparas[12] / 100;

            int moveStrategy = strategy;

            int rSeed = (int)DEparas[17];
            int noRep = (int)DEparas[18];
            // end parameter setting

            if (moveStrategy == 6)
            {
                vMix.Add(0); vMix.Add((double)DEparas[13] / 100);
                vMix.Add(1); vMix.Add((double)DEparas[14] / 100);
                vMix.Add(2); vMix.Add((double)DEparas[15] / 100);
            }
            if (moveStrategy == 5)
            {
                vMix.Add(0); vMix.Add((double)DEparas[13] / 100);
                vMix.Add(1); vMix.Add((double)DEparas[14] / 100);
                vMix.Add(2); vMix.Add((double)DEparas[15] / 100);
                vMix.Add(3); vMix.Add((double)DEparas[16] / 100);
            }
            #endregion
            // starting time and finish time using DateTime datatype
            DateTime start, finish;
            // elapsed time using TimeSpan datatype
            TimeSpan elapsed;
            #region Write parameter to text
            // opening output file
            TextWriter tw = new StreamWriter(oFile);
            tw.WriteLine("{0} Number of Vectors  ", noVec);
            tw.WriteLine("{0} Number of Iteration ", noIter);
            tw.WriteLine("{0} Number of Neighbor  ", noNB);
            tw.WriteLine("{0} Parameter Fmax      ", FMax);
            tw.WriteLine("{0} Parameter Fmin      ", FMin);
            tw.WriteLine("{0} Parameter crox        ", COx);
            tw.WriteLine("{0} Parameter cron        ", COn);
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
                //show results of running rep                
                //setRN.Invoke((i + 1).ToString());
                // get the starting time from CPU clock
                start = DateTime.Now;
                // main program ...
                M3DE GlobalPop = new spDE(fx,noVec, noIter, noNB, FMax, FMin, COx, COn, maxE, moveStrategy, vMix, TopEp, BotEp, GapUnexplore);
                GlobalPop.SetRSeed(rSeed);                
                GlobalPop.Run(tw, true, aniEnable, AvgVal[i], out sAni, out sAni2);
                // get the finishing time from CPU clock
                finish = DateTime.Now;
                elapsed = finish - start;
                // display the elapsed time in hh:mm:ss.milli
                tw.WriteLine("{0} is the computational time", elapsed.Duration());
                tw.WriteLine("");
                if (i == 0) PFront = GlobalPop.ElististP; // rep 0          
            }
            tw.Close();
            #region Finalize animation data  //only for the first replication
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
