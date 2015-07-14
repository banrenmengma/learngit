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
using System.Drawing.Drawing2D;
using Chart3DLib;
using ETLib_AniPSO;

namespace PSO_basic_visual
{
    public partial class PSO3D : ETForm
    {
        ArrayList Ani;
        ArrayList AniS;
        Particle GBest;
        public int Istep;
        int fx = 0;
        Color[] pColor = new Color[5];
        int type = 0;
        ColorMap cm;
        Point3[,] pts;
        Point3[,] pt;
        Point3[,] pt1;
        Point3[,] pt2;
        double minf = +1e13;
        double maxf = -1e13;
        double density = 0.04;
        public PSO3D()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            cm = new ColorMap();
        }
        private void PSO3D_Load(object sender, EventArgs e)
        {
            //SupportTest();
            pColor[0] = Color.Yellow;
            pColor[1] = Color.DarkGray;
            pColor[2] = Color.Blue;
            pColor[3] = Color.Red;
            pColor[4] = Color.Green;
            Istep = 0;
            this.AniStep.Text = Istep.ToString();
            this.AniSpeed.Text = "100";
            this.PSOiter.Value = 100;
            this.PSOnumParticles.Value = 5;
            this.PSOwmin.Text = "0.4";
            this.PSOwmax.Text = "0.9";
            this.PSOnb.Value = 5;
            this.PSOcp.Text = "2";
            this.PSOcg.Text = "2";
            this.PSOcl.Text = "0";
            this.PSOcn.Text = "0";
            fx = Convert.ToInt32(this.fxindex.Value);
            this.txtFunction.Text = Function.Get_Function_Text(fx);
            this.fxindex.Maximum = Function.numF() - 1;
        } 
        private void btnRunPSO_Click(object sender, EventArgs e)
        {
            double ObjectiveValue;
            double[] index;
            double[] Avg;
            double[] PSOparas = new double[9];
            fx = Convert.ToInt32(this.fxindex.Value); //determine the function to be minimized
            //set PSO parameters
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
            //call PSO algorithm to minimize function fx
            MainClass.PSO(fx, PSOparas, out ObjectiveValue, out Avg, out index, out Ani, out AniS, out GBest);
            TimeSpan finish = DateTime.Now - start;
            //Clear the current graph
            PSOGraph.GraphPane.CurveList.Clear();
            //Draw average performance via the search
            DrawGraph.CreateXY(PSOGraph, index, Avg);
            
            #region drawGraph_function_outline
            //global best position
            pts = new Point3[1, 1];
            pts[0, 0] = new Point3((float)GBest.BestP[0], (float)GBest.BestP[1], (float)GBest.ObjectiveP, 1);
            //draw graph of function fx with global best position
            Draw3DFunction(this.chart3D1, 0, fx, density, GBest.PosMin[0], GBest.PosMax[0], GBest.PosMin[1], GBest.PosMax[1], pts, pt1);
            #endregion

            ComTime.Text = finish.ToString();

            // Enable animation function
            this.AniStep.Enabled = true;
            this.AniStepRun.Enabled = true;
            this.PSO_dynamic.Enabled = true;
            this.AniSpeed.Enabled = true;
            this.btnEDown.Enabled = true;
            this.btnEUp.Enabled = true;
            this.btnRleft.Enabled = true;
            this.btnRright.Enabled = true;
        }
        private void Draw3DFunction(Chart3D c3d,int mode,int fx, double density,double minX,double maxX,double minY,double maxY,Point3[,] sP, Point3[,] P)
        {
            c3d.C3DrawChart.CMap = cm.Jet(); //select theme for surface plotting
            c3d.C3DrawChart.ChartType = DrawChart.ChartTypeEnum.Scatter3D; //select chart type
            c3d.C3ChartStyle.IsColorBar = true;
            c3d.C3Labels.Title = "";
            c3d.C3DataSeries.LineStyle.IsVisible = false;
            c3d.mode = mode; //select drawing mode
            Setdata(c3d,fx,density,minX,maxX,minY,maxY,sP,P);
        }
        private void Setdata(Chart3D c3d, int fx, double density, double minX, double maxX, double minY, double maxY, Point3[,] sP, Point3[,] P)
        {
            //set the lower/upper bound with offset
            c3d.C3Axes.XMin = (float)minX - (float)(0.2 * (Function.upperP(this.fx) - Function.lowerP(this.fx)));
            c3d.C3Axes.XMax = (float)maxX + (float)(0.2 * (Function.upperP(this.fx) - Function.lowerP(this.fx)));
            c3d.C3Axes.YMin = (float)minY - (float)(0.2 * (Function.upperP(this.fx) - Function.lowerP(this.fx)));
            c3d.C3Axes.YMax = (float)maxY + (float)(0.2 * (Function.upperP(this.fx) - Function.lowerP(this.fx)));

            c3d.C3Axes.XTick = (float)(0.25 * (maxX - minX));
            c3d.C3Axes.YTick = (float)(0.25 * (maxY - minY));

            c3d.C3DataSeries.XDataMin = c3d.C3Axes.XMin;
            c3d.C3DataSeries.YDataMin = c3d.C3Axes.YMin;
            //set space between points for surface plotting
            c3d.C3DataSeries.XSpacing = (float)(density * (maxX - minX));
            c3d.C3DataSeries.YSpacing = (float)(density * (maxY - minY));
            c3d.C3DataSeries.XNumber = Convert.ToInt16((c3d.C3Axes.XMax -
                c3d.C3Axes.XMin) / c3d.C3DataSeries.XSpacing) + 1;
            c3d.C3DataSeries.YNumber = Convert.ToInt16((c3d.C3Axes.YMax -
                c3d.C3Axes.YMin) / c3d.C3DataSeries.YSpacing) + 1;
            
            P = new Point3[c3d.C3DataSeries.XNumber,
                c3d.C3DataSeries.YNumber];
            minf = +1e13;
            maxf = -1e13;
            //calculate necessary points for surface plotting
            for (int i = 0; i < c3d.C3DataSeries.XNumber; i++)
            {
                for (int j = 0; j < c3d.C3DataSeries.YNumber; j++)
                {
                    float x = c3d.C3DataSeries.XDataMin +
                        i * c3d.C3DataSeries.XSpacing;
                    float y = c3d.C3DataSeries.YDataMin +
                        j * c3d.C3DataSeries.YSpacing;
                    double zz = 0;
                    double[] point = { x, y };
                    zz = Function.Test_Function(fx,point);
                    if (minf > zz) minf = zz;
                    if (maxf < zz) maxf = zz;
                    float z = (float)zz;
                    P[i, j] = new Point3(x, y, z, 1);
                }
            }
            c3d.C3Axes.ZMin = (float)minf;
            c3d.C3Axes.ZMax = (float)maxf;
            
            c3d.C3Axes.ZTick = (float)(0.25 * (maxf - minf));
            c3d.C3DataSeriesSupport.PointArray = P;
            c3d.C3DataSeries.PointArray = sP;
        } 

