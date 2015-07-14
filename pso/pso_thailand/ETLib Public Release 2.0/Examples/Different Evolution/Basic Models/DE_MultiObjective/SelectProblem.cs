using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DE_MultiObjective
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
            MultiObjDE returnval = new MultiObjDE();
            if (cbProblem.Items.IndexOf(cbProblem.Text)!=-1) 
                returnval.Problem = cbProblem.Items.IndexOf(cbProblem.Text);
            this.Dispose();
            this.Close();
        }
    }
}