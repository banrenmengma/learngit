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
/* --------------------------------------------------------------------------------------------------------
  MOPSO.cs
  Nguyen Phan Bach Su 09-Feb-2010
  High Performance Computing Group,
  Industrial and Systems Engineering (ISE),
  Asian Institute of Technology (AIT)

 DESCRIPTION:
   Multi-strategy Multi-Learning-Term Multi-Objective PSO (M3PSO) is an optimization library which
was developed from the single objective GLNPSO library (Ai, T. J., 2009) to handle multi-objective 
optimization problems. Both M3PSO library and GLNPSO library were developed at Department of Industrial 
and Systems Engineering (ISE), Asian Institute of Technology (AIT), Thailand. The purpose of these libraries 
is to provide the researchers and students who are working on various optimization problems with a
general effective tool based on Particle Swarm Optimization algorithm.  
 * 
   This file contains the methods for interface control.
------------------------------------------------------------------------------------------------------------ */
using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ETLib_M3PSO;
namespace PSO_MutiObjective
{
    public partial class MultiObjPSO : ETForm
    {
        ArrayList Ani;
        ArrayList AniS;
        public int Istep;
        Color[] pColor = new Color[5];
        public static string[] pr = new string[11];
        public static int problem = 0;
        public static Label l = new Label();
        public int Problem 
        {
            set
            {
                problem = value;
                l.Text=pr[problem];
            }
        }
        public MultiObjPSO()
        {
            InitializeComponent();
        }
        private void MOPSOForm_Load(object sender, EventArgs e)
        {
            l = this.lproblem;
            pColor[0] = Color.Yellow;
            pColor[1] = Color.DarkGray;
            pColor[2] = Color.Blue;
            pColor[3] = Color.Red;
            pColor[4] = Color.Green;
            Istep = 0;
            this.PSOiter.Value = 500;
            this.PSOnumParticles.Value = 50;
            this.PSOwmin.Text = "0.4";
            this.PSOwmax.Text = "0.9";
            this.PSOnb.Value = 5;
            this.PSOcp.Text = "1";
            this.PSOcg.Text = "1";
            this.PSOcl.Text = "1";
            this.PSOcn.Text = "1";
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
        }
        private void MOPSOrun_Click(object sender, EventArgs e)
        {
            double[] index;
            ArrayList Average;
            double[] PSOparas = new double[19];
            ArrayList Pareto = new ArrayList();
            DateTime start = DateTime.Now;

            PSOparas[0] = Convert.ToDouble(this.PSOiter.Value);
            PSOparas[1] = Convert.ToDouble(this.PSOnumParticles.Value);
            PSOparas[2] = Convert.ToDouble(this.PSOwmin.Text);
            PSOparas[3] = Convert.ToDouble(this.PSOwmax.Text);
            PSOparas[4] = Convert.ToDouble(this.PSOnb.Value);
            PSOparas[5] = Convert.ToDouble(this.PSOcp.Text);
            PSOparas[6] = Convert.ToDouble(this.PSOcg.Text);
            PSOparas[7] = Convert.ToDouble(this.PSOcl.Text);
            PSOparas[8] = Convert.ToDouble(this.PSOcn.Text);
            PSOparas[9] = Convert.ToDouble(this.nElite.Text);
            PSOparas[10] = Convert.ToDouble(this.percTopE.Text);
            PSOparas[11] = Convert.ToDouble(this.percBotE.Text);
            PSOparas[12] = Convert.ToDouble(this.percGapU.Text);

            PSOparas[13] = Convert.ToDouble(this.ptype1.Text);
            PSOparas[14] = Convert.ToDouble(this.ptype2.Text);
            PSOparas[15] = Convert.ToDouble(this.ptype3.Text);
            PSOparas[16] = Convert.ToDouble(this.ptype4.Text);
            PSOparas[17] = Convert.ToDouble(this.randomS.Text);
            PSOparas[18] = Convert.ToDouble(this.nRep.Text);


            //for (int strategy = 1; strategy < 7; strategy++)
            //for (int strategy = 5; strategy < 6; strategy++)
            MainClass.PSO(problem,PSOparas, (int)moveS.Value, this.cAnimation.Checked, out index, out Pareto, out Ani, out AniS, out Average);

            TimeSpan finish = DateTime.Now - start;
            PSOGraph.GraphPane.CurveList.Clear();
            for (int i = 0; i < Average.Count; i++)
                DrawGraph.CreateXY(PSOGraph, index, (double[])Average[i], pColor[i + 1], i + 1);

            double[] xx = new double[Pareto.Count];
            double[] yy = new double[Pareto.Count];
            for (int i = 0; i < Pareto.Count; i++)
            {
                xx[i] = ((Particle)Pareto[i]).Objective[0];
                yy[i] = ((Particle)Pareto[i]).Objective[1];
            }
            PSO_Pareto.GraphPane.CurveList.Clear();
            DrawGraph.CreateXYScatter(PSO_Pareto, xx, yy, "Pareto Front", "Non-dominated front", Color.Blue);

            ObjVal.Text = finish.ToString();
            NumberPareto.Text = Pareto.Count.ToString();
            // Enable animation function
            if (this.cAnimation.Checked)
            {
                this.AniStep.Enabled = true;
                this.AniStepRun.Enabled = true;
                this.PSO_dynamic.Enabled = true;
                this.AniSpeed.Enabled = true;
            }
            else
            {
                this.AniStep.Enabled = false;
                this.AniStepRun.Enabled = false;
                this.PSO_dynamic.Enabled = false;
                this.AniSpeed.Enabled = false;
            }
        }
        private void PSO_dynamic_Click(object sender, EventArgs e)
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
                    if (((Particle)((ArrayList)Ani[s])[i]).type == pType)
                    {
                        xx[i] = ((Particle)((ArrayList)Ani[s])[i]).Objective[0];
                        yy[i] = ((Particle)((ArrayList)Ani[s])[i]).Objective[1];
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
                    if (((Particle)((ArrayList)AniS[s])[i]).type == pType)
                    {
                        xx[i] = ((Particle)((ArrayList)AniS[s])[i]).Objective[0];
                        yy[i] = ((Particle)((ArrayList)AniS[s])[i]).Objective[1];
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
    }
}