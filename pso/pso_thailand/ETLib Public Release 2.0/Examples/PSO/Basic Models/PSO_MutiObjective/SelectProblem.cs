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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSO_MutiObjective
{
    public partial class SelectProblem : Form
    {
        public int  p;
        public SelectProblem()
        {
            InitializeComponent();
        }

        private void SelectProblem_Load(object sender, EventArgs e)
        {
            this.cbProblem.Items.Add("SCH");
            this.cbProblem.Items.Add("KUR");
            this.cbProblem.Items.Add("ZDT1");
            this.cbProblem.Items.Add("ZDT2");
            this.cbProblem.Items.Add("ZDT3");
            this.cbProblem.Items.Add("ZDT4");
            this.cbProblem.Items.Add("ZDT6");
            this.cbProblem.Items.Add("CONSTR");
            this.cbProblem.Items.Add("SRN");
            this.cbProblem.Items.Add("TNK");
            this.cbProblem.Items.Add("I-BEAM");
        }

        private void cbProblem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProblem.Text == "")
            {
            }
            else
            {
                this.problem.ImageLocation = "ProblemPic\\" +(cbProblem.Items.IndexOf(cbProblem.Text)+1).ToString() + ".jpg";
            }
        }
        private void selectP_Click(object sender, EventArgs e)
        {
            MultiObjPSO returnval = new MultiObjPSO();
            if (cbProblem.Items.IndexOf(cbProblem.Text)!=-1) 
                returnval.Problem = cbProblem.Items.IndexOf(cbProblem.Text);
            this.Dispose();
            this.Close();
        }
    }
}