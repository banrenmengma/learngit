using System;
using System.Collections.Generic;
using System.Text;

namespace ETLib_DE_JSP
{
    public class Population
    {        
        public int Member;			//number of population member
        public int posBest;			//index of best vector in the population
        //public int localBest;       //index of local best vector
        //public int selBest;         //index of selected best vectors in the population  
        
        public double Dispersion;   //dispersion index of the population
        public double VelIndex;		//velocity index of the swarm:PSO
        public double MaxObj;		//maximum objective function of the population
        public double MinObj;		//minimum objective function of the population
        public double AvgObj;		//average objective function of the population

        public int[] lBestVectorIndex;      // local best decision vector index
        public int[] sBestVectorIndex;      // select best decision vector index

        //definition array of vector
        public DecisionVector[] Vector;

        public Population(int nVec, int nDim)
        {   // construct a population with nVec vector,
            // each vector with nDim dimension
            Member = nVec;
            Vector = new DecisionVector[Member]; // declare size of Vector (array)

            lBestVectorIndex = new int[Member];
            sBestVectorIndex = new int[Member];

            for (int i = 0; i < Member; i++)
            {	//Initialize vectors and each vector has nDim dimension
                Vector[i] = new DecisionVector(nDim);
            }
        }

        public void randomtrialvector(DecisionVector v) 
            // diff way to generate new vector
        {
            Random rnd = new Random();
            for (int i = 0; i < v.Dimension; i++)
            {
                v.TrialVector[i] = rnd.NextDouble();
            }
        }
        
            //1. DE/rand/1 scheme
        public void d_evole_r_1(DecisionVector v, DecisionVector v1, DecisionVector v2, DecisionVector v3, double F)
            {            
                for (int i = 0; i < v.Dimension; i++)
                {                    
                    v.TrialVector[i] = v1.CurrentVector[i] + F * (v2.CurrentVector[i] - v3.CurrentVector[i]);                    
                }             
        }
            //2.DE/current to best/1 scheme
        public void d_evolve_rand_best_1(DecisionVector v,DecisionVector vbest,DecisionVector v2, DecisionVector v3, double F, double X )
           
        {            
            for (int i = 0; i < v.Dimension; i++) 
            {
                v.TrialVector[i] = v.CurrentVector[i] + X * (vbest.CurrentVector[i] - v.CurrentVector[i])+ F * (v2.CurrentVector[i] - v3.CurrentVector[i]);
            }
        }

            //2.1 DE/current to selbest/1 scheme
        public void d_evolve_rand_selbest_1(DecisionVector v, DecisionVector sbest, DecisionVector v2, DecisionVector v3, double F, double X)
        {
            for (int i = 0; i < v.Dimension; i++)
            {
                v.TrialVector[i] = v.CurrentVector[i] + X * (sbest.CurrentVector[i] - v.CurrentVector[i]) + F * (v2.CurrentVector[i] - v3.CurrentVector[i]);
            }
        }
            //3.DE/best/1 scheme
        public void d_evolve_best_1(DecisionVector v,DecisionVector vbest, DecisionVector v1, DecisionVector v2, double F, double X)            
        {            
            for (int i = 0; i < v.Dimension; i++)
            {
                v.TrialVector[i] = vbest.CurrentVector[i]+ F *(v1.CurrentVector[i] - v2.CurrentVector[i]);
            }
        }

            //3.1 DE/selbest/1 scheme
        public void d_evolve_selbest_1(DecisionVector v, DecisionVector sbest, DecisionVector v1, DecisionVector v2, double F, double X)
        {
            for (int i = 0; i < v.Dimension; i++)
            {
                v.TrialVector[i] = sbest.CurrentVector[i] + F * (v1.CurrentVector[i] - v2.CurrentVector[i]);
            }
        }
            //4.DE/best/2 scheme
        public void d_evolve_best_2(DecisionVector v, DecisionVector vbest, DecisionVector v1, DecisionVector v2, DecisionVector v3, DecisionVector v4, double F)
            
