
using System;
using System.IO;
using System.Collections;
using ETLib_MODE_JSP;

namespace DE_MutiObjective
{	// MODE for minimization problem 
    class spM2DE : M2DE
    {
        public spM2DE(int nVec, int nIter, int nNB, double Fmax, double Fmin,
            double croRx, double croRn, int dim, JSPdata jd, int maxE, int moveStr, ArrayList vm, double te, double be, double gap)
            : base(nIter, nNB, Fmax, Fmin, croRx, croRn, dim, jd, maxE, moveStr, vm)
        {
            JD = new JSPdata(jd.NoJob, jd.NoMc, jd.NoOp, jd.Job, jd.NoOpPerMc, jd.Machine);
            int nObj = 2;
            //bool constr = false;
           
            base.SetParameters(nVec, dim, nObj,te, be, gap);
            //number of vectors, dimension, 
            //number of objective (+1 if ms6 is used, and +1 more if there are constraints in the model
            //and constraint activator (true if there are any constrains in the model         
            //define problem              
        }

        public override void InitPop()
        {
            for (int i = 0; i < Pop.Member; i++)
            {
                for (int j = 0; j < Pop.Vector[i].Dimension; j++)
                {
                    Pop.Vector[i].CurrentVector[j] = rand.NextDouble();
                }
                //set vector type
                if (Pop.movingStrategy == 5)
                {
                    int ms = 0;
                    for (int k = 0; k < 5; k++)
                        if ((i > Pop.Member * Pop.vectorMix[k, 0]) && (i <= Pop.Member * Pop.vectorMix[k, 1])) ms = k;
                    Pop.Vector[i].type = ms;
                }
                
                for (int o = 0; o < Pop.Vector[i].NoObj; o++)
                    Pop.Vector[i].Objective[o] = 1.7E308;
            }
                        
        }

        public override void DisplayResult(TextWriter t)
        {
            t.WriteLine("No. NonDom: " + "\t" + "{0}", ElististP.Count);
            for (int i = 0; i < this.ElististP.Count; i++)
            {
                for (int o = 0; o < ((DecisionVector)this.ElististP[0]).NoObj; o++)
                    t.Write(((DecisionVector)this.ElististP[i]).Objective[o].ToString() + "\t");
                t.WriteLine();

            }
            t.WriteLine("");
            t.WriteLine("Result:");
            t.WriteLine("-------");
            for (int i = 0; i < this.ElististP.Count; i++)
            {
                t.WriteLine("Elistist {0}", i);
                for (int w = 0; w < ((DecisionVector)this.ElististP[i]).Dimension; w++)
                {
                    t.WriteLine("x({0}) = {1}", w, ((DecisionVector)this.ElististP[i]).CurrentVector[w]);
                }

                FitnessValue myfitness1 = new FitnessValue();

                myfitness1.ScheduleGJSP(JD.NoJob, JD.NoMc, JD.NoOp, ((DecisionVector)this.ElististP[i]).CurrentVector, JD.Job, ((DecisionVector)this.ElististP[i]).Dimension,JD.NoOpPerMc ,JD.Machine, JD);

                for (int j = 0; j < JD.NoJob; j++)
                {
                    t.WriteLine("");
                    t.WriteLine("J{0}\t Start\t End\n", j + 1);
                    for (int k = 0; k < JD.NoOp[j]; k++)
                    {
                        t.WriteLine("{0} \t {1} \t {2} ", k + 1, JD.Job[j].Operation[k].StartTime, JD.Job[j].Operation[k].EndTime);

                    }
                } 

            }

        }
        public override double[] Objective(DecisionVector p, int trial)
        {
            double[] obj = new double[p.NoObj];
            FitnessValue myfitness = new FitnessValue();
            if (trial == 0) myfitness.ScheduleGJSP(JD.NoJob, JD.NoMc, JD.NoOp, p.CurrentVector, JD.Job, p.Dimension, JD.NoOpPerMc, JD.Machine, JD);
            if (trial == 1) myfitness.ScheduleGJSP(JD.NoJob, JD.NoMc, JD.NoOp, p.TrialVector, JD.Job, p.Dimension, JD.NoOpPerMc, JD.Machine, JD);
            objective myObjective1 = new objective();//Find the first objective
            obj[0] = myObjective1.Cmax2(JD.NoMc, JD.NoOpPerMc, JD.Machine);
            objective myObjective2 = new objective();
            obj[1] = myObjective2.TotalTardiness(JD.NoJob, JD.NoOp, JD.Job);
            return obj;
        }
    }

    class MainClass
    {
        public static void DE(double[] DEparas, int strategy, bool aniEnable, out double[] index, out ArrayList Pareto, out ArrayList Ani, out ArrayList AniS, out ArrayList Average)
        {
            // modification = criterion to join unexplored group is the range > 0.01*maxrange (excel)           
            // trap=100 steps
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
            int Dimension = 0;
            //To calculate Dimension = Sum of all NoOp 
            for (int j = 0; j < NoJob; j++)
            {
                Dimension += NoOp[j];
            }
            #endregion
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
            #region set DE parameters
            //parameter setting
            int noIter = Convert.ToInt32(DEparas[0]);
            int noVec = Convert.ToInt32(DEparas[1]);
            double FMin = DEparas[2];
            double FMax = DEparas[3];
            int noNB = Convert.ToInt32(DEparas[4]);
            double COx = DEparas[5];
            double COn = DEparas[6];
            double cL = DEparas[7];
            double cN = DEparas[8];

            int maxE = Convert.ToInt32(DEparas[9]);
            double TopEp = DEparas[10] / 100;
            double BotEp = DEparas[11] / 100;
            double GapUnexplore = DEparas[12] / 100;

            int moveStrategy = strategy;

            int rSeed = (int)DEparas[17];
            int noRep = (int)DEparas[18];
            // end parameter setting
            
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
                M2DE GlobalPop = new spM2DE(noVec, noIter, noNB, FMax, FMin, COx, COn,Dimension, JD, maxE, moveStrategy, vMix, TopEp, BotEp, GapUnexplore);
                GlobalPop.SetRSeed(rSeed);
                GlobalPop.Run(tw, true, aniEnable, AvgVal[i], out sAni, out sAni2);
                // get the finishing time from CPU clock
                finish = DateTime.Now;
                elapsed = finish - start;
                // display the elapsed time in hh:mm:ss.milli
                tw.WriteLine("{0} is the computational time", elapsed.Duration());
                tw.WriteLine("");
                if (i == 0) PFront = GlobalPop.ElististP;
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

