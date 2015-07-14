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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ETLib_AniPSO;

namespace PSO_basic_visual
{
    public partial class PSO_basic_visual : ETForm
    {
        ArrayList Ani;
        ArrayList AniS;
        Particle GBest;
        public int Istep;
        int fx = 0;
        Color[] pColor = new Color[5];
        public PSO_basic_visual()
        {
            InitializeComponent();
        }
        private void PSObasic_Load(object sender, EventArgs e)
        {   
            pColor[0] = Color.Yellow;
            pColor[1] = Color.DarkGray;
            pColor[2] = Color.Blue;
            pColor[3] = Color.Red;
            pColor[4] = Color.Green;
            Istep=0;
            this.AniStep.Text = Istep.ToString();
            this.AniSpeed.Text = "100";
            this.PSOiter.Value = 200;
            this.PSOnumParticles.Value = 5;
            this.PSOwmin.Text = "0.4";
            this.PSOwmax.Text="0.9";
            this.PSOnb.Value=5;
            this.PSOcp.Text = "2";
            this.PSOcg.Text = "2";
            this.PSOcl.Text = "0";
            this.PSOcn.Text = "0";
            fx = Convert.ToInt32(this.fxindex.Value);
            this.txtFunction.Text = Function.Get_Function_Text(fx);
            this.fxindex.Maximum = Function.numF() - 1;
        }
        private void Run_Click(object sender, EventArgs e)
        {
            double ObjectiveValue;
            double[] index;
            double[] Avg;
            double[] PSOparas = new double[9];
            fx = Convert.ToInt32(this.fxindex.Value); //choose objective function to be minimized
            PSOparas[0] = Convert.ToDouble(this.PSOiter.Value);
            PSOparas[1] = Convert.ToDouble(this.PSOnumParticles.Value);
            PSOparas[2] = Convert.ToDouble(this.PSOwmin.Text);
            PSOparas[3] = Convert.ToDouble(this.PSOwmax.Text);
            PSOparas[4] = Convert.ToDouble(this.PSOnb.Value);
            PSOparas[5] = Convert.ToDouble(this.PSOcp.Text);
            PSOparas[6] = Convert.ToDouble(this.PSOcg.Text);
            PSOparas[7] = Convert.ToDouble(this.PSOcl.Text);
            PSOparas[8] = Convert.ToDouble(this.PSOcn.Text);
            DateTime start = DateTime.Now;
            AniS = new ArrayList();
            //call PSO algorithm to minimize f(x)
            MainClass.PSO(fx, PSOparas, out ObjectiveValue, out Avg, out index, out Ani, out AniS, out GBest);

            TimeSpan finish = DateTime.Now - start;
            PSOGraph.GraphPane.CurveList.Clear();
            DrawGraph.CreateXY(PSOGraph, index, Avg);
            int density = 2000; //number of points used to construct the outline of a function within the pre-defined range
            #region drawGraph_function_outline
            double[] xx;
            double[] yy;
            PSO_Function.GraphPane.CurveList.Clear();
            xx = new double[1];
            yy = new double[1];
            xx[0] = GBest.BestP[0];
            yy[0] = GBest.ObjectiveP;
            DrawGraph.CreateXYScatter(PSO_Function, xx, yy, "F(x)", "Best Solution", Color.Red, 10f, ZedGraph.SymbolType.Triangle);
            xx = new double[density];
            yy = new double[density];
            for (int i = 0; i < density; i++)
            {
                xx[i] = ((Particle)((ArrayList)AniS[0])[0]).PosMin[0] + i * (((Particle)((ArrayList)AniS[0])[0]).PosMax[0] - ((Particle)((ArrayList)AniS[0])[0]).PosMin[0]) / density;
                yy[i] = Function.Test_Function(fx, xx[i]);
            }
            DrawGraph.CreateXYCurve(PSO_Function, xx, yy, "F(x)", "Function", Color.Blue);
            #endregion
            ObjVal.Text = finish.ToString();
            // Enable animation
            this.AniStep.Enabled = true;
            this.AniStepRun.Enabled = true;
            this.PSO_dynamic.Enabled = true;
            this.AniSpeed.Enabled = true;
        }
        private void PSO_dynamic_Click(object sender, EventArgs e)
        {
            int Aspeed = Int16.Parse(this.AniSpeed.Text);
            Istep=Int16.Parse(this.AniStep.Text);
            #region drawGraph of function
            double[] xx;
            double[] yy;
            PSO_Function.GraphPane.CurveList.Clear();
            int density = 2000;
            xx = new double[density];
            yy = new double[density];
            for (int i = 0; i < density; i++)
            {
                xx[i] = ((Particle)((ArrayList)AniS[0])[0]).PosMin[0] + i * (((Particle)((ArrayList)AniS[0])[0]).PosMax[0] - ((Particle)((ArrayList)AniS[0])[0]).PosMin[0]) / density;
                yy[i] = Function.Test_Function(fx, xx[i]);
            }          
            #endregion
            for (int s = Istep; s < AniS.Count; s++)
            {
                Animation.GraphPane.CurveList.Clear();
                DrawGraph.CreateXYCurve(Animation, xx, yy, "F(x)", "Function", Color.Blue);
                Step_Animate(pColor, s);
                Step_Animate_Swarm(pColor, s);
                System.Threading.Thread.Sleep(Aspeed);
            }
        }
        private void AniStep_Click(object sender, EventArgs e)
        {
            Istep = Int16.Parse(this.AniStep.Text)-1;
            this.Back.Enabled = true;
            this.Forward.Enabled = true;
            Animation.GraphPane.XAxis.Scale.MaxAuto = true;
            Animation.GraphPane.XAxis.Scale.MinAuto = true;
            Animation.GraphPane.YAxis.Scale.MaxAuto = true;
            Animation.GraphPane.YAxis.Scale.MinAuto = true;
        }
        private void Step_Animate(Color[] pColor, int s)
        {
                double[] xx = new double[1];
                double[] yy = new double[1];
                xx[0] = ((Particle)Ani[s]).BestP[0];
                yy[0] = ((Particle)Ani[s]).ObjectiveP;
                DrawGraph.CreateXYScatter(Animation, xx, yy, "Gbest", "Animation_Step" + s.ToString(), Color.Green, 10f, ZedGraph.SymbolType.Triangle);
            //choose whether the graph should be rescale after a number of step
            if ((s % 50 == 0) || (s == AniS.Count))
            {
                Animation.GraphPane.XAxis.Scale.MaxAuto = true;
                Animation.GraphPane.XAxis.Scale.MinAuto = true;
                Animation.GraphPane.YAxis.Scale.MaxAuto = true;
                Animation.GraphPane.YAxis.Scale.MinAuto = true;
            }
            else
            {
               // Animation.GraphPane.XAxis.Scale.MaxAuto = false;
               // Animation.GraphPane.XAxis.Scale.MinAuto = false;
               // Animation.GraphPane.YAxis.Scale.MaxAuto = false;
               // Animation.GraphPane.YAxis.Scale.MinAuto = false;
            }
        }
        private void Step_Animate_Swarm(Color[] pColor, int s)
        {
                double[] xx = new double[((ArrayList)AniS[s]).Count];
                double[] yy = new double[((ArrayList)AniS[s]).Count];
                //plot the current position of particles and their corresponding fitness (objective values)
                for (int i = 0; i < ((ArrayList)AniS[s]).Count; i++)
                {
                    xx[i] = ((Particle)((ArrayList)AniS[s])[i]).Position[0];
                    yy[i] = ((Particle)((ArrayList)AniS[s])[i]).Objective;
                }
                DrawGraph.CreateXYScatter(Animation, xx, yy, "particle", "Animation_StepS", pColor[3], 8f, ZedGraph.SymbolType.Circle);
                //plot the best found position of particles and their corresponding best objective values
                for (int i = 0; i < ((ArrayList)AniS[s]).Count; i++)
                {
                    xx[i] = ((Particle)((ArrayList)AniS[s])[i]).BestP[0];
                    yy[i] = ((Particle)((ArrayList)AniS[s])[i]).ObjectiveP;
                }
                DrawGraph.CreateXYScatter(Animation, xx, yy, "particle", "Animation_StepS", Color.Orange, 9f, ZedGraph.SymbolType.Diamond);

                    if ((s % 50 == 0) || (s == AniS.Count))
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
            if (Istep > AniS.Count - 1) 
            {
                MessageBox.Show("This is last step");
                Istep--;
                return;
            }
            Animation.GraphPane.CurveList.Clear();
            #region drawGraph
            double[] xx;
            double[] yy;
            PSO_Function.GraphPane.CurveList.Clear();
            int density = 2000;
            xx = new double[density];
            yy = new double[density];
            for (int i = 0; i < density; i++)
            {
                xx[i] = ((Particle)((ArrayList)AniS[0])[0]).PosMin[0] + i * (((Particle)((ArrayList)AniS[0])[0]).PosMax[0] - ((Particle)((ArrayList)AniS[0])[0]).PosMin[0]) / density;
                yy[i] = Function.Test_Function(fx, xx[i]);
            }

            #endregion
            DrawGraph.CreateXYCurve(Animation, xx, yy, "particle", "Animation_StepS", Color.Blue);
            #region drawDirection   
            xx = new double[2];
            yy = new double[2];
            xx[0] = ((Particle)((ArrayList)AniS[Istep])[0]).Position[0];
            yy[0] = ((Particle)((ArrayList)AniS[Istep])[0]).Objective;
            xx[1] = ((Particle)((ArrayList)AniS[Istep])[0]).BestP[0];
            yy[1] = ((Particle)((ArrayList)AniS[Istep])[0]).ObjectiveP;
            DrawGraph.CreateXYCurve(Animation, xx, yy, "direction", "Animation_StepS", Color.Orange);
            xx[1] = ((Particle)Ani[Istep]).BestP[0];
            yy[1] = ((Particle)Ani[Istep]).ObjectiveP;
            DrawGraph.CreateXYCurve(Animation, xx, yy, "direction", "Animation_StepS", Color.Green);
            #endregion
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
            Animation.GraphPane.CurveList.Clear();
            #region drawGraph
            double[] xx;
            double[] yy;
            PSO_Function.GraphPane.CurveList.Clear();
            int density = 2000;
            xx = new double[density];
            yy = new double[density];
            for (int i = 0; i < density; i++)
            {
                xx[i] = ((Particle)((ArrayList)AniS[0])[0]).PosMin[0] + i * (((Particle)((ArrayList)AniS[0])[0]).PosMax[0] - ((Particle)((ArrayList)AniS[0])[0]).PosMin[0]) / density;
                yy[i] = Function.Test_Function(fx, xx[i]);
            }

            #endregion
            DrawGraph.CreateXYCurve(Animation, xx, yy, "particle", "Animation_StepS", Color.Blue);
            #region drawDirection
            xx = new double[2];
            yy = new double[2];
            xx[0] = ((Particle)((ArrayList)AniS[Istep])[0]).Position[0];
            yy[0] = ((Particle)((ArrayList)AniS[Istep])[0]).Objective;
            xx[1] = ((Particle)((ArrayList)AniS[Istep])[0]).BestP[0];
            yy[1] = ((Particle)((ArrayList)AniS[Istep])[0]).ObjectiveP;
            DrawGraph.CreateXYCurve(Animation, xx, yy, "direction", "Animation_StepS", Color.Orange);
            xx[1] = ((Particle)Ani[Istep]).BestP[0];
            yy[1] = ((Particle)Ani[Istep]).ObjectiveP;
            DrawGraph.CreateXYCurve(Animation, xx, yy, "direction", "Animation_StepS", Color.Green);
            #endregion
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
        private void fxindex_ValueChanged(object sender, EventArgs e)
        {
            this.txtFunction.Text = Function.Get_Function_Text(Convert.ToInt32(this.fxindex.Value));
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}