        private void PSO_dynamic_Click(object sender, EventArgs e)
        {
            chart3D1.mode = 1;
            int Aspeed = Int16.Parse(this.AniSpeed.Text);
            Istep = Int16.Parse(this.AniStep.Text);
            if ((Istep > AniS.Count - 1) || (Istep < 0))
            {
                MessageBox.Show("Out of range");
                return;
            }
            for (int s = Istep; s < AniS.Count; s++)
            {
                this.lAniStep.Text = "Animation Step " + s.ToString();
                Step_Animate(pColor, s);
                chart3D2.Select();
                chart3D2.Invalidate();
                this.Refresh();
                System.Threading.Thread.Sleep(Aspeed);
            }
        }
        private void Step_Animate(Color[] pColor, int s)
        {
            fx = Convert.ToInt32(this.fxindex.Value);
            double density = 0.04;
            #region drawGraph_function_outline
            pt = new Point3[((ArrayList)AniS[s]).Count, 1];
            for (int i = 0; i < ((ArrayList)AniS[s]).Count; i++)
            {
                pt[i, 0] = new Point3((float)((Particle)((ArrayList)AniS[s])[i]).Position[0],
                    (float)((Particle)((ArrayList)AniS[s])[i]).Position[1],(float)((Particle)((ArrayList)AniS[s])[i]).Objective,1);
            }            
            if (s==Istep)Draw3DFunction(this.chart3D2, 0, fx, density, GBest.PosMin[0], GBest.PosMax[0], GBest.PosMin[1], GBest.PosMax[1], pt,pt2);
            if (s != Istep) Draw3DFunction(this.chart3D2, 2, fx, density, GBest.PosMin[0], GBest.PosMax[0], GBest.PosMin[1], GBest.PosMax[1], pt, pt2);
            #endregion        
        }
        private void AniStepRun_Click(object sender, EventArgs e)
        {
            chart3D1.mode = 1;
            Istep = Int16.Parse(this.AniStep.Text);
            if ((Istep > AniS.Count - 1) || (Istep < 0))
            {
                MessageBox.Show("Out of range");
                return;
            }
            int s = Istep;
            AniStepStep(s);
            this.Back.Enabled = true;
            this.Forward.Enabled = true;
        }
        private void AniStepStep(int s)
        {
            this.lAniStep.Text = "Animation Step " + s.ToString();
            Step_Animate(pColor, s);
            chart3D2.Select();
            chart3D2.Invalidate();
            this.Refresh();
        }
        private void Forward_Click(object sender, EventArgs e)
        {
            Istep++;
            if ((Istep > AniS.Count - 1) || (Istep < 0)) 
            {
                MessageBox.Show("Out of range");
                Istep--;
                return;
            }
            AniStepStep(Istep);
        }
        private void Back_Click(object sender, EventArgs e)
        {
            Istep--;
            if ((Istep > AniS.Count - 1) || (Istep < 0))
            {
                MessageBox.Show("Out of range");
                Istep++;
                return;
            }
            AniStepStep(Istep);
        }

