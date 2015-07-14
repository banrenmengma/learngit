namespace PSO_basic_visual
{
    partial class PSO_basic_visual
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PSO_basic_visual));
            this.button1 = new System.Windows.Forms.Button();
            this.PSOGraph = new ZedGraph.ZedGraphControl();
            this.ObjVal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PSO_Function = new ZedGraph.ZedGraphControl();
            this.PSO_dynamic = new System.Windows.Forms.Button();
            this.RunPSO = new System.Windows.Forms.Button();
            this.Animation = new ZedGraph.ZedGraphControl();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AniStepRun = new System.Windows.Forms.Button();
            this.AniStep = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Back = new System.Windows.Forms.Button();
            this.Forward = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.AniSpeed = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.fxindex = new System.Windows.Forms.NumericUpDown();
            this.PSOpara = new System.Windows.Forms.GroupBox();
            this.PSOcn = new System.Windows.Forms.TextBox();
            this.PSOcl = new System.Windows.Forms.TextBox();
            this.PSOcg = new System.Windows.Forms.TextBox();
            this.PSOcp = new System.Windows.Forms.TextBox();
            this.PSOwmax = new System.Windows.Forms.TextBox();
            this.PSOwmin = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.PSOnb = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PSOnumParticles = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.PSOiter = new System.Windows.Forms.NumericUpDown();
            this.txtFunction = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.fxindex)).BeginInit();
            this.PSOpara.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PSOnb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSOnumParticles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSOiter)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Exit_Click);
            // 
            // PSOGraph
            // 
            resources.ApplyResources(this.PSOGraph, "PSOGraph");
            this.PSOGraph.Name = "PSOGraph";
            this.PSOGraph.ScrollGrace = 0;
            this.PSOGraph.ScrollMaxX = 0;
            this.PSOGraph.ScrollMaxY = 0;
            this.PSOGraph.ScrollMaxY2 = 0;
            this.PSOGraph.ScrollMinX = 0;
            this.PSOGraph.ScrollMinY = 0;
            this.PSOGraph.ScrollMinY2 = 0;
            // 
            // ObjVal
            // 
            resources.ApplyResources(this.ObjVal, "ObjVal");
            this.ObjVal.Name = "ObjVal";
            this.ObjVal.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // PSO_Function
            // 
            resources.ApplyResources(this.PSO_Function, "PSO_Function");
            this.PSO_Function.Name = "PSO_Function";
            this.PSO_Function.ScrollGrace = 0;
            this.PSO_Function.ScrollMaxX = 0;
            this.PSO_Function.ScrollMaxY = 0;
            this.PSO_Function.ScrollMaxY2 = 0;
            this.PSO_Function.ScrollMinX = 0;
            this.PSO_Function.ScrollMinY = 0;
            this.PSO_Function.ScrollMinY2 = 0;
            // 
            // PSO_dynamic
            // 
            resources.ApplyResources(this.PSO_dynamic, "PSO_dynamic");
            this.PSO_dynamic.Name = "PSO_dynamic";
            this.PSO_dynamic.UseVisualStyleBackColor = true;
            this.PSO_dynamic.Click += new System.EventHandler(this.PSO_dynamic_Click);
            // 
            // RunPSO
            // 
            resources.ApplyResources(this.RunPSO, "RunPSO");
            this.RunPSO.Name = "RunPSO";
            this.RunPSO.UseVisualStyleBackColor = true;
            this.RunPSO.Click += new System.EventHandler(this.Run_Click);
            // 
            // Animation
            // 
            resources.ApplyResources(this.Animation, "Animation");
            this.Animation.Name = "Animation";
            this.Animation.ScrollGrace = 0;
            this.Animation.ScrollMaxX = 0;
            this.Animation.ScrollMaxY = 0;
            this.Animation.ScrollMaxY2 = 0;
            this.Animation.ScrollMinX = 0;
            this.Animation.ScrollMinY = 0;
            this.Animation.ScrollMinY2 = 0;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // AniStepRun
            // 
            resources.ApplyResources(this.AniStepRun, "AniStepRun");
            this.AniStepRun.Name = "AniStepRun";
            this.AniStepRun.UseVisualStyleBackColor = true;
            this.AniStepRun.Click += new System.EventHandler(this.AniStep_Click);
            // 
            // AniStep
            // 
            resources.ApplyResources(this.AniStep, "AniStep");
            this.AniStep.ForeColor = System.Drawing.Color.Red;
            this.AniStep.Name = "AniStep";
            this.AniStep.TextChanged += new System.EventHandler(this.AniStep_TextChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // Back
            // 
            resources.ApplyResources(this.Back, "Back");
            this.Back.Name = "Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Forward
            // 
            resources.ApplyResources(this.Forward, "Forward");
            this.Forward.Name = "Forward";
            this.Forward.UseVisualStyleBackColor = true;
            this.Forward.Click += new System.EventHandler(this.Forward_Click);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // AniSpeed
            // 
            resources.ApplyResources(this.AniSpeed, "AniSpeed");
            this.AniSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.AniSpeed.Name = "AniSpeed";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Rescale_Click_1);
            // 
            // fxindex
            // 
            resources.ApplyResources(this.fxindex, "fxindex");
            this.fxindex.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.fxindex.Name = "fxindex";
            this.fxindex.ValueChanged += new System.EventHandler(this.fxindex_ValueChanged);
            // 
            // PSOpara
            // 
            this.PSOpara.Controls.Add(this.PSOcn);
            this.PSOpara.Controls.Add(this.PSOcl);
            this.PSOpara.Controls.Add(this.PSOcg);
            this.PSOpara.Controls.Add(this.PSOcp);
            this.PSOpara.Controls.Add(this.PSOwmax);
            this.PSOpara.Controls.Add(this.PSOwmin);
            this.PSOpara.Controls.Add(this.label15);
            this.PSOpara.Controls.Add(this.PSOnb);
            this.PSOpara.Controls.Add(this.label13);
            this.PSOpara.Controls.Add(this.label14);
            this.PSOpara.Controls.Add(this.label11);
            this.PSOpara.Controls.Add(this.label12);
            this.PSOpara.Controls.Add(this.label10);
            this.PSOpara.Controls.Add(this.label9);
            this.PSOpara.Controls.Add(this.label8);
            this.PSOpara.Controls.Add(this.PSOnumParticles);
            this.PSOpara.Controls.Add(this.label2);
            this.PSOpara.Controls.Add(this.PSOiter);
            resources.ApplyResources(this.PSOpara, "PSOpara");
            this.PSOpara.Name = "PSOpara";
            this.PSOpara.TabStop = false;
            // 
            // PSOcn
            // 
            resources.ApplyResources(this.PSOcn, "PSOcn");
            this.PSOcn.Name = "PSOcn";
            // 
            // PSOcl
            // 
            resources.ApplyResources(this.PSOcl, "PSOcl");
            this.PSOcl.Name = "PSOcl";
            // 
            // PSOcg
            // 
            resources.ApplyResources(this.PSOcg, "PSOcg");
            this.PSOcg.Name = "PSOcg";
            // 
            // PSOcp
            // 
            resources.ApplyResources(this.PSOcp, "PSOcp");
            this.PSOcp.Name = "PSOcp";
            // 
            // PSOwmax
            // 
            resources.ApplyResources(this.PSOwmax, "PSOwmax");
            this.PSOwmax.Name = "PSOwmax";
            // 
            // PSOwmin
            // 
            resources.ApplyResources(this.PSOwmin, "PSOwmin");
            this.PSOwmin.Name = "PSOwmin";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // PSOnb
            // 
            resources.ApplyResources(this.PSOnb, "PSOnb");
            this.PSOnb.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.PSOnb.Name = "PSOnb";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // PSOnumParticles
            // 
            resources.ApplyResources(this.PSOnumParticles, "PSOnumParticles");
            this.PSOnumParticles.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PSOnumParticles.Name = "PSOnumParticles";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // PSOiter
            // 
            resources.ApplyResources(this.PSOiter, "PSOiter");
            this.PSOiter.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PSOiter.Name = "PSOiter";
            // 
            // txtFunction
            // 
            resources.ApplyResources(this.txtFunction, "txtFunction");
            this.txtFunction.Name = "txtFunction";
            this.txtFunction.ReadOnly = true;
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.AniSpeed);
            this.groupBox1.Controls.Add(this.Forward);
            this.groupBox1.Controls.Add(this.Back);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.AniStep);
            this.groupBox1.Controls.Add(this.AniStepRun);
            this.groupBox1.Controls.Add(this.PSO_dynamic);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // PSO_basic_visual
            // 
            this.AcceptButton = this.RunPSO;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtFunction);
            this.Controls.Add(this.PSOpara);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.fxindex);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Animation);
            this.Controls.Add(this.RunPSO);
            this.Controls.Add(this.PSO_Function);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ObjVal);
            this.Controls.Add(this.PSOGraph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PSO_basic_visual";
            this.Load += new System.EventHandler(this.PSObasic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fxindex)).EndInit();
            this.PSOpara.ResumeLayout(false);
            this.PSOpara.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PSOnb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSOnumParticles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSOiter)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private ZedGraph.ZedGraphControl PSOGraph;
        private System.Windows.Forms.TextBox ObjVal;
        private System.Windows.Forms.Label label1;
        private ZedGraph.ZedGraphControl PSO_Function;
        private System.Windows.Forms.Button PSO_dynamic;
        private System.Windows.Forms.Button RunPSO;
        private ZedGraph.ZedGraphControl Animation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AniStepRun;
        private System.Windows.Forms.TextBox AniStep;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button Forward;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox AniSpeed;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown fxindex;
        private System.Windows.Forms.GroupBox PSOpara;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown PSOiter;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown PSOnumParticles;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown PSOnb;
        private System.Windows.Forms.TextBox PSOcn;
        private System.Windows.Forms.TextBox PSOcl;
        private System.Windows.Forms.TextBox PSOcg;
        private System.Windows.Forms.TextBox PSOcp;
        private System.Windows.Forms.TextBox PSOwmax;
        private System.Windows.Forms.TextBox PSOwmin;
        private System.Windows.Forms.TextBox txtFunction;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

