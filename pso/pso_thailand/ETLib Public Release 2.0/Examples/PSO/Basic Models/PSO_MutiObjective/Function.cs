using System;
using System.Collections.Generic;
using System.Text;
using ETLib_M3PSO;
namespace PSO_MutiObjective
{
    class Function
    {
        public static void ZDT6_Function(Particle P, double[] obj) //range [0,1], optimal range x1=[0,1],xi=0 for other i
        {
            int n = 10;
            double[] var = new double[n];

            for (int j = 0; j < n; j++)
            {
                var[j] = P.Position[j];
                obj[1] += var[j];
            }
           
            obj[1] = 1 + 9 * Math.Pow((obj[1] - var[0]) / (n - 1), 0.25);
            obj[0] = 1 - Math.Exp(-4 * var[0]) * Math.Pow(Math.Sin(6 * Math.PI * var[0]), 6);
            obj[1] = obj[1] * (1 - Math.Pow(obj[0] / obj[1], 2));

        }

        public static void ZDT4_Function(Particle P, double[] obj) //range [0,1], optimal range x1=[0,1],xi=0 for other i
        {
            int n = 10;
            double[] var = new double[n];
            var[0] = P.Position[0];
            for (int j = 1; j < n; j++)
            {
                var[j] = P.Position[j];
                obj[1] += (Math.Pow(var[j], 2) - 10 * Math.Cos(4 * Math.PI * var[j]));
            }
            obj[1] = 1 + 10 * (n - 1) + obj[1];
            obj[1] = obj[1] * (1 - Math.Sqrt(var[0] / obj[1]));
            obj[0] = var[0];
            
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
        public static void ZDT3_Function(Particle p, double[] obj) //range [0,1], optimal range x1=[0,1],xi=0 for other i
        {
            int n = 30;
            double[] var = new double[n];
            for (int j = 0; j < n; j++)
            {
                var[j] = p.Position[j];
                obj[1] += var[j];
            }
            obj[1] = 1 + 9 * (obj[1] - var[0]) / (n - 1);
            obj[1] = obj[1] * (1 - Math.Sqrt(var[0] / obj[1]) - var[0] / obj[1] * Math.Sin(10 * Math.PI * var[0]));
            obj[0] = var[0];
        }

        public static void ZDT2_Function(Particle P,double[] obj) //range [0,1], optimal range x1=[0,1],xi=0 for other i
        {
            int n = 30;
            double[] var = new double[n];
            for (int j = 0; j < n; j++)
            {
                var[j] = P.Position[j];
                obj[1] += var[j];
            }
            obj[1] = 1 + 9 * (obj[1] - var[0]) / (n - 1);
            obj[1] = obj[1] * (1 - Math.Pow(var[0] / obj[1], 2));
            obj[0] = var[0];
        }

        public static void ZDT1_Function(Particle p, double[] obj) //range [0,1], optimal range x1=[0,1],xi=0 for other i
        {
            int n = 30;
            double[] var = new double[n];
            for (int j = 0; j < n; j++)
            {
                var[j] = p.Position[j];
                obj[1] += var[j];
            }
            obj[1] = 1 + 9 * (obj[1] - var[0]) / (n - 1);
            obj[1] = obj[1] * (1 - Math.Sqrt(var[0] / obj[1]));
            obj[0] = var[0];
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
        public static void KUR_Function(Particle p, double[] obj) // range [-10e2,10e2], optimal range [0,2]
        {
            double[] var  = new double[3];
            for (int i = 0; i < p.Dimension; i++)
                var[i] = p.Position[i];
            for (int j=0; j < 3; j++)
            {
                if (j<2) obj[0] += -10 * Math.Exp(-0.2 * Math.Sqrt(Math.Pow(var[j], 2) + Math.Pow(var[j+1], 2)));
                obj[1] += Math.Pow(Math.Abs(var[j]),0.8)+5*Math.Sin(Math.Pow(var[j],3)) ;
            }
        }
        public static void SCH_Function(Particle p, double[] obj) // range [-10e2,10e2], optimal range [0,2]
        {
            double var = p.Position[0];
            obj[0] = Math.Pow(var, 2);
            obj[1] = Math.Pow(var - 2, 2);
        }
        public static void TNK_Function(Particle p, double[] obj) // range [-10e2,10e2], optimal range [0,2]
        {
            double[] var = new double[3];
            var[0] = p.Position[0];
            var[1] = p.Position[1];
            p.inFeasible = 0;
            obj[0] = var[0];
            obj[1] = var[1];
            if ((-Math.Pow(var[0], 2) - Math.Pow(var[1], 2) +1+0.1*Math.Cos(16*Math.Atan(var[0]/var[1])) > 0)||(var[1]==0)) obj[2]++;
            if (Math.Pow(var[0] - 0.5, 2) + Math.Pow(var[1] - 0.5, 2) > 0.5) obj[2]++;
            p.inFeasible = (int)obj[2];
        }
        public static void SRN_Function(Particle p, double[] obj) // range [-10e2,10e2], optimal range [0,2]
        {
            double[] var = new double[2];
            var[0] = p.Position[0];
            var[1] = p.Position[1];
            p.inFeasible = 0;
            obj[0] = Math.Pow(var[0]-2,2)+Math.Pow(var[1]-1,2)+2;
            obj[1] = 9 * var[0] - Math.Pow(var[1] - 1, 2);
            if (Math.Pow(var[0], 2) + Math.Pow(var[1], 2)>225) obj[2]++;
            if (var[0]-3*var[1]>-10) obj[2]++;
            p.inFeasible = (int)obj[2];
        }
        public static void CONSTR_Function(Particle p, double[] obj) // range [-10e2,10e2], optimal range [0,2]
        {
            double[] var=new double[2];
            var[0]=p.Position[0];
            var[1]=p.Position[1];
            p.inFeasible = 0;
            obj[0] = var[0];
            obj[1] = (1+var[1])/var[0];
            if (var[1] + 9 * var[0] < 6) obj[2]++;
            if (-var[1] + 9 * var[0] < 1) obj[2]++;
            p.inFeasible = (int)obj[2];
        }
        public static void KITA_Function(Particle p, double[] obj) // range [0,inf], optimal range [0,2]
        {
            double[] var = new double[2];
            var[0] = p.Position[0];
            var[1] = p.Position[1];
            p.inFeasible = 0;
            obj[0] = -Math.Pow(var[0],2)+var[1];
            obj[1] = var[0] / 2 + var[1] + 1;
            if (var[0]/6+var[1]<13/2) obj[2]++;
            if (var[0]/2+var[1]<15/2) obj[2]++;
            if (5*var[0]+var[1]<30) obj[2]++;
            p.inFeasible = (int)obj[2];
        }
        public static void IBeamFunction(Particle p, double[] obj) 
        {
            double[] x = new double[4];
            x[0] = p.Position[0];
            x[1] = p.Position[1];
            x[2] = p.Position[2];
            x[3] = p.Position[3];
            p.inFeasible = 0;
            obj[0] = 2*x[1]*x[3]+x[2]*(x[0]-2*x[3]);
            obj[1] = 60000/(x[2]*Math.Pow(x[0]-2*x[3],3)+2*x[1]*x[3]*(4*Math.Pow(x[3],2)+3*x[0]*(x[0]-2*x[3])));
            if ((16 - obj[1] * 3 *x[0] - (15000 * x[1]) / ((x[0] - 2 * x[3]) * Math.Pow(x[2], 3) + 2 * x[3] * Math.Pow(x[1], 3)))<0) obj[2]++;
            p.inFeasible = (int)obj[2];
        }
    }
}
