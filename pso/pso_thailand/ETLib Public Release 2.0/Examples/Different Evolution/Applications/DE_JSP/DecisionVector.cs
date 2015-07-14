using System;
using System.Collections.Generic;
using System.Text;

namespace DE_lib
{
    class DecisionVector
    {
        //define vector parameters 
        public int Dimension;     //dimension

        public int localBest;     //index of local best position
        public int selBest;       //index of select top best position

        public double[] Velocity;   //current particle velocity:PSO
        public double[] Neighbor;   //near neighbor best position:PSO


        public double[] CurrentVector;   //current  decision vector
        public double[] TrialVector;     //trial vector       

        public double Objective;     //current  objective function
        public double TrialObjective;     //trial  objective function
        // public double BestObjective;    //previous best  objective function
        public double[] VecMax;     //maximum position of vector
        public double[] VecMin;     //minimum position of vector 


        public DecisionVector(int nDim)
        {   // construct a decision vector with nDim dimension
            Dimension = nDim;
            CurrentVector = new double[Dimension];
            TrialVector = new double[Dimension];
            Velocity = new double[Dimension];
            Neighbor = new double[Dimension];
            VecMax = new double[Dimension];
            VecMin = new double[Dimension];
        }
    }
}