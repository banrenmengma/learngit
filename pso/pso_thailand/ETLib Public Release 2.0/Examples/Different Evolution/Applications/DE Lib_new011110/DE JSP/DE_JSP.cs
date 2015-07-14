using System;
using System.IO;
using ETLib_DE_JSP;

namespace DE_JSP
{	// DE for minimization problem
    class newDE : DE
    {	// this part is the problem specific code
        
        public JSPdata JD;   // JD, new object of newDE,in class JSPdata
        public newDE(int nVec, int nIter, int nNB, double Fmax, double Fmin, double croRx, double croRn, double dcg, double dcl, double dcn, JSPdata jd, int dim, int sRi, int Rii, int sLS, int LSi)
            : base(nIter, nNB, Fmax, Fmin, croRx, croRn, dcg, dcl, dcn, sRi, Rii, sLS, LSi)
        {
            base.SetDimension(nVec, dim);
            JD = new JSPdata(jd.NoJob, jd.NoMc, jd.NoOp, jd.Job, jd.NoOpPerMc, jd.Machine);
        }
        public override void DisplayResult(TextWriter t)
        {
            double obj = 0;

            t.WriteLine("");
            t.WriteLine("Result:");
            t.WriteLine("-------");
            for (int i = 0; i < this.Pop.Vector[this.Pop.posBest].Dimension; i++) // foreach dimension of best vector
                t.WriteLine("x({0}) = {1}", i, this.Pop.Vector[this.Pop.posBest].CurrentVector[i]);
            t.WriteLine("f(x) = {0}", this.Pop.Vector[this.Pop.posBest].Objective);

            for (int i = 0; i < this.Pop.Member; i++)//display assigned machine for each operation of the best vector
            {
                if (i == this.Pop.posBest)
                {
                    FitnessValue.FitnessValueScheduleGJSP(JD.NoJob, JD.NoMc, JD.NoOp, this.Pop.Vector[i].CurrentVector, JD.Job, this.Pop.Vector[i].Dimension, JD.NoOpPerMc, JD.Machine, JD);
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

        }

        public override double Objective(DecisionVector P, int trial)
        {
            double obj = 0;

            if (trial == 0) obj = FitnessValue.FitnessValueScheduleGJSP(JD.NoJob, JD.NoMc, JD.NoOp, P.CurrentVector, JD.Job, P.Dimension, JD.NoOpPerMc, JD.Machine, JD);
            if (trial == 1) obj = FitnessValue.FitnessValueScheduleGJSP(JD.NoJob, JD.NoMc, JD.NoOp, P.TrialVector, JD.Job, P.Dimension, JD.NoOpPerMc, JD.Machine, JD);

            return obj;
        }

        public override void InitPop()
        {
            for (int i = 0; i < Pop.Member; i++) //each vector
            {
                for (int j = 0; j < Pop.Vector[i].Dimension; j++) //each dimension
                {
                    Pop.Vector[i].CurrentVector[j] = rand.NextDouble();
                    Pop.Vector[i].Velocity[j] = 0;
                    // Pop.Vector[i].BestVector[j] = Pop.Vector[i].CurrentVector[j];
                    //Pop.Vector[i].VecMin[j] = 0;
                    //Pop.Vector[i].VecMax[j] = 1;
                }
                Pop.Vector[i].Objective = 1.7E308;
            }
            Pop.posBest = 0;
        }

        public override void ReInitPop()
        {
            for (int i = 0; i < Pop.Member; i++)
            {
                if (i != Pop.posBest)
                {
                    for (int j = 0; j < Pop.Vector[i].Dimension; j++)
                    {
                        Pop.Vector[i].CurrentVector[j] = rand.NextDouble();
                        //Pop.Vector[i].BestVector[j] = Pop.Vector[i].CurrentVector[j];

                        //sSwarm.pParticle[i].PosMin[j] = 0;
                        //sSwarm.pParticle[i].PosMax[j] = 1;
                    }
                    Pop.Vector[i].Objective = 1.7E308;
                }
            }
        }

        public override void LocalSearchVector(DecisionVector P, ref Random RandomNum)
        {
            P.CurrentVector = LocalSearch.InterExchangeCirticalPath(JD.NoJob, JD.NoMc, JD.NoOp, JD.NoOpPerMc,
                    P.Dimension, P.CurrentVector, P.Objective, JD.Machine, JD.Job, ref rand, ref JD);
            P.Objective = Objective(P, 0);

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
            int Dimension = 0; 
            //To calculate Dimension = Sum of all NoOp 
            for (int j = 0; j < NoJob; j++)
            {
                Dimension += NoOp[j];
            }            
            #endregion

            int noVec = 500;
            int noIter = 500;
            int noNB = 4;
            double FMax = 2;
            double FMin = 1.5;
            //double F = 2; // amplify
            double CRx = 0.5; //max crossover rate
            double CRn = 0.1; //min crossover rate
            double Wmax = 1;   // max weight 
            double Wmin = 0;   // min weight
            double cN = 0;   // coefficient neighbor
            string oFile = "MyDE.xls"; 
            int noRep= 2;

            int startReinit = 501;    // inidicate reinitial
            int ReInitIterval = 501;  // indicate reinitial interval 
            int startLS = 101;        // indicate LS
            int LSinterval = 101;     // indicate LS interval

			// starting time and finish time using DateTime datatype
			DateTime start, finish;
			
			// elapsed time using TimeSpan datatype
			TimeSpan elapsed;

			// opening output file
			TextWriter tw = new StreamWriter(oFile);
			tw.WriteLine("{0} Number of Vector  ", noVec);
			tw.WriteLine("{0} Number of Iteration ", noIter);
			tw.WriteLine("{0} Number of Neighbor  ", noNB);
            tw.WriteLine("{0} Parameter Fmax      ", FMax);
            tw.WriteLine("{0} Parameter Fmin      ", FMin);
            //tw.WriteLine("{0} Parameter F        ", F);
			tw.WriteLine("{0} Parameter CRmax        ", CRx);
            tw.WriteLine("{0} Parameter CRmin        ", CRn);
			tw.WriteLine("{0} Parameter cl        ", Wmin);
			tw.WriteLine("{0} Parameter cn        ", cN);
			tw.WriteLine("{0} Output File Name    ", oFile);
			tw.WriteLine("");
			

			for(int i=0; i<noRep; i++)
			{
				Console.WriteLine("Replication {0}", i+1);
				tw.WriteLine("Replication {0}", i+1);
				// get the starting time from CPU clock
				start = DateTime.Now;
				
				// main program ...
                DE myDE = new newDE(noVec, noIter, noNB, FMax, FMin, CRx, CRn, Wmax, Wmin, cN, JD, Dimension, startReinit, ReInitIterval, startLS, LSinterval);                
				myDE.Run(tw, true);

				myDE.DisplayResult(tw);
                Console.WriteLine("Obj = {0}", myDE.Pop.Vector[myDE.Pop.posBest].Objective);
                               				
				// get the finishing time from CPU clock
				finish = DateTime.Now;
				elapsed = finish - start;
				
				// display the elapsed time in hh:mm:ss.milli
				tw.WriteLine("{0} is the computational time", elapsed.Duration());
                Console.WriteLine("{0} is the computational time", elapsed.Duration());                
				tw.WriteLine("");
			}
            
			tw.Close();
		}
	}
}