        private void AniStep_TextChanged(object sender, EventArgs e)
        {
            this.Back.Enabled = false;
            this.Forward.Enabled = false;
        }
        private void fxindex_ValueChanged(object sender, EventArgs e)
        {
            this.txtFunction.Text = Function.Get_Function_Text(Convert.ToInt32(this.fxindex.Value));
        }
        private void btnRright_Click(object sender, EventArgs e)
        {
            chart3D1.mode = 1;
            Istep = Int16.Parse(this.AniStep.Text);
            int s = Istep;
            if (chart3D2.C3ViewAngle.Azimuth + 10f > 180f) chart3D2.C3ViewAngle.Azimuth = 180f;
            if (chart3D2.C3ViewAngle.Azimuth + 10f <= 180f)
                chart3D2.C3ViewAngle.Azimuth += 10f;
            AniStepStep(s);
        }
        private void btnRleft_Click(object sender, EventArgs e)
        {
            chart3D1.mode = 1;
            Istep = Int16.Parse(this.AniStep.Text);
            int s = Istep;
            if (chart3D2.C3ViewAngle.Azimuth - 10f < -180f) chart3D2.C3ViewAngle.Azimuth = -180f;
            if (chart3D2.C3ViewAngle.Azimuth - 10f >= -180f)
                chart3D2.C3ViewAngle.Azimuth -= 10f;
            AniStepStep(s);
        }
        private void btnEDown_Click(object sender, EventArgs e)
        {
            chart3D1.mode = 1;
            Istep = Int16.Parse(this.AniStep.Text);
            int s = Istep;
            if (chart3D2.C3ViewAngle.Elevation - 5f < -90f) chart3D2.C3ViewAngle.Elevation = -90f;
            if (chart3D2.C3ViewAngle.Elevation - 5f >= -90f)
                chart3D2.C3ViewAngle.Elevation -= 5f;
            AniStepStep(s);
        }
        private void btnEUp_Click(object sender, EventArgs e)
        {
            chart3D1.mode = 1;
            Istep = Int16.Parse(this.AniStep.Text);
            int s = Istep;
            if (chart3D2.C3ViewAngle.Elevation + 5f > 90f) chart3D2.C3ViewAngle.Elevation = 90f;
            if (chart3D2.C3ViewAngle.Elevation + 5f <= 90f)
                chart3D2.C3ViewAngle.Elevation += 5f;
            AniStepStep(s);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //do nothing to prevent flickering
        }
    }
}