        {
            for (int i = 0; i < v.Dimension; i++)
            {
                v.TrialVector[i] = vbest.CurrentVector[i] + F*(v1.CurrentVector[i] + v2.CurrentVector[i] - v3.CurrentVector[i] - v4.CurrentVector[i]);
            }
        }

            //4.1DE/selbest/2 scheme
        public void d_evolve_selbest_2(DecisionVector v, DecisionVector sbest, DecisionVector v1, DecisionVector v2, DecisionVector v3, DecisionVector v4, double F)
        {
            for (int i = 0; i < v.Dimension; i++)
            {
                v.TrialVector[i] = sbest.CurrentVector[i] + F * (v1.CurrentVector[i] + v2.CurrentVector[i] - v3.CurrentVector[i] - v4.CurrentVector[i]);
            }
        }
            //5.DE/rand/2 scheme
        public void d_evolve_rand_2(DecisionVector v, DecisionVector v1, DecisionVector v2, DecisionVector v3, DecisionVector v4, DecisionVector v5, double F)
            
        {
            for (int i = 0; i < v.Dimension; i++)
            {
                v.TrialVector[i] = v1.CurrentVector[i] + F*(v2.CurrentVector[i]-v3.CurrentVector[i])+ F*(v4.CurrentVector[i]-v5.CurrentVector[i]);
            }
        }

            //6.DE/current to localBest/1 scheme
        public void d_evolve_rand_localBest_1(DecisionVector v, DecisionVector lbest,DecisionVector v2, DecisionVector v3, double F, double X)
        {
            for (int i = 0; i < v.Dimension; i++)
            {
                v.TrialVector[i] = v.CurrentVector[i] + X * (lbest.CurrentVector[i] - v.CurrentVector[i]) + F * (v2.CurrentVector[i] - v3.CurrentVector[i]);
            }
        }

            //7.DE/localBest/1 scheme
        public void d_evolve_localBest_1(DecisionVector v, DecisionVector lbest, DecisionVector v1, DecisionVector v2, double F, double X)
        {
            
            for (int i = 0; i < v.Dimension; i++)
            {
                v.TrialVector[i] = lbest.CurrentVector[i]+ F * (v1.CurrentVector[i] - v2.CurrentVector[i]);
            }
        }

            //8. combine linear weight between randtolocalBest and randtoselBest
        public void d_evolve_rand_localBest_TO_rand_selBest(DecisionVector v, DecisionVector lbest, DecisionVector sbest, DecisionVector v1, DecisionVector v2, DecisionVector v3, DecisionVector v4, double X,double F, double W)
        {                        
            for (int i = 0; i < v.Dimension; i++)
            {
                v.TrialVector[i] = (1 - W) * (v.CurrentVector[i] + X * (lbest.CurrentVector[i] - v.CurrentVector[i]) + F * (v2.CurrentVector[i] - v3.CurrentVector[i])) + W * (v.CurrentVector[i] + X * (sbest.CurrentVector[i] - v.CurrentVector[i]) + F * (v2.CurrentVector[i] - v3.CurrentVector[i]));
            }
        }

        //9. combine linear weight between randtolocalBest and randtoBest
        public void d_evolve_rand_localBest_TO_rand_to_Best(DecisionVector v, DecisionVector lbest, DecisionVector vbest, DecisionVector v1, DecisionVector v2, DecisionVector v3, DecisionVector v4, double X, double F, double W)
        {

            for (int i = 0; i < v.Dimension; i++)
            {
                v.TrialVector[i] = (1 - W) * (v.CurrentVector[i] + X * (lbest.CurrentVector[i] - v.CurrentVector[i]) + F * (v2.CurrentVector[i] - v3.CurrentVector[i])) + W * (v.CurrentVector[i] + X * (vbest.CurrentVector[i] - v.CurrentVector[i]) + F * (v2.CurrentVector[i] - v3.CurrentVector[i]));
            }

        }
        
