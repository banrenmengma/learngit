using System;
using System.Collections.Generic;
using System.Text;
using ETLib_MODE;

namespace DE_MultiObjective
{
    class Function
    {
        public static void ZDT6_Function(DecisionVector V, double[] obj, int trial) //range [0,1], optimal range x1=[0,1],xi=0 for other i
        {
            int n = 10;
            double[] var = new double[n];
            if (trial == 0)
            {
                for (int j = 0; j < n; j++)
                {
                    var[j] = V.CurrentVector[j];
                    obj[1] += var[j];
                }

                obj[1] = 1 + 9 * Math.Pow((obj[1] - var[0]) / (n - 1), 0.25);
                obj[0] = 1 - Math.Exp(-4 * var[0]) * Math.Pow(Math.Sin(6 * Math.PI * var[0]), 6);
                obj[1] = obj[1] * (1 - Math.Pow(obj[0] / obj[1], 2));
            }
            if (trial == 1)
            {
                for (int j = 0; j < n; j++)
                {
                    var[j] = V.TrialVector[j];
                    obj[1] += var[j];
                }

                obj[1] = 1 + 9 * Math.Pow((obj[1] - var[0]) / (n - 1), 0.25);
                obj[0] = 1 - Math.Exp(-4 * var[0]) * Math.Pow(Math.Sin(6 * Math.PI * var[0]), 6);
                obj[1] = obj[1] * (1 - Math.Pow(obj[0] / obj[1], 2));
            }

        }

        public static void ZDT4_Function(DecisionVector V, double[] obj, int trial) //range [0,1], optimal range x1=[0,1],xi=0 for other i
        {
            int n = 10;
            double[] var = new double[n];
            if (trial == 0)
            {
                var[0] = V.CurrentVector[0];
                for (int j = 1; j < n; j++)
                {
                    var[j] = V.CurrentVector[j];
                    obj[1] += (Math.Pow(var[j], 2) - 10 * Math.Cos(4 * Math.PI * var[j]));
                }
                obj[1] = 1 + 10 * (n - 1) + obj[1];
                obj[1] = obj[1] * (1 - Math.Sqrt(var[0] / obj[1]));
                obj[0] = var[0];
            }
            if (trial == 1)
            {
                var[0] = V.TrialVector[0];
                for (int j = 1; j < n; j++)
                {
                    var[j] = V.TrialVector[j];
                    obj[1] += (Math.Pow(var[j], 2) - 10 * Math.Cos(4 * Math.PI * var[j]));
                }
                obj[1] = 1 + 10 * (n - 1) + obj[1];
                obj[1] = obj[1] * (1 - Math.Sqrt(var[0] / obj[1]));
                obj[0] = var[0];
            }
        }

        public static void ZDT3_Function(Random rnd, double[] obj) //range [0,1], optimal range x1=[0,1],xi=0 for other i
        {
            int n = 30;
            double[] var = new double[n];
            for (int j = 0; j < n; j++)
            {
                var[j] = rnd.NextDouble();
                obj[1] += var[j];
            }
            obj[1] = 1 + 9 * (obj[1] - var[0]) / (n - 1);
            obj[1] = obj[1] * (1 - Math.Sqrt(var[0] / obj[1]) - var[0] / obj[1] * Math.Sin(10 * Math.PI * var[0]));
            obj[0] = var[0];
        }
        public static void ZDT3_Function(DecisionVector v, double[] obj, int trial) //range [0,1], optimal range x1=[0,1],xi=0 for other i
        {
            int n = 30;
            double[] var = new double[n];
            if (trial == 0)
            {
                for (int j = 0; j < n; j++)
                {
                    var[j] = v.CurrentVector[j];
                    obj[1] += var[j];
                }
                obj[1] = 1 + 9 * (obj[1] - var[0]) / (n - 1);
                obj[1] = obj[1] * (1 - Math.Sqrt(var[0] / obj[1]) - var[0] / obj[1] * Math.Sin(10 * Math.PI * var[0]));
                obj[0] = var[0];
            }
            if (trial == 1)
            {
                for (int j = 0; j < n; j++)
                {
                    var[j] = v.TrialVector[j];
                    obj[1] += var[j];
                }
                obj[1] = 1 + 9 * (obj[1] - var[0]) / (n - 1);
                obj[1] = obj[1] * (1 - Math.Sqrt(var[0] / obj[1]) - var[0] / obj[1] * Math.Sin(10 * Math.PI * var[0]));
                obj[0] = var[0];
            }
        }

