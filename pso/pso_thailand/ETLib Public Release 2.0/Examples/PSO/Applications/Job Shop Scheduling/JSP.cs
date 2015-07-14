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
using System.Collections.Generic;
using System.Text;

namespace PSO_JSP
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
        public machine[] Machine ;
        public JSPdata(int nj,int nm,int[] no,job[] J,int[] nopm,machine[] m)
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