        //10. combine linear weight between selbest/1 to rand/1
        public void d_evolve_selbest_to_rand_1(DecisionVector v, DecisionVector sbest, DecisionVector v1, DecisionVector v2, DecisionVector v3, DecisionVector v4, DecisionVector v5, double F,double W)
        {
            for (int i = 0; i < v.Dimension; i++)
            {
                v.TrialVector[i] = (1-W) * (sbest.CurrentVector[i] + F * (v1.CurrentVector[i] - v2.CurrentVector[i])) + W * (v3.CurrentVector[i] + F * (v4.CurrentVector[i] - v5.CurrentVector[i]));

            }    
        }       
        //11. combine linear weight between randtolocalbest to rand/1
        public void d_evolve_randtolocalbest_to_rand_1(DecisionVector v, DecisionVector lbest, DecisionVector v1, DecisionVector v2, DecisionVector v3, DecisionVector v4, DecisionVector v5, double F,double X ,double W)
        {
            for (int i = 0; i < v.Dimension; i++)
            {
                v.TrialVector[i] = (1 - W) * (lbest.CurrentVector[i] + X * (lbest.CurrentVector[i] - v.CurrentVector[i]) + F * (v1.CurrentVector[i] - v2.CurrentVector[i])) + W * (v3.CurrentVector[i] + F * (v4.CurrentVector[i] - v5.CurrentVector[i]));

            }
        }

        //12. combine linear weight between localbest to rand/1
        public void d_evolve_rand1_to_localbest(DecisionVector v, DecisionVector lbest, DecisionVector v1, DecisionVector v2, DecisionVector v3, DecisionVector v4, DecisionVector v5, double F, double X, double W)
        {
            for (int i = 0; i < v.Dimension; i++)
            {
                v.TrialVector[i] = W * lbest.CurrentVector[i] + (1 - W) * v1.CurrentVector[i] + F * (v1.CurrentVector[i] - v2.CurrentVector[i]);

            }
        }