        public static void ZDT2_Function(DecisionVector V,double[] obj, int trial) //range [0,1], optimal range x1=[0,1],xi=0 for other i
        {
            int n = 30;
            double[] var = new double[n];
            if (trial == 0)
            {
                for (int j = 0; j < n; j++)
                {
                    var[j] = V.CurrentVector[j];
                    obj[1] += var[j];
                }
                obj[1] = 1 + 9 * (obj[1] - var[0]) / (n - 1);
                obj[1] = obj[1] * (1 - Math.Pow(var[0] / obj[1], 2));
                obj[0] = var[0];
            }
            if (trial == 1)
            {
                for (int j = 0; j < n; j++)
                {
                    var[j] = V.TrialVector[j];
                    obj[1] += var[j];
                }
                obj[1] = 1 + 9 * (obj[1] - var[0]) / (n - 1);
                obj[1] = obj[1] * (1 - Math.Pow(var[0] / obj[1], 2));
                obj[0] = var[0];
            }
        }

        public static void ZDT1_Function(DecisionVector v, double[] obj, int trial) //range [0,1], optimal range x1=[0,1],xi=0 for other i
        {
            int n = 30;
            double[] var = new double[n];
            if (trial == 0)
            {
                for (int j = 0; j < n; j++)
                {
                    var[j] = v.CurrentVector[j];
                    obj[1] += var[j];
                }
                obj[1] = 1 + 9 * (obj[1] - var[0]) / (n - 1);
                obj[1] = obj[1] * (1 - Math.Sqrt(var[0] / obj[1]));
                obj[0] = var[0];
            }
            if (trial == 1)
            {
                for (int j = 0; j < n; j++)
                {
                    var[j] = v.TrialVector[j];
                    obj[1] += var[j];
                }
                obj[1] = 1 + 9 * (obj[1] - var[0]) / (n - 1);
                obj[1] = obj[1] * (1 - Math.Sqrt(var[0] / obj[1]));
                obj[0] = var[0];
            }
        }

