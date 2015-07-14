using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ETLib_DE_JSP;


namespace DE_JSP
{
    public class ReadInput
    {
        public static void ReadfromFile(out int NoJob, out int NoMc, out int[] NoOp, out job[] Job)
        {
            //Reading input data from a file
            char[] Dividers = { ',', ' ' };
            StreamReader InputSR;
            ReadInput.OpenFile(out InputSR);
            ReadInput.ReadFile1NoJobMc(InputSR, Dividers, out NoJob, out NoMc);
            NoOp = new int[NoJob];
            Job = new job[NoJob];
            ReadInput.ReadFile2ProcessTimeMachineNo(InputSR, NoJob, ref NoOp, ref Job, Dividers);

            //For MaxWeightedTardiness & MaxWeightedEaeliness
            ReadInput.ReadFile3ReadyTime(InputSR, ref Job, Dividers);
            //For MaxWeightedTardiness & MaxWeightedEaeliness
            ReadInput.ReadFile4DueDate(InputSR, ref Job, Dividers, NoJob);
            //For MaxWeightedTardiness & MaxWeightedEaeliness
            ReadInput.ReadFile5WeightTardy1Line(InputSR, ref Job, Dividers, NoJob);
            InputSR.Close();
            //Ending for reading input data from a file
        }
        public static void OpenFile(out StreamReader InputSR)
        {

            FileStream InputFS = File.Open("Name.txt", FileMode.Open, FileAccess.Read);
            InputSR = new StreamReader(InputFS);
        }

        public static void ReadFile1NoJobMc(StreamReader InputSR, char[] Dividers, out int NoJob, out int NoMc)
        {
            string InputLine = InputSR.ReadLine();
            string[] sInputSplit = InputLine.Split(Dividers);
            int i = 0;
            int[] NumSplit = new int[sInputSplit.Length];
            foreach (string s in sInputSplit)
            {
                if (s.Length > 0)  // (skip any empty segments)
                {
                    NumSplit[i] = Int32.Parse(s);  // skip strings that aren't numbers	
                    i = i + 1;
                }
            }
            NoJob = NumSplit[0];
            NoMc = NumSplit[1];
        }

        public static void ReadFile2ProcessTimeMachineNo(StreamReader InputSR, int NoJob, ref int[] NoOp, ref job[] Job, char[] Dividers)
        {
            for (int j = 0; j < NoJob; j++)	//Read,Split,Convert to number
            {
                string InputLine = InputSR.ReadLine();
                string[] sInputSplit = InputLine.Split(Dividers);
                int k = 0;
                int k1 = 0;
                int k2 = 0;

                foreach (string s in sInputSplit)
                {
                    if (s.Length > 0)
                    {
                        NoOp[j]++;
                    }
                }
                NoOp[j] = NoOp[j] / 2; // determine number of operations for each job
                Job[j].Operation = new operation[NoOp[j]];
                foreach (string s in sInputSplit)
                {
                    if (s.Length > 0)
                    {
                        if (k % 2 == 0) //it means the even position nums 0,2,4,... tell m/c no.
                        {
                            Job[j].Operation[k1].MachineNo = Int32.Parse(s);
                            k1 = k1 + 1;
                        }
                        else
                        {
                            Job[j].Operation[k2].ProcessTime = Double.Parse(s);
                            k2 = k2 + 1;
                        }
                        k = k + 1;
                    }
                }

            }
        }

        public static void ReadFile3ReadyTime(StreamReader InputSR, ref job[] Job, char[] Dividers)
        {
            string InputLine = InputSR.ReadLine();	//Read,Split,Convert to number
            if (InputLine != null)
            {
                string[] sInputSplit = InputLine.Split(Dividers);
                int j = 0;
                foreach (string s in sInputSplit)
                {
                    if (s.Length > 0)
                    {
                        Job[j].ReadyTime = Double.Parse(s);
                        j = j + 1;
                    }
                }
            }
        }

        public static void ReadFile4DueDate(StreamReader InputSR, ref job[] Job, char[] Dividers, int NoJob)
        {
            string InputLine = InputSR.ReadLine();	//Read,Split,Convert to number
            if (InputLine != null)
            {
                string[] sInputSplit = InputLine.Split(Dividers);
                int j = 0;
                foreach (string s in sInputSplit)
                {
                    if (s.Length > 0)
                    {
                        Job[j].DueDate = Double.Parse(s);
                        j = j + 1;
                    }
                }
            }
            else
            {
                for (int j = 0; j < NoJob; j++)
                {
                    Job[j].DueDate = 100000000;
                }
            }
        }

        public static void ReadFile5WeightTardy1Line(StreamReader InputSR, ref job[] Job, char[] Dividers, int NoJob)
        {
            string InputLine = InputSR.ReadLine();	//Read,Split,Convert to number
            if (InputLine != null)
            {
                string[] sInputSplit = InputLine.Split(Dividers);
                int j = 0;
                foreach (string s in sInputSplit)
                {
                    if (s.Length > 0)
                    {
                        Job[j].WeightTardy = Double.Parse(s);
                        j = j + 1;
                    }
                }
            }
            else
            {
                for (int j = 0; j < NoJob; j++)
                {
                    Job[j].WeightTardy = 1;
                }
            }
        }
        public static void MachineInfo(int NoJob, int[] NoOp, ref int[] NoOpPerMc, job[] Job)
        {
            for (int j = 0; j < NoJob; j++)
            {
                for (int i = 0; i < NoOp[j]; i++)
                {
                    int m = Job[j].Operation[i].MachineNo;
                    NoOpPerMc[m]++; //count number of operation of each machine
                }
            }
        }
    }
}