        public void Crossover_1point(DecisionVector v, double coRate, Random rnd)
        {
            for (int i = 0; i < v.Dimension; i++) // consider each dimension เลยนะ
            {
                if (rnd.NextDouble() >= coRate)
                {
                    v.TrialVector[i] = v.CurrentVector[i];
                }
            }
        }
        public void Crossover_2point(DecisionVector v, double coRate, Random rnd)
        {
            int start_p = rnd.Next(v.Dimension);
            int L = 0;
            do
                L++;
            while ((rnd.NextDouble() <= coRate) && (start_p + L <v.Dimension));
            for (int i = start_p; i < start_p+L; i++)
            {
                v.TrialVector[i] = v.CurrentVector[i];
            }
        }
        public void Evole(int M ,double F,double coRate,Random rnd)
        {	//evole population ...            
                              
                int r1 = rnd.Next(Member); 
                int r2 = 0; 
                int r3 = 0;
                int r4 = 0;
                int r5 = 0;
                double X = 0.2;                
                
                do r2 = rnd.Next(Member); while (r2 == r1);
                do r3 = rnd.Next(Member); while ((r3 == r1) || (r3 == r2));
                do r4 = rnd.Next(Member); while ((r4 == r1) || (r4 == r2) || (r4 == r3));
                do r5 = rnd.Next(Member); while ((r5 == r1) || (r5 == r2) || (r5 == r3) || (r5 == r4));

                //selection of mutation strategy
                //randomtrailvector(Vector[i]); // generate new random vector (replacing mutant vector)
                d_evole_r_1(Vector[M], Vector[r1], Vector[r2], Vector[r3], F);
                //d_evolve_rand_best_1(Vector[M], Vector[posBest],Vector[r2], Vector[r3], F,X );
                //d_evolve_rand_selbest_1(Vector[M], Vector[sBestVectorIndex[i]], Vector[r2], Vector[r3], F, X);
                //d_evolve_best_1(Vector[M], Vector[posBest],Vector[r1], Vector[r2], F);
                //d_evolve_selbest_1(Vector[M], Vector[sBestVectorIndex[i]],Vector[r1], Vector[r2], F);
                //d_evolve_best_2(Vector[M], Vector[posBest], Vector[r1], Vector[r2], Vector[r3], Vector[r4], F);
                //d_evolve_selbest_2(Vector[M], Vector[sBestVectorIndex[i]], Vector[r1], Vector[r2], Vector[r3], Vector[r4], F);
                //d_evolve_rand_2(Vector[M], Vector[r1], Vector[r2], Vector[r3], Vector[r4], Vector[r5], F);
                //d_evolve_rand_localBest_1(Vector[M], Vector[lBestVectorIndex[M]], Vector[r2], Vector[r3], F, X);
                //d_evolve_localBest_1(Vector[M], Vector[lBestVectorIndex[M]], Vector[r1], Vector[r2], F,X);
                //d_evolve_rand_localBest_TO_rand_selBest(Vector[M],Vector[lBestVectorIndex[M]],Vector[sBestVectorIndex[M]],Vector[r1],Vector[r2],Vector[r3],Vector[r4], X, F, Weight);
                //d_evolve_rand_localBest_TO_rand_to_Best(Vector[M], Vector[lBestVectorIndex[M]], Vector[posBest], Vector[r1], Vector[r2], Vector[r3], Vector[r4], X, F, Weight);
                //d_evolve_selbest_to_rand_1(Vector[M], Vector[sBestVectorIndex[M]], Vector[r1], Vector[r2], Vector[r3], Vector[r4], Vector[r5], F, Weight);
                //d_evolve_randtolocalbest_to_rand_1(Vector[M], Vector[lBestVectorIndex[M]], Vector[r1], Vector[r2], Vector[r3], Vector[r4], Vector[r5], F, X, Weight);
                //d_evolve_rand1_to_localbest(Vector[M], Vector[lBestVectorIndex[M]], Vector[r1], Vector[r2], Vector[r3], Vector[r4], Vector[r5], F, X, Weight);

                // selection of crossover operation
                //Crossover_1point(Vector[M], coRate, rnd);
                Crossover_2point(Vector[M], coRate, rnd);            
                               
        }
               

       public void Selection(int M) // compare solutions between target and trial vector
        {            
                if (Vector[M].TrialObjective < Vector[M].Objective)
                {
                    Vector[M].Objective = Vector[M].TrialObjective;
                    Array.Copy(Vector[M].TrialVector, Vector[M].CurrentVector, Vector[M].Dimension);                    
                }            
        }     

