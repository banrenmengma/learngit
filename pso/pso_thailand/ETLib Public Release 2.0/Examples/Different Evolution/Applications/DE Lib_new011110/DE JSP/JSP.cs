using System;
using System.Collections.Generic;
using System.Text;
using ETLib_DE_JSP;

namespace DE_JSP
{
    public struct operation
    {
        public int MachineNo;
        public double ProcessTime, StartTime, EndTime;
        public int ScheduleSeqNo;
    }
    public struct job
    {
        public double ReadyTime, DueDate, WeightTardy;
        public operation[] Operation;
    }
    public struct ordernumber
    {
        public int JobNo, OprNo;
        public double EndTime;
    }
    public struct machine
    {
        public ordernumber[] OrderNo;
    }
    public struct JSPdata
    {
        public int NoJob;
        public int NoMc;
        public int[] NoOp;
        public job[] Job;
        public int[] NoOpPerMc;
        public machine[] Machine;
        public JSPdata(int nj, int nm, int[] no, job[] J, int[] nopm, machine[] m)
        {
            this.NoJob = nj;
            this.NoMc = nm;
            this.NoOp = no;
            this.Job = J;
            this.NoOpPerMc = nopm;
            this.Machine = m;
        }
    }
}
