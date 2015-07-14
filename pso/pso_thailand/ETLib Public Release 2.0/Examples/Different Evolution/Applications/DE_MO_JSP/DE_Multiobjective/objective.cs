using System;
using System.Collections.Generic;
using System.Text;
using ETLib_MODE_JSP;

namespace DE_MutiObjective
{
    class objective
    {
        //1. Makespan
        public double Cmax2(int NoMc, int[] NoOpPerMc, machine[] Machine)
        {
            double Cmax = 0;
            for (int m = 0; m < NoMc; m++)
            {
                if (Machine[m].OrderNo[NoOpPerMc[m] - 1].EndTime > Cmax)
                {
                    Cmax = Machine[m].OrderNo[NoOpPerMc[m] - 1].EndTime;
                }
            }
            return Cmax;
        }
        //2. Max weighted tardiness
        public double MaxWeightTardiness(int NoJob, int[] NoOp, job[] Job)
        {
            double MaxWTardiness = 0;
            for (int j = 0; j < NoJob; j++)
            {
                MaxWTardiness = (Job[j].WeightTardy * Math.Max(((Job[j].Operation[NoOp[j] - 1].EndTime) - (Job[j].DueDate)), 0)) + MaxWTardiness;
            }
            return MaxWTardiness;
        }
        //2.1 Total  tardiness
        public double TotalTardiness(int NoJob, int[] NoOp, job[] Job)
        {
            double SumTardiness = 0;
            for (int j = 0; j < NoJob; j++)
            {
                SumTardiness = (Math.Max(((Job[j].Operation[NoOp[j] - 1].EndTime) - (Job[j].DueDate)), 0)) + SumTardiness;
            }
            return SumTardiness;
        }
        //3. Max weighted earliness
        public double MaxWeightEarliness(int NoJob, int[] NoOp, job[] Job)
        {
            double MaxWEarliness = 0;
            for (int j = 0; j < NoJob; j++)
            {
                MaxWEarliness = (Job[j].WeightTardy * Math.Max((-(Job[j].Operation[NoOp[j] - 1].EndTime) + (Job[j].DueDate)), 0)) + MaxWEarliness;
            }
            return MaxWEarliness;
        }

    }
}
    