        public void UpdateBest(int nbSize)
        {	//updating cognitive and social information 

            int l_temp, n_temp;
            double FDR;
            double FDRBest;

            //update personal best: not useful for DE cuz DE always yeild better solutions, best obj. is the lastest obj.
            /*for (int i = 0; i < Member; i++)
            {
                if (Vector[i].Objective < Vector[i].Objective)
                {
                    Vector[i].Objective = Vector[i].Objective;
                   // for (int j = 0; j < Vector[i].Dimension; j++)
                      //  Vector[i].BestVector[j] = Vector[i].CurrentVector[j];
                }
            }*/

            //update global best
            for (int i = 0; i < Member; i++)
                if (Vector[i].Objective < Vector[posBest].Objective)
                    posBest = i;

            
            //update local best
            for (int i = 0; i < Member; i++)
            {
                Vector[i].localBest = i;

                for (int j = i - nbSize / 2; j <= i + nbSize / 2; j++) //each member in its local
                {
                    l_temp = j;
                    if (i == j)
                        continue;
                    if (l_temp < 0)
                        l_temp += Member;
                    if (l_temp >= Member)
                        l_temp -= Member;
                    if (Vector[l_temp].Objective < Vector[Vector[i].localBest].Objective)                    
                        Vector[i].localBest = l_temp;                   
                }
                    lBestVectorIndex[i] = Vector[i].localBest;
            }

            //update near neighbor best
            /*
            for (int i = 0; i < Member; i++)
            {
                for (int j = 0; j < Vector[i].Dimension; j++)
                {
                    if (i == 0)
                        n_temp = 1;
                    else
                        n_temp = 0;

                    FDRBest = (Vector[i].Objective - Vector[n_temp].BestObjective) / Math.Abs(Vector[i].CurrentVector[j] - Vector[n_temp].BestVector[j]);

                    for (int k = 0; k < Member; k++)
                    {
                        if (i == k) continue;
                        FDR = (Vector[i].Objective - Vector[k].BestObjective) / Math.Abs(Vector[i].CurrentVector[j] - Vector[k].BestVector[j]);
                        if (FDR > FDRBest)
                        {
                            n_temp = k;
                            FDRBest = FDR;
                        }
                    }
                    Vector[i].Neighbor[j] = Vector[n_temp].BestVector[j];
                }
            }
              */
            /*
            //Sorting obective and update selBest

            double[] z = new double[Member];
            Random rnd = new Random();
            int nobest = 50;
            int[] pos = new int[Member];	//Create Dimension Array to be sorted.
            for (int i = 0; i < Member; i++)
            {
                pos[i] = i;  // Determine index of position array
                z[i] = Vector[i].Objective;
            }
            Array.Sort(z, pos); //sort according to objective value from min to max

            for (int j = 0; j < Member; j++)//assign "selbest vector" for each individual
            {
                int b = rnd.Next(0, nobest);
                Vector[j].selBest = pos[b];
                sBestVectorIndex[j] = Vector[j].selBest;
            }*/
        }

        public void DisplayBest()
        {	//display the best particle

            Console.Write("\n");
            Console.Write("Best Particle in the Swarm\n");
            Console.Write("--------------------------\n");
            Console.Write("position:\n");
            Console.Write("---------\n");
            for (int j = 0; j < Vector[posBest].Dimension; j++)
            {
                Console.Write("dimension {0}: {1}\n", j, Vector[posBest].CurrentVector[j]);
            }
            Console.Write("---------\n");
            Console.Write("objective: {0}\n", Vector[posBest].Objective);

        }

        public void EvalDispersion()
        {	//evaluate dispersion index

            double result = 0;
            for (int i = 0; i < this.Member; i++)
            {
                for (int j = 0; j < this.Vector[i].Dimension; j++)
                {
                    result += System.Math.Abs(this.Vector[i].CurrentVector[j] - this.Vector[this.posBest].CurrentVector[j]);
                }
            }
            this.Dispersion = result / this.Member / this.Vector[0].Dimension;
        }

        public void EvalVelIndex()
        {	//evaluate velocity index

            double result = 0;
            for (int i = 0; i < this.Member; i++)
                for (int j = 0; j < this.Vector[i].Dimension; j++)
                    result += System.Math.Abs(this.Vector[i].Velocity[j]);

            this.VelIndex = result / this.Member / this.Vector[0].Dimension;
        }

        public void EvalStatObj()
        {	//evaluate swarm's objective function statistic

            MaxObj = -1.7E308;
            MinObj = 1.7E308;
            AvgObj = 0;

            for (int i = 0; i < this.Member; i++)
            {
                if (MaxObj < this.Vector[i].Objective)
                    MaxObj = this.Vector[i].Objective;
                if (MinObj > this.Vector[i].Objective)
                    MinObj = this.Vector[i].Objective;
                AvgObj += this.Vector[i].Objective;
            }
            AvgObj /= this.Member;
        }
        
    }
}
