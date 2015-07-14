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
using ZedGraph;
using System.Drawing;

namespace PSO_MutiObjective
{
    class DrawGraph
    {
        public static void CreateXY(ZedGraphControl zgc, double[] step, double[] Val,Color color,int obj)
        {
            GraphPane myPane = zgc.GraphPane;
            // Set the Titles 
            myPane.Title.Text = "Performance";
            myPane.XAxis.Title.Text = " Generation ";
            myPane.YAxis.Title.Text = " Avg ";
            // myPane.XAxis.Scale.FontSpec.Size = 5;

            LineItem myCurve = myPane.AddCurve("f_" + obj.ToString(),step
                , Val,Color.Black, SymbolType.Circle);
            myCurve.Symbol.IsVisible = true;

            // Fix up the curve attributes a little 
            myCurve.Symbol.Size = 5.0F;
            myCurve.Symbol.Fill = new Fill(color);
            myCurve.Line.Width = 1.5F;
            myCurve.Line.IsSmooth = true;
            myCurve.Line.SmoothTension = 0.5F;
            myCurve.Line.Color = color;
            // Draw the X tics between the labels instead of  
            // at the labels 
            myPane.XAxis.MajorTic.IsBetweenLabels = true;

            myPane.YAxis.Scale.FontSpec.FontColor = Color.Blue;
            myPane.YAxis.Title.FontSpec.FontColor = Color.Blue;

 
            //myPane.Chart.Fill = new Fill(Color.White,                  Color.FromArgb(255, 255, 166), 90F);
            myPane.Legend.IsVisible = true;
            myPane.YAxis.MinorTic.IsAllTics = false;

            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;
            myPane.YAxis.MajorGrid.IsVisible = true;
            //myPane.YAxis.MajorGrid.IsVisible = true;
            //myPane.Fill = new Fill(Color.FromArgb(250, 250, 255));
            myPane.Legend.Position = ZedGraph.LegendPos.BottomCenter;
            //myPane.BarSettings.Type = BarType.Stack;
            // Tell ZedGraph to refigure the 
            // axes since the data have changed 
            zgc.AxisChange();
            zgc.Refresh();
        }
        public static void CreateXYScatter(ZedGraphControl zgc, double[] x, double[] y, string legend, string title,Color C)
        {
            GraphPane myPane = zgc.GraphPane;
            // Set the Titles 
            if (title!="Animation_StepS")
            myPane.Title.Text =title;
            myPane.XAxis.Title.Text = " f_1 ";
            myPane.YAxis.Title.Text = " f_2 ";
            // myPane.XAxis.Scale.FontSpec.Size = 5;

            LineItem myCurve = myPane.AddCurve(legend, x
                , y, Color.Black, SymbolType.Circle);
            myCurve.Symbol.IsVisible = true;

            myCurve.Line.IsVisible = false;
            // Fix up the curve attributes a little 
            myCurve.Symbol.Size = 7.0F;
            myCurve.Symbol.Fill = new Fill(C);
            if (title != "Animation_StepS")
            {
                myCurve.Symbol.Type = ZedGraph.SymbolType.Triangle;
            }
            myCurve.Line.Width = 1.5F;
            myCurve.Line.IsSmooth = true;
            myCurve.Line.SmoothTension = 0.5F;
            myCurve.Line.Color = Color.Red;
            // Draw the X tics between the labels instead of  
            // at the labels 

            myPane.XAxis.MajorTic.IsBetweenLabels = true;

            myPane.YAxis.Scale.FontSpec.FontColor = Color.Blue;
            myPane.YAxis.Title.FontSpec.FontColor = Color.Blue;


            //myPane.Chart.Fill = new Fill(Color.White,                  Color.FromArgb(255, 255, 166), 90F);
            myPane.Legend.IsVisible = false;
            
            myPane.YAxis.MinorTic.IsAllTics = false;

            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;
            myPane.YAxis.MajorGrid.IsVisible = true;
            //myPane.YAxis.MajorGrid.IsVisible = true;
            //myPane.Fill = new Fill(Color.FromArgb(250, 250, 255));
            myPane.Legend.Position = ZedGraph.LegendPos.BottomCenter;
            //myPane.BarSettings.Type = BarType.Stack;
            // Tell ZedGraph to refigure the 
            // axes since the data have changed 
            zgc.AxisChange();
            zgc.Refresh();
        }
    }
}
