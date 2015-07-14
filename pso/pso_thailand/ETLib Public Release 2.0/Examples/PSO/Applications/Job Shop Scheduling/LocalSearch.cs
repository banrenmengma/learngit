////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//ET-Lib Object Library for Evolutionary Techniques                                                               //
//Copyright (C) 2010 Kachitvichyanukul, V., T. J. Ai, and S. Nguyen                                               //  
//This program is free software; you can redistribute it and/or modify it under the terms of the GNU General      //
//Public License as published by the Free Software Foundation; either version 2 of the License, or (at your       //
//option) any later version.                                                                                      //
//This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the      // 
//implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License    //
//for more details.                                                                                               //  
//For a copy of the GNU General Public License write to                                                           //  
//Free Software Foundation, Inc.,                                                                                 //  
//51 Franklin Street, Fifth Floor,                                                                                //
//Boston, MA 02110-1301 USA.                                                                                      //
//                                                                                                                //
//For further information on ET-Lib please contact via electronic mail                                            //
//Voratas Kachitvichyanukul (voratas@ait.ac.th)                                                                   //
//Industrial and Manufacturing Engineering                                                                        //  
//Asian Institute of Technology                                                                                   //
//THAILAND, 12120                                                                                                 //
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;

namespace PSO_JSP
{
    public class LocalSearch
    {
        public static double[] InterExchangeCirticalPath(int NoJob, int NoMc, int[] NoOp, int[] NoOpPerMc,
            int Dimension, double[] Position, double FitValue, machine[] Machine, job[] Job, ref Random RandomNum, ref JSPdata JD)
        {
            ArrayList Pair1 = new ArrayList(); //forward
            ArrayList Pair2 = new ArrayList();
            ArrayList Pair1BW = new ArrayList(); //backward
            ArrayList Pair2BW = new ArrayList();
            FitValue = FitnessValue.FitnessValueScheduleGJSP(NoJob, NoMc, NoOp, Position, Job, Dimension, NoOpPerMc, Machine,JD);
            CirticalPath(NoJob, NoMc, NoOp, NoOpPerMc, Machine, Job, ref Pair1, ref Pair2, ref Pair1BW, ref Pair2BW, ref RandomNum); //get possible pairs by defining a path (blocks)

            double[] AdjPosition = new double[Dimension];
            double[] MinAdjPosition = new double[Dimension];
            double AdjFitValue = 0;
            double MinAdjFitValue = FitValue;
            for (int i = 0; i < Dimension; i++)
            {
                MinAdjPosition[i] = Position[i];
            }

            int NoPair = Pair1.Count; //forward	
            for (int l = 0; l < NoPair; l++)
            {
                int Locate1 = (int)Pair1[l];
                int Locate2 = (int)Pair2[l];
                if (Locate1 < Locate2) //"Locate1>Locate2" means leaps frogging Locate1 over Locate2 (Active Schedule)//
                {
                    for (int i = 0; i < Dimension; i++)
                    {
                        AdjPosition[i] = Position[i];
                    }
                    InterExchangeAPair(Dimension, ref AdjPosition, Locate1, Locate2);//InterExchange one pair to the position
                    AdjFitValue = FitnessValue.FitnessValueScheduleGJSP(NoJob, NoMc, NoOp, AdjPosition, Job, Dimension, NoOpPerMc, Machine,JD);

                    if (AdjFitValue < MinAdjFitValue)
                    {
                        MinAdjFitValue = AdjFitValue;
                        for (int i = 0; i < Dimension; i++)
                        {
                            MinAdjPosition[i] = AdjPosition[i];
                        }
                    }
                }
            }

            int NoPairBW = Pair1BW.Count; //backward
            for (int l = 0; l < NoPairBW; l++)
            {
                int Locate1 = (int)Pair1BW[l];
                int Locate2 = (int)Pair2BW[l];
                if (Locate1 < Locate2) //"Locate1>Locate2" means leaps frogging Locate1 over Locate2 (Active Schedule)//
                {
                    for (int i = 0; i < Dimension; i++)
                    {
                        AdjPosition[i] = Position[i];
                    }
                    InterExchangeAPairBW(Dimension, ref AdjPosition, Locate1, Locate2);//InterExchange one pair to the position
                    AdjFitValue = FitnessValue.FitnessValueScheduleGJSP(NoJob, NoMc, NoOp, AdjPosition, Job, Dimension, NoOpPerMc, Machine,JD);

                    if (AdjFitValue < MinAdjFitValue)
                    {
                        MinAdjFitValue = AdjFitValue;
                        for (int i = 0; i < Dimension; i++)
                        {
                            MinAdjPosition[i] = AdjPosition[i];
                        }
                    }
                }
            }

            return MinAdjPosition;
        }
        public static void InterExchangeAPair(int Dimension, ref double[] AdjPosition, int Locate1, int Locate2)
        {
            int JobLocate2 = (int)AdjPosition[Locate2];
            int CountTempArrayLastJob = 1;
            for (int i = Locate2 - 1; i >= Locate1; i--)
            {
                if (AdjPosition[i] == JobLocate2)
                {
                    CountTempArrayLastJob++;
                }
                else
                {
                    AdjPosition[i + CountTempArrayLastJob] = AdjPosition[i];
                }
            }
            for (int i = 0; i < CountTempArrayLastJob; i++)
            {
                AdjPosition[Locate1] = JobLocate2;
                Locate1++;
            }
        }
        public static void InterExchangeAPairBW(int Dimension, ref double[] AdjPosition, int Locate1, int Locate2)
        {
            int JobLocate1 = (int)AdjPosition[Locate1];
            int CountTempArrayFirstJob = 1;
            for (int i = Locate1 + 1; i <= Locate2; i++)
            {
                if (AdjPosition[i] == JobLocate1)
                {
                    CountTempArrayFirstJob++;
                }
                else
                {
                    AdjPosition[i - CountTempArrayFirstJob] = AdjPosition[i];
                }
            }
            for (int i = 0; i < CountTempArrayFirstJob; i++)
            {
                AdjPosition[Locate2] = JobLocate1;
                Locate2--;
            }
        }
        public static void CirticalPath(int NoJob, int NoMc, int[] NoOp, int[] NoOpPerMc, machine[] Machine, job[] Job,
            ref ArrayList Pair1, ref ArrayList Pair2, ref ArrayList Pair1BW, ref ArrayList Pair2BW, ref Random RandomNum)
        {
            int NowJob = 0;
            int NowOpr, NowMc, NowOrderNo;
            int LinkJobNo = 0; int LinkOprNo = 0;
            bool LastBlock = false;

            double MaxEndTime = 0;
            for (int m = 0; m < NoMc; m++)
            {
                if (Machine[m].OrderNo[NoOpPerMc[m] - 1].EndTime > MaxEndTime)
                {
                    MaxEndTime = Machine[m].OrderNo[NoOpPerMc[m] - 1].EndTime;
                    NowJob = Machine[m].OrderNo[NoOpPerMc[m] - 1].JobNo;
                }
            }
            NowOpr = NoOp[NowJob] - 1;
            NowMc = Job[NowJob].Operation[NowOpr].MachineNo;
            NowOrderNo = NoOpPerMc[NowMc] - 1;

            ArrayList Block = new ArrayList();
            CriticleBlock(NowMc, NowOrderNo, Job, Machine, ref Block, ref LinkJobNo, ref LinkOprNo, ref LastBlock, ref RandomNum);
            CriticlePairAtMiddleBlockActiveCB(ref Pair1, ref Pair2, ref Pair1BW, ref Pair2BW, ref Block);
            while (LastBlock == false)
            {
                MoveToNextBlockOnNextMc(Job, Machine, LinkJobNo, LinkOprNo, ref NowJob, ref NowOpr, ref NowMc, ref NowOrderNo);
                Block.Clear();
                CriticleBlock(NowMc, NowOrderNo, Job, Machine, ref Block, ref LinkJobNo, ref LinkOprNo, ref LastBlock, ref RandomNum);
                if (LastBlock == true)
                {
                    CriticlePairAtMiddleBlockActiveCB(ref Pair1, ref Pair2, ref Pair1BW, ref Pair2BW, ref Block);
                }
                else
                {
                    CriticlePairAtMiddleBlockActiveCB(ref Pair1, ref Pair2, ref Pair1BW, ref Pair2BW, ref Block);
                }
            }
            Pair1.TrimToSize();
            Pair2.TrimToSize();
            Pair1BW.TrimToSize();
            Pair2BW.TrimToSize();
            Block.TrimToSize();
        }
        public static void MoveToNextBlockOnNextMc(job[] Job, machine[] Machine,
            int LinkJobNo, int LinkOprNo, ref int NowJob, ref int NowOpr, ref int NowMc, ref int NowOrderNo)
        {
            NowJob = LinkJobNo;
            NowOpr = LinkOprNo - 1;
            NowMc = Job[NowJob].Operation[NowOpr].MachineNo;
            int i = 0;
            while (true)  //to find NowOrderNo (it will be used in Critical Block)
            {
                if ((Machine[NowMc].OrderNo[i].JobNo == NowJob) && (Machine[NowMc].OrderNo[i].OprNo == NowOpr))
                {
                    NowOrderNo = i;
                    break;
                }
                else
                {
                    i++;
                }
            }
        }
        public static void CriticleBlock(int NowMc, int NowOrderNo, job[] Job, machine[] Machine, ref ArrayList Block, ref int LinkJobNo, ref int LinkOprNo, ref bool LastBlock, ref Random RandomNum)
        {	//Assign info of jobs to the tail criticle block of a machine
            int j1, o1, j2, o2, jj2, oo2;
            jj2 = Machine[NowMc].OrderNo[NowOrderNo].JobNo;
            oo2 = Machine[NowMc].OrderNo[NowOrderNo].OprNo;
            Block.Add(Job[jj2].Operation[oo2].ScheduleSeqNo);
            if (NowOrderNo != 0)
            {
                while (true)//(End==false)
                {
                    j1 = Machine[NowMc].OrderNo[NowOrderNo - 1].JobNo;
                    o1 = Machine[NowMc].OrderNo[NowOrderNo - 1].OprNo;
                    j2 = Machine[NowMc].OrderNo[NowOrderNo].JobNo;
                    o2 = Machine[NowMc].OrderNo[NowOrderNo].OprNo;
                    if (Job[j2].Operation[o2].StartTime == Job[j1].Operation[o1].EndTime)
                    {
                        if (o2 >= 1) //when there is more than 1 critical path,
                        {		  //prob. to select a path is 0.5
                            if (Job[j2].Operation[o2].StartTime == Job[j2].Operation[(o2 - 1)].EndTime)
                            {
                                if (RandomNum.NextDouble() <= 0.5)
                                {
                                    LinkJobNo = j2;
                                    LinkOprNo = o2;
                                    break;//End = true;
                                }
                            }
                        }
                        Block.Add(Job[j1].Operation[o1].ScheduleSeqNo);
                        NowOrderNo = NowOrderNo - 1;
                        if (NowOrderNo <= 0)
                        {
                            if (o1 == 0)
                            {
                                LastBlock = true;
                                break;
                            }
                            LinkJobNo = j1;
                            LinkOprNo = o1;
                            break;//End = true;
                        }
                    }
                    else
                    {
                        LinkJobNo = j2;
                        LinkOprNo = o2;
                        break;//End = true;
                    }
                }
            }
            else  //if(NowOrderNo==0)
            {
                if (oo2 == 0)
                {
                    LastBlock = true;
                }
                LinkJobNo = jj2;
                LinkOprNo = oo2;
            }
        }
        public static void CriticlePairAtMiddleBlockActiveCB(ref ArrayList Pair1, ref ArrayList Pair2, ref ArrayList Pair1BW, ref ArrayList Pair2BW, ref ArrayList Block)
        {//Check McBlock size and assign the possible interexchange pairs to Pair1 and Pair2
            if (Block.Count >= 3)
            {
                int IndexLast = (Block.Count) - 1;
                for (int i = 1; i < Block.Count; i++)
                {
                    Pair1.Add(Block[IndexLast]);
                    Pair2.Add(Block[IndexLast - i]);
                }
                for (int i = 1; i < Block.Count; i++)
                {
                    Pair1BW.Add(Block[0 + i]);
                    Pair2BW.Add(Block[0]);
                }
            }
            else
            {
                if (Block.Count == 2)
                {
                    Pair1.Add(Block[1]);
                    Pair2.Add(Block[0]);
                }
            }
        }
    } //class LocalSearch
}
