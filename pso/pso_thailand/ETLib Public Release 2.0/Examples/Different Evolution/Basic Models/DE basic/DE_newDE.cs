using System;
using System.IO;
using ETLib_DE_Basic;

namespace DE_lib
{	// DE for minimization problem
    class newDE : DE
    {	// this part is the problem specific code
        // Minimize f(x) = 0.001x^2 + 2*Sin(x), -100<=x<=100
        
        public newDE(int nVec, int nIter, double Fmax, double Fmin, double croRx, double croRn)
            : base(nIter, Fmax, Fmin, croRx, croRn)
        {
            base.SetDimension(nVec, 1);
            
        }
        public override void DisplayResult(TextWriter t)
        {
            t.WriteLine("");
            t.WriteLine("Result:");
            t.WriteLine("-------");
            //write position of the best vector
            for (int i = 0; i < this.Pop.Vector[this.Pop.posBest].Dimension; i++) // foreach dimension of best vector
                t.WriteLine("x({0}) = {1}", i, this.Pop.Vector[this.Pop.posBest].CurrentVector[i]);
            t.WriteLine("f(x) = {0}", this.Pop.Vector[this.Pop.posBest].Objective);
         }

        public override double Objective(DecisionVector P, int trial)
        {
            double obj = 0;
            //evaluate the objective value corresponding to the position of the Vector 
            if (trial == 0)
            {
                for (int i = 0; i < P.Dimension; i++)
                    obj += 0.001 * Math.Pow(P.CurrentVector[i], 2) + 2 * Math.Sin(P.CurrentVector[i]);
            }
            if (trial == 1)
            {
                for (int i = 0; i < P.Dimension; i++)
                    obj += 0.001 * Math.Pow(P.TrialVector[i], 2) + 2 * Math.Sin(P.TrialVector[i]);
            }  
            return obj;
        }

        public override void InitPop()
        {
            for (int i = 0; i < Pop.Member; i++) //each vector
            {
                for (int j = 0; j < Pop.Vector[i].Dimension; j++) //each dimension
                {
                    Pop.Vector[i].CurrentVector[j] = -100+200*rand.NextDouble(); //generate random number between 0 to 1                   
                    Pop.Vector[i].VecMax[j] = -100;  //set the lower bound of a position
                    Pop.Vector[i].VecMin[j] = 100;   //set the upper bound of a position
                }
                Pop.Vector[i].Objective = 1.7E308;
            }
            Pop.posBest = 0;
        }
              
    }

	class MainClass
	{
		public static void Main(string[] args)
        {
           //set DE parameters

            About.showAbout();
            int noVec = 100;
            int noIter = 100;           
            double FMax = 2;
            double FMin = 0.1;
            //double F = 2; 
            double CRx = 0.5; //max crossover rate
            double CRn = 0.5; //min crossover rate            
            string oFile = "MyDE.xls"; 
            int noRep= 10;

			// starting time and finish time using DateTime datatype
			DateTime start, finish;
			
			// elapsed time using TimeSpan datatype
			TimeSpan elapsed;

			// opening output file
			TextWriter tw = new StreamWriter(oFile);
			tw.WriteLine("{0} Number of Vector  ", noVec);
			tw.WriteLine("{0} Number of Iteration ", noIter);			
            tw.WriteLine("{0} Parameter Fmax      ", FMax);
            tw.WriteLine("{0} Parameter Fmin      ", FMin);
            //tw.WriteLine("{0} Parameter F        ", F);
			tw.WriteLine("{0} Parameter CRmax        ", CRx);
            tw.WriteLine("{0} Parameter CRmin        ", CRn);			
			tw.WriteLine("{0} Output File Name    ", oFile);
			tw.WriteLine("");
			

			for(int i=0; i<noRep; i++)
			{
				tw.WriteLine("Replication {0}", i+1);
                
				// get the starting time from CPU clock
				start = DateTime.Now;
				
				// main program ...
                DE myDE = new newDE(noVec, noIter,FMax, FMin, CRx, CRn);
                Console.WriteLine("Replication {0}", i + 1);
                myDE.Run(tw, true);

				myDE.DisplayResult(tw);
                                               				
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
