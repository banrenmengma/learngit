using System;
using System.IO;

namespace ETLib_DE_JSP
{
    public class DE
    {
        double Fx;    // maximum value of F      
        double Fn;    // minimum value of F

        double X;
        double coRx;    //maximun crossover propability
        double coRn;    // minimum crossover propability

        double Wx;
        double Wn;
        
        int Iter;     //number of iteration
        int nVec; 	  //number of vector
        int nDim;     //number of dimension
        int NB;       //number of neighbors

        int startReinit;
        int ReInitIterval;
        int startLS;
        int LSiterval;

        public Population Pop;
        public Random rand = new Random();
        
        public DE(int nIter, int nNB, double Fmax, double Fmin, double croRx, double croRn,double Wmax, double Wmin, double dcn,int Ristart, int Rii, int LSsstart, int LSi)
        {
            Iter = nIter;
            NB = nNB;
            Fx = Fmax;
            Fn = Fmin;
            coRx = croRx;
            coRn = croRn;
            Wx = Wmax;
            Wn = Wmin;
            
            startReinit = Ristart;
            ReInitIterval = Rii;
            startLS = LSsstart;
            LSiterval = LSi;
        }

        public virtual void InitPop()
        {	//swarm initialization 
            for (int i = 0; i < Pop.Member; i++)
            {
                for (int j = 0; j < Pop.Vector[i].Dimension; j++)
                {
                    Pop.Vector[i].CurrentVector[j] = rand.NextDouble();                    
                }

                Pop.Vector[i].Objective = 1.7E308;
            }

            Pop.posBest = 0;
        }

        public virtual void ReInitPop()
        {	//swarm initialization
            for (int i = 0; i < Pop.Member; i++)
            {
                if (i != Pop.posBest)// reinitialize all members accept for the best individual
                {
                    for (int j = 0; j < Pop.Vector[i].Dimension; j++)
                    {
                        Pop.Vector[i].CurrentVector[j] = rand.NextDouble();
                        //Pop.Vector[i].BestVector[j] = Pop.Vector[i].CurrentVector[j];
                    }

                    Pop.Vector[i].Objective = 1.7E308;
                }
            }
        }
        public void SetDimension(int vec, int dim)
        {	//set swarm members and particle dimensions
            nVec = vec;
            nDim = dim;
        }

        public void Run(TextWriter t, bool debug)
        {	//DE main iteration

            //double F = Fn;
            double diff = Fx - Fn;
            double decrF = (Fx - Fn) / Iter;
            double coR = coRn;
            double decrCr = (coRx - coRn) / Iter;
            //double Weight = Wn;
            //double decrW = (Wx - Wn) / Iter;

            Pop = new Population(nVec, nDim);
            InitPop();
            Evaluate();
            Pop.UpdateBest(NB);
            //Pop.SortingObjective();

            if (debug)
            {
                Pop.EvalDispersion();
                Pop.EvalStatObj();
                t.WriteLine("{0} \t {1}  \t {2}  \t {3} \t  {4}  \t {5} \t  {6}", 0, Pop.posBest, Pop.Vector[Pop.posBest].Objective, Pop.Dispersion, Pop.AvgObj, Pop.MinObj, Pop.MaxObj);
            }

            for (int i = 1; i < Iter; i++)
            {
                double F = Fn + rand.NextDouble() * diff; // F is changes every iteration           
                
                bool reinit_locals = false;
                if (((i - startLS) % LSiterval == 0) && (i >= startLS)) //check condition for LS
                {
                    for (int j = 0; j < Pop.Member; j++) //do local search for each member
                        LocalSearchVector(Pop.Vector[j], ref rand);
                    reinit_locals = true;
                }
                if (((i - startReinit) % ReInitIterval == 0) && (i >= startReinit)) //check condition for reinitialize
                {
                    ReInitPop();
                    reinit_locals = true;
                }

                if (reinit_locals)//if LS or reinitial condition is met , then not evolve, but update the solution
                {
                    Evaluate();
                    Pop.UpdateBest(NB);
                    //Pop.SortingObjective();
                }
                
                if (!reinit_locals)// if not perform LS or reinitial, then evolve, evaluate trial vector, selection, and update solution
                {
                    for (int m = 0; m < Pop.Member; m++)
                    {
                        Pop.Evole(m,F, coR, rand);
                        EvaluateTrial(m);
                        Pop.Selection(m);
                    }                  
                    
                    Pop.UpdateBest(NB);
                    //Pop.SortingObjective();
                }                 
                
                if (debug)
                {
                    Pop.EvalDispersion();
                    Pop.EvalStatObj();
                    t.WriteLine("{0} \t {1} \t {2}  \t {3}  \t {4}  \t {5}  \t {6}", i, Pop.posBest, Pop.Vector[Pop.posBest].Objective, Pop.Dispersion, Pop.AvgObj, Pop.MinObj, Pop.MaxObj);
                }
                //F -= decrF;    
                coR += decrCr;
                //Weight += decrW;
            }                     
                   

        }        

        void Evaluate()
        {	//evaluate objective function value of each  member
            for (int j = 0; j < Pop.Member; j++)
                Pop.Vector[j].Objective = Objective(Pop.Vector[j],0);
        }
        void EvaluateTrial(int M)
        {	//evaluate objective function value of each  member            
                Pop.Vector[M].TrialObjective = Objective(Pop.Vector[M], 1);
        }

        public virtual double Objective(DecisionVector p,int trial)
        {	//empty function to be override in the problem specific definition
            //to calculate objective function of a particle
            return 0;
        }

        public virtual void LocalSearchVector(DecisionVector p, ref Random rnd)
        {
        }

        public virtual void DisplayResult(TextWriter t)
        {	//empty function to be override in the problem specific definition
            //to display the result
            t.Write("the result is ...");
        }
    }
}