        private static void FON_Function(Random rnd, double[] obj) //range [-4,4], optimal range x1=x2=x3 in [-1/sqrt(3),1/sqrt(3)]
        {
            double[] var = new double[3];

            for (int j = 0; j < 3; j++)
            {
                var[j] = -4 + 8 * rnd.NextDouble();
                obj[0] += Math.Pow(var[j] - 1 / Math.Sqrt(3), 2);
                obj[1] += Math.Pow(var[j] + 1 / Math.Sqrt(3), 2);
            }
            obj[0] = 1 - Math.Exp(-obj[0]);
            obj[1] = 1 - Math.Exp(-obj[1]);
        }
        public static void KUR_Function(DecisionVector v, double[] obj,int trial) // range [-10e2,10e2], optimal range [0,2]
        {
            double[] var  = new double[3];
            if (trial == 0)
            {
                for (int i = 0; i < v.Dimension; i++)
                    var[i] = v.CurrentVector[i];
                for (int j = 0; j < 3; j++)
                {
                    if (j < 2) obj[0] += -10 * Math.Exp(-0.2 * Math.Sqrt(Math.Pow(var[j], 2) + Math.Pow(var[j + 1], 2)));
                    obj[1] += Math.Pow(Math.Abs(var[j]), 0.8) + 5 * Math.Sin(Math.Pow(var[j], 3));
                }
            }
            if (trial == 1)
            {
                for (int i = 0; i < v.Dimension; i++)
                    var[i] = v.TrialVector[i];
                for (int j = 0; j < 3; j++)
                {
                    if (j < 2) obj[0] += -10 * Math.Exp(-0.2 * Math.Sqrt(Math.Pow(var[j], 2) + Math.Pow(var[j + 1], 2)));
                    obj[1] += Math.Pow(Math.Abs(var[j]), 0.8) + 5 * Math.Sin(Math.Pow(var[j], 3));
                }
            }
        }
        public static void SCH_Function(DecisionVector v, double[] obj, int trial) // range [-10e2,10e2], optimal range [0,2]
        {             
            if (trial == 0)
            {
                double var = v.CurrentVector[0];
                obj[0] = Math.Pow(var, 2);
                obj[1] = Math.Pow(var - 2, 2);
            }
            if (trial == 1)
            {
                double var = v.TrialVector[0];
                obj[0] = Math.Pow(var, 2);
                obj[1] = Math.Pow(var - 2, 2);
            }
        }
        public static void TNK_Function(DecisionVector v, double[] obj, int trial) // range [-10e2,10e2], optimal range [0,2]
        {
            double[] var = new double[3];
            if (trial == 0)
            {
                var[0] = v.CurrentVector[0];
                var[1] = v.CurrentVector[1];
                v.inFeasible = 0;
                obj[0] = var[0];
                obj[1] = var[1];
                if ((-Math.Pow(var[0], 2) - Math.Pow(var[1], 2) + 1 + 0.1 * Math.Cos(16 * Math.Atan(var[0] / var[1])) > 0) || (var[1] == 0)) obj[2]++;
                if (Math.Pow(var[0] - 0.5, 2) + Math.Pow(var[1] - 0.5, 2) > 0.5) obj[2]++;
                v.inFeasible = (int)obj[2];
            }
            if (trial == 1)
            {
                var[0] = v.TrialVector[0];
                var[1] = v.TrialVector[1];
                v.inFeasible = 0;
                obj[0] = var[0];
                obj[1] = var[1];
                if ((-Math.Pow(var[0], 2) - Math.Pow(var[1], 2) + 1 + 0.1 * Math.Cos(16 * Math.Atan(var[0] / var[1])) > 0) || (var[1] == 0)) obj[2]++;
                if (Math.Pow(var[0] - 0.5, 2) + Math.Pow(var[1] - 0.5, 2) > 0.5) obj[2]++;
                v.inFeasible = (int)obj[2];
            }
        }
        public static void SRN_Function(DecisionVector v, double[] obj, int trial) // range [-10e2,10e2], optimal range [0,2]
        {
            double[] var = new double[2];
            if (trial == 0)
            {
                var[0] = v.CurrentVector[0];
                var[1] = v.CurrentVector[1];
                v.inFeasible = 0;
                obj[0] = Math.Pow(var[0] - 2, 2) + Math.Pow(var[1] - 1, 2) + 2;
                obj[1] = 9 * var[0] - Math.Pow(var[1] - 1, 2);
                if (Math.Pow(var[0], 2) + Math.Pow(var[1], 2) > 225) obj[2]++;
                if (var[0] - 3 * var[1] > -10) obj[2]++;
                v.inFeasible = (int)obj[2];
            }
            if (trial == 1)
            {
                var[0] = v.TrialVector[0];
                var[1] = v.TrialVector[1];
                v.inFeasible = 0;
                obj[0] = Math.Pow(var[0] - 2, 2) + Math.Pow(var[1] - 1, 2) + 2;
                obj[1] = 9 * var[0] - Math.Pow(var[1] - 1, 2);
                if (Math.Pow(var[0], 2) + Math.Pow(var[1], 2) > 225) obj[2]++;
                if (var[0] - 3 * var[1] > -10) obj[2]++;
                v.inFeasible = (int)obj[2];
            }
        }
        public static void CONSTR_Function(DecisionVector v, double[] obj, int trial) // range [-10e2,10e2], optimal range [0,2]
        {
            double[] var=new double[2];
            if (trial == 0)
            {
                var[0] = v.CurrentVector[0];
                var[1] = v.CurrentVector[1];
                v.inFeasible = 0;
                obj[0] = var[0];
                obj[1] = (1 + var[1]) / var[0];
                if (var[1] + 9 * var[0] < 6) obj[2]++;
                if (-var[1] + 9 * var[0] < 1) obj[2]++;
                v.inFeasible = (int)obj[2];
            }
            if (trial == 1)
            {
                var[0] = v.TrialVector[0];
                var[1] = v.TrialVector[1];
                v.inFeasible = 0;
                obj[0] = var[0];
                obj[1] = (1 + var[1]) / var[0];
                if (var[1] + 9 * var[0] < 6) obj[2]++;
                if (-var[1] + 9 * var[0] < 1) obj[2]++;
                v.inFeasible = (int)obj[2];
            }
        }
        public static void KITA_Function(DecisionVector v, double[] obj, int trial) // range [0,inf], optimal range [0,2]
        {
            double[] var = new double[2];
            if (trial == 0)
            {
                var[0] = v.CurrentVector[0];
                var[1] = v.CurrentVector[1];
                v.inFeasible = 0;
                obj[0] = -Math.Pow(var[0], 2) + var[1];
                obj[1] = var[0] / 2 + var[1] + 1;
                if (var[0] / 6 + var[1] < 13 / 2) obj[2]++;
                if (var[0] / 2 + var[1] < 15 / 2) obj[2]++;
                if (5 * var[0] + var[1] < 30) obj[2]++;
                v.inFeasible = (int)obj[2];
            }
            if (trial == 1)
            {
                var[0] = v.TrialVector[0];
                var[1] = v.TrialVector[1];
                v.inFeasible = 0;
                obj[0] = -Math.Pow(var[0], 2) + var[1];
                obj[1] = var[0] / 2 + var[1] + 1;
                if (var[0] / 6 + var[1] < 13 / 2) obj[2]++;
                if (var[0] / 2 + var[1] < 15 / 2) obj[2]++;
                if (5 * var[0] + var[1] < 30) obj[2]++;
                v.inFeasible = (int)obj[2];
            }
        }
        public static void IBeamFunction(DecisionVector v, double[] obj, int trial) 
        {
            double[] x = new double[4];
            if (trial == 0)
            {
                x[0] = v.CurrentVector[0];
                x[1] = v.CurrentVector[1];
                x[2] = v.CurrentVector[2];
                x[3] = v.CurrentVector[3];
                v.inFeasible = 0;
                obj[0] = 2 * x[1] * x[3] + x[2] * (x[0] - 2 * x[3]);
                obj[1] = 60000 / (x[2] * Math.Pow(x[0] - 2 * x[3], 3) + 2 * x[1] * x[3] * (4 * Math.Pow(x[3], 2) + 3 * x[0] * (x[0] - 2 * x[3])));
                if ((16 - obj[1] * 0.3 - (15000 * x[1]) / (Math.Pow(x[0] - 2 * x[3], 3) * Math.Pow(x[2], 3) + 2 * x[3] * Math.Pow(x[1], 3))) < 0) obj[2]++;
                v.inFeasible = (int)obj[2];
            }
            if (trial == 1)
            {
                x[0] = v.TrialVector[0];
                x[1] = v.TrialVector[1];
                x[2] = v.TrialVector[2];
                x[3] = v.TrialVector[3];
                v.inFeasible = 0;
                obj[0] = 2 * x[1] * x[3] + x[2] * (x[0] - 2 * x[3]);
                obj[1] = 60000 / (x[2] * Math.Pow(x[0] - 2 * x[3], 3) + 2 * x[1] * x[3] * (4 * Math.Pow(x[3], 2) + 3 * x[0] * (x[0] - 2 * x[3])));
                if ((16 - obj[1] * 0.3 - (15000 * x[1]) / (Math.Pow(x[0] - 2 * x[3], 3) * Math.Pow(x[2], 3) + 2 * x[3] * Math.Pow(x[1], 3))) < 0) obj[2]++;
                v.inFeasible = (int)obj[2];
            }
        }
    }
}
