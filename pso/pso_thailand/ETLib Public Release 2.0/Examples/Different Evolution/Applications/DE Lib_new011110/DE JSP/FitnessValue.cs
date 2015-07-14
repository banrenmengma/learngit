using System;
using System.Collections.Generic;
using System.Text;
using ETLib_DE_JSP;

namespace DE_JSP
{
    public class FitnessValue
    {
        //Evaluate Multi Objective Function
        public static double FitnessValueScheduleGJSP(int NoJob, int NoMc, int[] NoOp, double[] rPosition, job[] Job, int Dimension, int[] NoOpPerMc, machine[] Machine, JSPdata JD)
        {
            double[] Position = new double[Dimension];
            for (int i = 0; i < Dimension; i++)
                Position[i] = rPosition[i]; // assign value of each dimension to Position array
            PositionAdjust.SortingListRuleOnPosition(JD.NoJob, JD.NoOp, Dimension, ref Position);
            DecodeActiveSchedule.OprBasedDecodeActiveSchd(NoJob, NoMc, Position, Job, Dimension, NoOpPerMc, Machine);
            double ObjFn = 0;
            double ObjFn2 = 0;
            double ObjFn3 = 0;
            double ObjFn4 = 0;
            double ObjFn5 = 0;
            ObjFn = Cmax2(NoMc, NoOpPerMc, Machine);
            ObjFn2 = MaxWeightTardiness(NoJob, NoOp, Job);
            ObjFn3 = MaxWeightEarliness(NoJob, NoOp, Job);
            ObjFn4 = 0.4 * ObjFn + 0.3 * ObjFn2 + 0.3 * ObjFn3;
            ObjFn5 = TotalTardiness(NoJob, NoOp, Job);
            return //ObjFn;
            //ObjFn2; 
            //ObjFn3;
            //ObjFn4;
            ObjFn5;

        }
        //1. Makespan
        public static double Cmax2(int NoMc, int[] NoOpPerMc, machine[] Machine)
        {
            double Cmax = 0;
            for (int m = 0; m < NoMc; m++) //for each machine
            {
                if (Machine[m].OrderNo[NoOpPerMc[m] - 1].EndTime > Cmax) // check if completion time of the last operation [on that machine 
                {
                    Cmax = Machine[m].OrderNo[NoOpPerMc[m] - 1].EndTime;
                }
            }
            return Cmax;
        }
        //2. Max weighted tardiness
        public static double MaxWeightTardiness(int NoJob, int[] NoOp, job[] Job)
        {
            double MaxWTardiness = 0;
            for (int j = 0; j < NoJob; j++)
            {
                MaxWTardiness = (Job[j].WeightTardy * Math.Max(((Job[j].Operation[NoOp[j] - 1].EndTime) - (Job[j].DueDate)), 0)) + MaxWTardiness;
            }
            return MaxWTardiness;
        }
        //2.1 Total  tardiness
        public static double TotalTardiness(int NoJob, int[] NoOp, job[] Job)
        {
            double SumTardiness = 0;
            for (int j = 0; j < NoJob; j++)
            {
                SumTardiness = (Math.Max(((Job[j].Operation[NoOp[j] - 1].EndTime) - (Job[j].DueDate)), 0)) + SumTardiness;
            }
            return SumTardiness;
        }

        //3. Max weighted earliness
        public static double MaxWeightEarliness(int NoJob, int[] NoOp, job[] Job)
        {
            double MaxWEarliness = 0;
            for (int j = 0; j < NoJob; j++)
            {
                MaxWEarliness = (Job[j].WeightTardy * Math.Max((-(Job[j].Operation[NoOp[j] - 1].EndTime) + (Job[j].DueDate)), 0)) + MaxWEarliness;
            }
            return MaxWEarliness;
        }
    } //class FitnessValue

