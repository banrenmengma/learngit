using System;
using System.Collections.Generic;
using System.Text;
using ETLib_MODE_JSP;

namespace DE_MutiObjective
{
    public class FitnessValue
    {
        //Evaluate Multi Objective Function
        public void ScheduleGJSP(int NoJob, int NoMc, int[] NoOp, double[] rPosition, job[] Job, int Dimension, int[] NoOpPerMc, machine[] Machine, JSPdata JD)
        {
            double[] Position = new double[Dimension];
            for (int i = 0; i < Dimension; i++)
                Position[i] = rPosition[i];
            PositionAdjust.SortingListRuleOnPosition(JD.NoJob, JD.NoOp, Dimension, ref Position);
            DecodeActiveSchedule.OprBasedDecodeActiveSchd(NoJob, NoMc, Position, Job, Dimension, NoOpPerMc, Machine);
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
                JobNumber = (int)(Position[d]);
                OpNumber = CountJobNumber[JobNumber];
                McNumber = Job[JobNumber].Operation[OpNumber].MachineNo;
                Job[JobNumber].Operation[OpNumber].ScheduleSeqNo = d;

                int s = CountMcNumber[McNumber];
                Machine[McNumber].OrderNo[s].JobNo = JobNumber;
                Machine[McNumber].OrderNo[s].OprNo = OpNumber;

                if (MachineReadyTime[McNumber] <= JobReadyTime[JobNumber])
                {
                    Job[JobNumber].Operation[OpNumber].StartTime = JobReadyTime[JobNumber];
                }
                else //means (MachineReadyTime[McNumber]>JobReadyTime[JobNumber])
                {
                    //seeking any gap between two operations.
                    //case1
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
}
