
using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ETLib_MODE;

namespace DE_MultiObjective
{
    public partial class MultiObjDE : Form
    {
        ArrayList Ani;
        ArrayList AniS;
        public int Istep;
        Color[] pColor = new Color[5];
        public static string[] pr = new string[11];
        public static int problem = 0;
        public static Label l = new Label();
        //private setRNText setRNTextDelegate;
        public int Problem 
        {
            set
            {
                problem = value;
                l.Text=pr[problem];
            }
        }
        public MultiObjDE()
        {
            InitializeComponent();
        }
        private void MODEForm_Load(object sender, EventArgs e)
        {
            l = this.lproblem;
            pColor[0] = Color.Yellow;
            pColor[1] = Color.DarkGray;
            pColor[2] = Color.Blue;
            pColor[3] = Color.Red;
            pColor[4] = Color.Green;
            Istep = 0;
            this.DEiter.Value = 500;
            this.DEnumVectors.Value = 50;
            this.DEfmin.Text = "0.4";
            this.DEfmax.Text = "0.9";
            this.DEnb.Value = 5;
            this.DEcrx.Text = "0.5";
            this.DEcrn.Text = "0.1";
            this.nElite.Text = "100";
            this.percTopE.Text = "10";
            this.percBotE.Text = "20";
            this.percGapU.Text = "5";

            this.ptype1.Text = "25";
            this.ptype2.Text = "25";
            this.ptype3.Text = "25";
            this.ptype4.Text = "25";
            this.randomS.Text = "-1";
            this.nRep.Text = "1";

            this.cAnimation.Checked = false;
            this.cRandomExp.Checked = true;
            this.randomS.Enabled = false;

            pr[0]="SCH";
            pr[1]="KUR";
            pr[2]="ZDT1";
            pr[3]="ZDT2";
            pr[4]="ZDT3";
            pr[5]="ZDT4";
            pr[6]="ZDT6";
            pr[7]="CONSTR";
            pr[8]="SRN";
            pr[9]="TNK";
            pr[10] = "I-Beam";
            this.lproblem.Text = pr[problem];
            this.AniStep.Text = Istep.ToString();
            this.AniSpeed.Text = "100";
            //setRNTextDelegate = new setRNText(this.RNsettext);
        }
        private void MODErun_Click(object sender, EventArgs e)
        {
            double[] index;
            ArrayList Average;
            double[] DEparas = new double[19];
            ArrayList Pareto = new ArrayList();
            DateTime start = DateTime.Now;

            DEparas[0] = Convert.ToDouble(this.DEiter.Value);
            DEparas[1] = Convert.ToDouble(this.DEnumVectors.Value);
            DEparas[2] = Convert.ToDouble(this.DEfmin.Text);
            DEparas[3] = Convert.ToDouble(this.DEfmax.Text);
            DEparas[4] = Convert.ToDouble(this.DEnb.Value);
            DEparas[5] = Convert.ToDouble(this.DEcrx.Text);
            DEparas[6] = Convert.ToDouble(this.DEcrn.Text);
            DEparas[9] = Convert.ToDouble(this.nElite.Text);
            DEparas[10] = Convert.ToDouble(this.percTopE.Text);
            DEparas[11] = Convert.ToDouble(this.percBotE.Text);
            DEparas[12] = Convert.ToDouble(this.percGapU.Text);
            DEparas[13] = Convert.ToDouble(this.ptype1.Text);
            DEparas[14] = Convert.ToDouble(this.ptype2.Text);
            DEparas[15] = Convert.ToDouble(this.ptype3.Text);
            DEparas[16] = Convert.ToDouble(this.ptype4.Text);
            DEparas[17] = Convert.ToDouble(this.randomS.Text);
            DEparas[18] = Convert.ToDouble(this.nRep.Text);


            //for (int strategy = 1; strategy < 7; strategy++)
            //for (int strategy = 5; strategy < 6; strategy++)
            MainClass.DE(problem, DEparas, (int)moveS.Value, this.cAnimation.Checked, out index, out Pareto, out Ani, out AniS, out Average /*, setRNTextDelegate*/);

            TimeSpan finish = DateTime.Now - start;
            DEGraph.GraphPane.CurveList.Clear();
            for (int i = 0; i < Average.Count; i++)
                DrawGraph.CreateXY(DEGraph, index, (double[])Average[i], pColor[i + 1], i + 1);

            double[] xx = new double[Pareto.Count];
            double[] yy = new double[Pareto.Count];
            for (int i = 0; i < Pareto.Count; i++)
            {
                xx[i] = ((DecisionVector)Pareto[i]).Objective[0];
                yy[i] = ((DecisionVector)Pareto[i]).Objective[1];
            }
            DE_Pareto.GraphPane.CurveList.Clear();
            DrawGraph.CreateXYScatter(DE_Pareto, xx, yy, "Pareto Front", "Non-dominated front", Color.Blue);

            //show results of computational time and #of Pareto
            ObjVal.Text = finish.ToString();
            NumberPareto.Text = Pareto.Count.ToString();
            // Enable animation function
            if (this.cAnimation.Checked)
            {
                this.AniStep.Enabled = true;
                this.AniStepRun.Enabled = true;
                this.DE_dynamic.Enabled = true;
                this.AniSpeed.Enabled = true;
            }
            else
            {
                this.AniStep.Enabled = false;
                this.AniStepRun.Enabled = false;
                this.DE_dynamic.Enabled = false;
                this.AniSpeed.Enabled = false;
            }
        }
        private void DE_dynamic_Click(object sender, EventArgs e)
        {
            int Aspeed = Int16.Parse(this.AniSpeed.Text);
            Istep = Int16.Parse(this.AniStep.Text);
            for (int s = Istep; s < Ani.Count; s++)
            {
                Step_Animate(pColor, s);
                Step_Animate_Swarm(pColor, s);
                System.Threading.Thread.Sleep(Aspeed);
            }
        }
        private void ActivateStepAni_Click(object sender, EventArgs e)
        {
            Istep = Int16.Parse(this.AniStep.Text) - 1;
            this.Back.Enabled = true;
            this.Forward.Enabled = true;
            Animation.GraphPane.XAxis.Scale.MaxAuto = true;
            Animation.GraphPane.XAxis.Scale.MinAuto = true;
            Animation.GraphPane.YAxis.Scale.MaxAuto = true;
            Animation.GraphPane.YAxis.Scale.MinAuto = true;
        }
        private void Step_Animate(Color[] pColor, int s)
        {
            Animation.GraphPane.CurveList.Clear();
            for (int pType = 0; pType < 5; pType++)
            {
                double[] xx = new double[((ArrayList)Ani[s]).Count];
                double[] yy = new double[((ArrayList)Ani[s]).Count];
                for (int i = 0; i < ((ArrayList)Ani[s]).Count; i++)
                {
                    if (((DecisionVector)((ArrayList)Ani[s])[i]).type == pType)
                    {
                        xx[i] = ((DecisionVector)((ArrayList)Ani[s])[i]).Objective[0];
                        yy[i] = ((DecisionVector)((ArrayList)Ani[s])[i]).Objective[1];
                    }
                }
                DrawGraph.CreateXYScatter(Animation, xx, yy, "pType" + pType.ToString(), "Animation_Step" + s.ToString(), pColor[pType]);
            }
            if ((s % 10 == 0) || (s == Ani.Count))
            {
                Animation.GraphPane.XAxis.Scale.MaxAuto = true;
                Animation.GraphPane.XAxis.Scale.MinAuto = true;
                Animation.GraphPane.YAxis.Scale.MaxAuto = true;
                Animation.GraphPane.YAxis.Scale.MinAuto = true;
            }
            else
            {
                //Animation.GraphPane.XAxis.Scale.MaxAuto = false;
                // Animation.GraphPane.XAxis.Scale.MinAuto = false;
                // Animation.GraphPane.YAxis.Scale.MaxAuto = false;
                // Animation.GraphPane.YAxis.Scale.MinAuto = false;
            }
        }
        private void Step_Animate_Swarm(Color[] pColor, int s)
        {
            //Animation.GraphPane.CurveList.Clear();
            for (int pType = 0; pType < 4; pType++)
            {
                double[] xx = new double[((ArrayList)AniS[s]).Count];
                double[] yy = new double[((ArrayList)AniS[s]).Count];
                for (int i = 0; i < ((ArrayList)AniS[s]).Count; i++)
                {
                    if (((DecisionVector)((ArrayList)AniS[s])[i]).type == pType)
                    {
                        xx[i] = ((DecisionVector)((ArrayList)AniS[s])[i]).Objective[0];
                        yy[i] = ((DecisionVector)((ArrayList)AniS[s])[i]).Objective[1];
                    }
                }
                DrawGraph.CreateXYScatter(Animation, xx, yy, "spType" + pType.ToString(), "Animation_StepS", pColor[pType]);
            }
            if ((s % 50 == 0) || (s == Ani.Count))
            {
                Animation.GraphPane.XAxis.Scale.MaxAuto = true;
                Animation.GraphPane.XAxis.Scale.MinAuto = true;
                Animation.GraphPane.YAxis.Scale.MaxAuto = true;
                Animation.GraphPane.YAxis.Scale.MinAuto = true;
            }
            else
            {
                Animation.GraphPane.XAxis.Scale.MaxAuto = false;
                Animation.GraphPane.XAxis.Scale.MinAuto = false;
                Animation.GraphPane.YAxis.Scale.MaxAuto = false;
                Animation.GraphPane.YAxis.Scale.MinAuto = false;
            }
        }
        private void Forward_Click(object sender, EventArgs e)
        {
            Istep++;
            if (Istep > Ani.Count - 1)
            {
                MessageBox.Show("This is last step");
                Istep--;
                return;
            }
            Step_Animate(pColor, Istep);
            Step_Animate_Swarm(pColor, Istep);
        }
        private void Back_Click(object sender, EventArgs e)
        {
            Istep--;
            if (Istep < 0)
            {
                MessageBox.Show("This is first step");
                Istep++;
                return;
            }
            Step_Animate(pColor, Istep);
            Step_Animate_Swarm(pColor, Istep);
        }
        private void AniStep_TextChanged(object sender, EventArgs e)
        {
            this.Back.Enabled = false;
            this.Forward.Enabled = false;
        }
        private void Rescale_Click_1(object sender, EventArgs e)
        {
            Animation.GraphPane.XAxis.Scale.MaxAuto = true;
            Animation.GraphPane.XAxis.Scale.MinAuto = true;
            Animation.GraphPane.YAxis.Scale.MaxAuto = true;
            Animation.GraphPane.YAxis.Scale.MinAuto = true;
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void cRandomExp_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cRandomExp.Checked)
            {
                this.randomS.Text = "-1";
                this.randomS.Enabled = false;
            }
            else
            {
                this.randomS.Text = "1";
                this.randomS.Enabled = true;
            }
        }
        private void selectPr_Click(object sender, EventArgs e)
        {
            SelectProblem newForm = new SelectProblem();
            newForm.Show();
        }
        private void moveS_ValueChanged_1(object sender, EventArgs e)
        {
            if (moveS.Value == 6)
            {
                this.ptype1.Text = "25";
                this.ptype2.Text = "25";
                this.ptype3.Text = "50";
                this.ptype4.Text = "0";
            }
            if (moveS.Value == 5)
            {
                this.ptype1.Text = "25";
                this.ptype2.Text = "25";
                this.ptype3.Text = "25";
                this.ptype4.Text = "25";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void ObjVal_TextChanged(object sender, EventArgs e)
        {

        }

        /*public void RNsettext(String txt)
        {
            this.RN.Text = txt;
        }*/
    }
}