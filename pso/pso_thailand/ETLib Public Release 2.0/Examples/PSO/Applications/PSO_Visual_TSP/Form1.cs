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

namespace PSO_basic_visual_TSP
{
    public partial class Form1 : ETForm
    {
        Tour myTour;
        ArrayList Ani;
        ArrayList AniS;
        Particle GBest;
        public int Istep;
        int fx = 0;
        Color[] pColor = new Color[5];
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {   
            //SupportTest();
            pColor[0] = Color.Yellow;
            pColor[1] = Color.DarkGray;
            pColor[2] = Color.Blue;
            pColor[3] = Color.Red;
            pColor[4] = Color.Green;
            Istep=0;
            this.AniStep.Text = Istep.ToString();
            this.AniSpeed.Text = "100";
            this.PSOiter.Value = 200;
            this.PSOnumParticles.Value = 50;
            this.PSOwmin.Text = "0.4";
            this.PSOwmax.Text="0.9";
            this.PSOnb.Value=5;
            this.PSOcp.Text = "2";
            this.PSOcg.Text = "2";
            this.PSOcl.Text = "0";
            this.PSOcn.Text = "0";
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PSO_dynamic_Click(object sender, EventArgs e)
        {
            int Aspeed = Int16.Parse(this.AniSpeed.Text);
            Istep=Int16.Parse(this.AniStep.Text);
            #region drawGraph
            double[] xx;
            double[] yy;
            //PSO_Function.GraphPane.CurveList.Clear();
            xx = new double[myTour.NumLocs];
            yy = new double[myTour.NumLocs];
            for (int i = 0; i < myTour.NumLocs; i++)
            {
                xx[i] = myTour.loc[i].X;
                yy[i] = myTour.loc[i].Y;
            }         
            #endregion
            for (int s = Istep; s < AniS.Count; s++)
            {
                Animation.GraphPane.CurveList.Clear();
                DrawGraph.CreateXYScatter(Animation, xx, yy, "Location", "Best Solution", Color.Blue, 10f, ZedGraph.SymbolType.Circle);
                Step_Animate(pColor, s);
                System.Threading.Thread.Sleep(Aspeed);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            double ObjectiveValue;
            double[] index;
            double[] Avg;
            double[] PSOparas = new double[9];
            #region setPSOparamater
            myTour=new Tour();
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
            #endregion
            MainClass.PSO(out myTour,fx,PSOparas, out ObjectiveValue, out Avg, out index, out Ani,out AniS,out GBest);

            TimeSpan finish = DateTime.Now - start;

            #region drawGraph_function_outline
            double[] xx;
            double[] yy;
            PSOGraph.GraphPane.CurveList.Clear();
            PSO_Function.GraphPane.CurveList.Clear();
            
            //draw locations
            xx = new double[myTour.NumLocs];
            yy = new double[myTour.NumLocs];
            for (int i = 0; i < myTour.NumLocs; i++)
            {
                xx[i] = myTour.loc[i].X;
                yy[i] = myTour.loc[i].Y;
            }
            DrawGraph.CreateXYScatter(PSO_Function, xx, yy, "Location", "Best Solution", Color.Blue, 10f, ZedGraph.SymbolType.Circle);
            //draw global best tour
            int[] visitOrder = new int[myTour.NumLocs];
            xx = new double[myTour.NumLocs+1];
            yy = new double[myTour.NumLocs+1];
            visitOrder = myTour.getTour(GBest.BestP);
            xx[0] = myTour.loc[0].X;
            yy[0] = myTour.loc[0].Y;

            for (int i = 1; i < myTour.NumLocs; i++)
            {
                xx[i] = myTour.loc[visitOrder[i - 1]].X;
                yy[i] = myTour.loc[visitOrder[i - 1]].Y;
            }
            xx[myTour.NumLocs] = myTour.loc[0].X;
            yy[myTour.NumLocs] = myTour.loc[0].Y;
            DrawGraph.CreateXYCurve(PSO_Function, xx, yy, "Best Tour", "Best Tour's Distance " + GBest.ObjectiveP.ToString(), Color.Red,false);            //draw average objective value at each iteration
            //draw average objective value at each iteration
            DrawGraph.CreateXY(PSOGraph, index, Avg);
            //draw best objective at each iteration
            xx = new double[Ani.Count];
            yy = new double[Ani.Count];
            for (int i = 0; i < Ani.Count; i++)
            {
                xx[i] = i;
                yy[i] = ((Particle)Ani[i]).ObjectiveP;
            }
            DrawGraph.CreateXYCurve(PSOGraph, xx, yy, "F(x)", "Function", Color.Blue,true);
            #endregion

            ObjVal.Text = finish.ToString();
            //NumberPareto.Text = Pareto.Count.ToString();
            // Enable animation function
            this.AniStep.Enabled = true;
            this.AniStepRun.Enabled = true;
            this.PSO_dynamic.Enabled = true;
            this.AniSpeed.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
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
            int[] visitOrder = new int[myTour.NumLocs];
            double[] xx;
            double[] yy;
            xx = new double[myTour.NumLocs + 1];
            yy = new double[myTour.NumLocs + 1];
            visitOrder = myTour.getTour(((Particle)Ani[s]).BestP);
            xx[0] = myTour.loc[0].X;
            yy[0] = myTour.loc[0].Y;

            for (int i = 1; i < myTour.NumLocs; i++)
            {
                xx[i] = myTour.loc[visitOrder[i - 1]].X;
                yy[i] = myTour.loc[visitOrder[i - 1]].Y;
            }
            xx[myTour.NumLocs] = myTour.loc[0].X;
            yy[myTour.NumLocs] = myTour.loc[0].Y;
            DrawGraph.CreateXYCurve(Animation, xx, yy, "Best Tour", "Animation Step "
                + s.ToString() + " Best Tour's Distance " +
                ((Particle)Ani[s]).ObjectiveP.ToString("F2"), Color.Red, false);            //draw average objective value at each iteration

            if ((s % 50 == 0) || (s == AniS.Count))
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
        private void Forward_Click(object sender, EventArgs e)
        {
            Istep++;
            if (Istep > AniS.Count - 1) 
            {
                MessageBox.Show("This is last step");
                Istep--;
                return;
            }
            #region drawGraph
            double[] xx;
            double[] yy;
            //PSO_Function.GraphPane.CurveList.Clear();
            xx = new double[myTour.NumLocs];
            yy = new double[myTour.NumLocs];
            for (int i = 0; i < myTour.NumLocs; i++)
            {
                xx[i] = myTour.loc[i].X;
                yy[i] = myTour.loc[i].Y;
            }
            #endregion
            Animation.GraphPane.CurveList.Clear();
            DrawGraph.CreateXYScatter(Animation, xx, yy, "Location", "Best Solution", Color.Blue, 10f, ZedGraph.SymbolType.Circle);
            Step_Animate(pColor, Istep);
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
            #region drawGraph
            double[] xx;
            double[] yy;
            //PSO_Function.GraphPane.CurveList.Clear();
            xx = new double[myTour.NumLocs];
            yy = new double[myTour.NumLocs];
            for (int i = 0; i < myTour.NumLocs; i++)
            {
                xx[i] = myTour.loc[i].X;
                yy[i] = myTour.loc[i].Y;
            }
            #endregion
            Animation.GraphPane.CurveList.Clear();
            DrawGraph.CreateXYScatter(Animation, xx, yy, "Location", "Best Solution", Color.Blue, 10f, ZedGraph.SymbolType.Circle);
            Step_Animate(pColor, Istep);
        }

        private void AniStep_TextChanged(object sender, EventArgs e)
        {
            this.Back.Enabled = false;
            this.Forward.Enabled = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Animation.GraphPane.XAxis.Scale.MaxAuto = true;
            Animation.GraphPane.XAxis.Scale.MinAuto = true;
            Animation.GraphPane.YAxis.Scale.MaxAuto = true;
            Animation.GraphPane.YAxis.Scale.MinAuto = true;
        }
    }
}