    public class DecodeActiveSchedule
    {
        public static void OprBasedDecodeActiveSchd(int NoJob, int NoMc, double[] Position, job[] Job, int Dimension, int[] NoOpPerMc, machine[] Machine)
        {
            double[] MachineReadyTime = new double[NoMc];
            double[] JobReadyTime = new double[NoJob];
            int[] CountJobNumber = new int[NoJob];
            int[] CountMcNumber = new int[NoMc];
            int JobNumber, McNumber, OpNumber;
            for (int j = 0; j < NoJob; j++)
            {
                JobReadyTime[j] = Job[j].ReadyTime;
            }
            for (int m = 0; m < NoMc; m++)
            {
                Machine[m].OrderNo = new ordernumber[NoOpPerMc[m]]; 
            }
            for (int d = 0; d < Dimension; d++)
            {
                JobNumber = (int)(Position[d]); //determine Job number in sorted array
                OpNumber = CountJobNumber[JobNumber]; // determine operation number of jobs, ex. operation 1 of Job2
                McNumber = Job[JobNumber].Operation[OpNumber].MachineNo; // determine machine number for this operation
                Job[JobNumber].Operation[OpNumber].ScheduleSeqNo = d; // sequence determined by d

                int s = CountMcNumber[McNumber];
                Machine[McNumber].OrderNo[s].JobNo = JobNumber;
                Machine[McNumber].OrderNo[s].OprNo = OpNumber;

                if (MachineReadyTime[McNumber] <= JobReadyTime[JobNumber])
                {
                    Job[JobNumber].Operation[OpNumber].StartTime = JobReadyTime[JobNumber];
                }
                else //means (MachineReadyTime[McNumber]>JobReadyTime[JobNumber])
                {
                    //case1 : seeking any gap between two operations.
                    double StartTimeFirstOrder =
                        Machine[McNumber].OrderNo[0].EndTime -
                        Job[(Machine[McNumber].OrderNo[0].JobNo)].Operation[(Machine[McNumber].OrderNo[0].OprNo)].ProcessTime;
                    if (StartTimeFirstOrder > JobReadyTime[JobNumber])
                    {
                        double FreeIntervalCase1 = StartTimeFirstOrder - JobReadyTime[JobNumber];
                        if (FreeIntervalCase1 >= Job[JobNumber].Operation[OpNumber].ProcessTime)
                        {
                            Job[JobNumber].Operation[OpNumber].StartTime = JobReadyTime[JobNumber];
                            goto JumpToHere;
                        }
                    }
                    //case2
                    int i = 0;
                    while (i < CountMcNumber[McNumber] - 1)
                    {
                        double EndTimeIOrder = Machine[McNumber].OrderNo[i].EndTime;
                        double StartTimeI1Order = Machine[McNumber].OrderNo[i + 1].EndTime - Job[(Machine[McNumber].OrderNo[i + 1].JobNo)].Operation[(Machine[McNumber].OrderNo[i + 1].OprNo)].ProcessTime;
                        double MaximumNumber = Math.Max(EndTimeIOrder, JobReadyTime[JobNumber]);
                        double FreeInterval = StartTimeI1Order - MaximumNumber;
                        if (FreeInterval >= Job[JobNumber].Operation[OpNumber].ProcessTime)
                        {
                            Job[JobNumber].Operation[OpNumber].StartTime = MaximumNumber;
                            break;
                        }
                        i++;
                    }
                    //case3
                    if (i == CountMcNumber[McNumber] - 1) //on the last assign order
                    {
                        Job[JobNumber].Operation[OpNumber].StartTime = MachineReadyTime[McNumber];
                    }
                JumpToHere: ;
                }//end of else(MachineReadyTime[McNumber]>JobReadyTime[JobNumber])
                //End of 'For an active scheduling'

                Job[JobNumber].Operation[OpNumber].EndTime = Job[JobNumber].Operation[OpNumber].StartTime + Job[JobNumber].Operation[OpNumber].ProcessTime;
                MachineReadyTime[McNumber] = Math.Max(Job[JobNumber].Operation[OpNumber].EndTime, MachineReadyTime[McNumber]);
                JobReadyTime[JobNumber] = Job[JobNumber].Operation[OpNumber].EndTime;
                Machine[McNumber].OrderNo[s].EndTime = Job[JobNumber].Operation[OpNumber].EndTime;

                //insert the last machine info on the given McNumber(key sort is EndTime)
                //in order to get correct sequence on the OrderNo.
                int m = McNumber;
                int TheLastOrder = CountMcNumber[McNumber];
                for (int n = 0; n < TheLastOrder; n++)
                {
                    if (Machine[m].OrderNo[TheLastOrder].EndTime < Machine[m].OrderNo[n].EndTime)
                    {	//insert the last order before the nth order.
                        //start from the last backwards to the nth order.
                        int TempJobNo, TempOprNo;
                        double TempEndTime;
                        TempJobNo = Machine[m].OrderNo[TheLastOrder].JobNo;
                        TempOprNo = Machine[m].OrderNo[TheLastOrder].OprNo;
                        TempEndTime = Machine[m].OrderNo[TheLastOrder].EndTime;
                        for (int t = (TheLastOrder - 1); t >= n; t--)
                        {
                            Machine[m].OrderNo[t + 1].JobNo = Machine[m].OrderNo[t].JobNo;
                            Machine[m].OrderNo[t + 1].OprNo = Machine[m].OrderNo[t].OprNo;
                            Machine[m].OrderNo[t + 1].EndTime = Machine[m].OrderNo[t].EndTime;
                        }
                        Machine[m].OrderNo[n].JobNo = TempJobNo;
                        Machine[m].OrderNo[n].OprNo = TempOprNo;
                        Machine[m].OrderNo[n].EndTime = TempEndTime;
                        break;
                    }
                }
                CountJobNumber[JobNumber] = CountJobNumber[JobNumber] + 1;
                CountMcNumber[McNumber] = CountMcNumber[McNumber] + 1;
            }//end of for loop(d)	
        }
    }
    public class PositionAdjust
    {
        public static void SortingListRuleOnPosition(int NoJob, int[] NoOp, int Dimension, ref double[] Position)
        {            
            int[] DimensionArray = new int[Dimension];	//Create Dimension Array to be sorted.
            for (int i = 0; i < Dimension; i++)
            {
                DimensionArray[i] = i;  // Determine index of dimension array
            }

           /* // rescale value in Position array
            
            double max = Position[0];
            double min = Position[0];
            foreach (int n in Position)
            {
                max = Math.Max(max, n);
                min = Math.Min(min, n);
            }
            double a = 1 / (max - min);
            double b = -min / (max-min);
            for (int i = 0; i < Dimension; i++)
            {
                Position[i] = a * Position[i] + b;

            }
            //end of rescale
            * */

            Array.Sort(Position, DimensionArray);	//Sorting value in Position array
                        
            //Assign integer(job) to each position of sorted array
            int d = 0;
            for (int j = 0; j < NoJob; j++)
            {
                for (int i = 0; i < NoOp[j]; i++)
                {
                    Position[DimensionArray[d]] = (double)j;
                    d++;
                }
            }
        }//end of method SortingListRuleOnPosition
    }

}

