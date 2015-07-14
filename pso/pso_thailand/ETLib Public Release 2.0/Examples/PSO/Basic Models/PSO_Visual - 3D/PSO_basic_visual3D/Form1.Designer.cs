namespace PSO_basic_visual
{
    partial class PSO3D
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
            Chart3DLib.LineStyle lineStyle1 = new Chart3DLib.LineStyle();
            Chart3DLib.DataSeries dataSeries1 = new Chart3DLib.DataSeries();
            Chart3DLib.BarStyle barStyle1 = new Chart3DLib.BarStyle();
            Chart3DLib.LineStyle lineStyle2 = new Chart3DLib.LineStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PSO3D));
            Chart3DLib.DataSeries dataSeries2 = new Chart3DLib.DataSeries();
            Chart3DLib.BarStyle barStyle2 = new Chart3DLib.BarStyle();
            Chart3DLib.LineStyle lineStyle3 = new Chart3DLib.LineStyle();
            Chart3DLib.LineStyle lineStyle4 = new Chart3DLib.LineStyle();
            Chart3DLib.LineStyle lineStyle5 = new Chart3DLib.LineStyle();
            Chart3DLib.DataSeries dataSeries3 = new Chart3DLib.DataSeries();
            Chart3DLib.BarStyle barStyle3 = new Chart3DLib.BarStyle();
            Chart3DLib.LineStyle lineStyle6 = new Chart3DLib.LineStyle();
            Chart3DLib.DataSeries dataSeries4 = new Chart3DLib.DataSeries();
            Chart3DLib.BarStyle barStyle4 = new Chart3DLib.BarStyle();
            Chart3DLib.LineStyle lineStyle7 = new Chart3DLib.LineStyle();
            Chart3DLib.LineStyle lineStyle8 = new Chart3DLib.LineStyle();
            this.btnExit = new System.Windows.Forms.Button();
            this.PSOGraph = new ZedGraph.ZedGraphControl();
            this.ComTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PSO_dynamic = new System.Windows.Forms.Button();
            this.RunPSO = new System.Windows.Forms.Button();
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
            this.btnRleft = new System.Windows.Forms.Button();
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
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnRright = new System.Windows.Forms.Button();
            this.btnEUp = new System.Windows.Forms.Button();
            this.btnEDown = new System.Windows.Forms.Button();
            this.lAniStep = new System.Windows.Forms.Label();
            this.chart3D2 = new Chart3DLib.Chart3D();
            this.chart3D1 = new Chart3DLib.Chart3D();
            ((System.ComponentModel.ISupportInitialize)(this.fxindex)).BeginInit();
            this.PSOpara.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PSOnb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSOnumParticles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSOiter)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(747, 639);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(105, 26);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // PSOGraph
            // 
            this.PSOGraph.Location = new System.Drawing.Point(22, 305);
            this.PSOGraph.Name = "PSOGraph";
            this.PSOGraph.ScrollGrace = 0;
            this.PSOGraph.ScrollMaxX = 0;
            this.PSOGraph.ScrollMaxY = 0;
            this.PSOGraph.ScrollMaxY2 = 0;
            this.PSOGraph.ScrollMinX = 0;
            this.PSOGraph.ScrollMinY = 0;
            this.PSOGraph.ScrollMinY2 = 0;
            this.PSOGraph.Size = new System.Drawing.Size(278, 192);
            this.PSOGraph.TabIndex = 1;
            // 
            // ComTime
            // 
            this.ComTime.Location = new System.Drawing.Point(279, 635);
            this.ComTime.Name = "ComTime";
            this.ComTime.ReadOnly = true;
            this.ComTime.Size = new System.Drawing.Size(100, 20);
            this.ComTime.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(276, 615);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Computational Time";
            // 
            // PSO_dynamic
            // 
            this.PSO_dynamic.Enabled = false;
            this.PSO_dynamic.Location = new System.Drawing.Point(34, 70);
            this.PSO_dynamic.Name = "PSO_dynamic";
            this.PSO_dynamic.Size = new System.Drawing.Size(100, 26);
            this.PSO_dynamic.TabIndex = 7;
            this.PSO_dynamic.Text = "Animate";
            this.PSO_dynamic.UseVisualStyleBackColor = true;
            this.PSO_dynamic.Click += new System.EventHandler(this.PSO_dynamic_Click);
            // 
            // RunPSO
            // 
            this.RunPSO.Location = new System.Drawing.Point(279, 584);
            this.RunPSO.Name = "RunPSO";
            this.RunPSO.Size = new System.Drawing.Size(105, 26);
            this.RunPSO.TabIndex = 8;
            this.RunPSO.Text = "RunPSO";
            this.RunPSO.UseVisualStyleBackColor = true;
            this.RunPSO.Click += new System.EventHandler(this.btnRunPSO_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Final Solution";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Average Objective";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(336, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Animation";
            // 
            // AniStepRun
            // 
            this.AniStepRun.Enabled = false;
            this.AniStepRun.Location = new System.Drawing.Point(169, 70);
            this.AniStepRun.Name = "AniStepRun";
            this.AniStepRun.Size = new System.Drawing.Size(113, 26);
            this.AniStepRun.TabIndex = 13;
            this.AniStepRun.Text = "Step Animate";
            this.AniStepRun.UseVisualStyleBackColor = true;
            this.AniStepRun.Click += new System.EventHandler(this.AniStepRun_Click);
            // 
            // AniStep
            // 
            this.AniStep.Enabled = false;
            this.AniStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.AniStep.ForeColor = System.Drawing.Color.Red;
            this.AniStep.Location = new System.Drawing.Point(34, 44);
            this.AniStep.Name = "AniStep";
            this.AniStep.Size = new System.Drawing.Size(100, 20);
            this.AniStep.TabIndex = 14;
            this.AniStep.TextChanged += new System.EventHandler(this.AniStep_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Animation from step";
            // 
            // Back
            // 
            this.Back.Enabled = false;
            this.Back.Location = new System.Drawing.Point(169, 105);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(49, 26);
            this.Back.TabIndex = 16;
            this.Back.Text = "<<";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Forward
            // 
            this.Forward.Enabled = false;
            this.Forward.Location = new System.Drawing.Point(233, 105);
            this.Forward.Name = "Forward";
            this.Forward.Size = new System.Drawing.Size(49, 26);
            this.Forward.TabIndex = 17;
            this.Forward.Text = ">>";
            this.Forward.UseVisualStyleBackColor = true;
            this.Forward.Click += new System.EventHandler(this.Forward_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(166, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Ani_Speed (ms/step)";
            // 
            // AniSpeed
            // 
            this.AniSpeed.Enabled = false;
            this.AniSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.AniSpeed.ForeColor = System.Drawing.Color.Green;
            this.AniSpeed.Location = new System.Drawing.Point(169, 44);
            this.AniSpeed.Name = "AniSpeed";
            this.AniSpeed.Size = new System.Drawing.Size(113, 20);
            this.AniSpeed.TabIndex = 18;
            // 
            // btnRleft
            // 
            this.btnRleft.Enabled = false;
            this.btnRleft.Location = new System.Drawing.Point(561, 503);
            this.btnRleft.Name = "btnRleft";
            this.btnRleft.Size = new System.Drawing.Size(33, 22);
            this.btnRleft.TabIndex = 20;
            this.btnRleft.Text = "L";
            this.btnRleft.UseVisualStyleBackColor = true;
            this.btnRleft.Click += new System.EventHandler(this.btnRleft_Click);
            // 
            // fxindex
            // 
            this.fxindex.Location = new System.Drawing.Point(279, 532);
            this.fxindex.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.fxindex.Name = "fxindex";
            this.fxindex.Size = new System.Drawing.Size(35, 20);
            this.fxindex.TabIndex = 21;
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
            this.PSOpara.Location = new System.Drawing.Point(22, 501);
            this.PSOpara.Name = "PSOpara";
            this.PSOpara.Size = new System.Drawing.Size(237, 164);
            this.PSOpara.TabIndex = 22;
            this.PSOpara.TabStop = false;
            this.PSOpara.Text = "PSO parameters";
            // 
            // PSOcn
            // 
            this.PSOcn.Location = new System.Drawing.Point(173, 103);
            this.PSOcn.Name = "PSOcn";
            this.PSOcn.Size = new System.Drawing.Size(49, 20);
            this.PSOcn.TabIndex = 44;
            // 
            // PSOcl
            // 
            this.PSOcl.Location = new System.Drawing.Point(173, 78);
            this.PSOcl.Name = "PSOcl";
            this.PSOcl.Size = new System.Drawing.Size(49, 20);
            this.PSOcl.TabIndex = 43;
            // 
            // PSOcg
            // 
            this.PSOcg.Location = new System.Drawing.Point(173, 49);
            this.PSOcg.Name = "PSOcg";
            this.PSOcg.Size = new System.Drawing.Size(49, 20);
            this.PSOcg.TabIndex = 42;
            // 
            // PSOcp
            // 
            this.PSOcp.Location = new System.Drawing.Point(173, 23);
            this.PSOcp.Name = "PSOcp";
            this.PSOcp.Size = new System.Drawing.Size(49, 20);
            this.PSOcp.TabIndex = 41;
            // 
            // PSOwmax
            // 
            this.PSOwmax.Location = new System.Drawing.Point(73, 103);
            this.PSOwmax.Name = "PSOwmax";
            this.PSOwmax.Size = new System.Drawing.Size(50, 20);
            this.PSOwmax.TabIndex = 40;
            // 
            // PSOwmin
            // 
            this.PSOwmin.Location = new System.Drawing.Point(73, 78);
            this.PSOwmin.Name = "PSOwmin";
            this.PSOwmin.Size = new System.Drawing.Size(50, 20);
            this.PSOwmin.TabIndex = 24;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 132);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 13);
            this.label15.TabIndex = 39;
            this.label15.Text = "# local";
            // 
            // PSOnb
            // 
            this.PSOnb.Location = new System.Drawing.Point(73, 130);
            this.PSOnb.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.PSOnb.Name = "PSOnb";
            this.PSOnb.Size = new System.Drawing.Size(50, 20);
            this.PSOnb.TabIndex = 38;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 106);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 37;
            this.label13.Text = "wmax";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 79);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 34;
            this.label14.Text = "wmin";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(148, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "cn";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(148, 79);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "cl";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(148, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(19, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "cg";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(148, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "cp";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "# particles";
            // 
            // PSOnumParticles
            // 
            this.PSOnumParticles.Location = new System.Drawing.Point(73, 50);
            this.PSOnumParticles.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PSOnumParticles.Name = "PSOnumParticles";
            this.PSOnumParticles.Size = new System.Drawing.Size(50, 20);
            this.PSOnumParticles.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "# iteration";
            // 
            // PSOiter
            // 
            this.PSOiter.Location = new System.Drawing.Point(73, 23);
            this.PSOiter.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PSOiter.Name = "PSOiter";
            this.PSOiter.Size = new System.Drawing.Size(50, 20);
            this.PSOiter.TabIndex = 23;
            // 
            // txtFunction
            // 
            this.txtFunction.Location = new System.Drawing.Point(279, 558);
            this.txtFunction.Name = "txtFunction";
            this.txtFunction.ReadOnly = true;
            this.txtFunction.Size = new System.Drawing.Size(100, 20);
            this.txtFunction.TabIndex = 23;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(276, 513);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 13);
            this.label16.TabIndex = 24;
            this.label16.Text = "Function";
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
            this.groupBox1.Location = new System.Drawing.Point(414, 524);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 141);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Animation";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(306, 196);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(22, 13);
            this.label18.TabIndex = 29;
            this.label18.Text = "Ele";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(514, 508);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 13);
            this.label17.TabIndex = 28;
            this.label17.Text = "Rotate";
            // 
            // btnRright
            // 
            this.btnRright.Enabled = false;
            this.btnRright.Location = new System.Drawing.Point(596, 503);
            this.btnRright.Name = "btnRright";
            this.btnRright.Size = new System.Drawing.Size(33, 22);
            this.btnRright.TabIndex = 23;
            this.btnRright.Text = "R";
            this.btnRright.UseVisualStyleBackColor = true;
            this.btnRright.Click += new System.EventHandler(this.btnRright_Click);
            // 
            // btnEUp
            // 
            this.btnEUp.Enabled = false;
            this.btnEUp.Location = new System.Drawing.Point(309, 212);
            this.btnEUp.Name = "btnEUp";
            this.btnEUp.Size = new System.Drawing.Size(24, 22);
            this.btnEUp.TabIndex = 22;
            this.btnEUp.Text = "U";
            this.btnEUp.UseVisualStyleBackColor = true;
            this.btnEUp.Click += new System.EventHandler(this.btnEUp_Click);
            // 
            // btnEDown
            // 
            this.btnEDown.Enabled = false;
            this.btnEDown.Location = new System.Drawing.Point(309, 240);
            this.btnEDown.Name = "btnEDown";
            this.btnEDown.Size = new System.Drawing.Size(24, 22);
            this.btnEDown.TabIndex = 21;
            this.btnEDown.Text = "D";
            this.btnEDown.UseVisualStyleBackColor = true;
            this.btnEDown.Click += new System.EventHandler(this.btnEDown_Click);
            // 
            // lAniStep
            // 
            this.lAniStep.AutoSize = true;
            this.lAniStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lAniStep.Location = new System.Drawing.Point(555, 24);
            this.lAniStep.Name = "lAniStep";
            this.lAniStep.Size = new System.Drawing.Size(92, 13);
            this.lAniStep.TabIndex = 28;
            this.lAniStep.Text = "Animation Step";
            // 
            // chart3D2
            // 
            this.chart3D2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chart3D2.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.chart3D2.BackColor = System.Drawing.Color.White;
            this.chart3D2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lineStyle1.IsVisible = true;
            lineStyle1.LineColor = System.Drawing.Color.Black;
            lineStyle1.Pattern = System.Drawing.Drawing2D.DashStyle.Solid;
            lineStyle1.PlotMethod = Chart3DLib.LineStyle.PlotLinesMethodEnum.Lines;
            lineStyle1.Thickness = 1F;
            this.chart3D2.C3Axes.AxisStyle = lineStyle1;
            this.chart3D2.C3Axes.XMax = 5F;
            this.chart3D2.C3Axes.XMin = -5F;
            this.chart3D2.C3Axes.XTick = 1F;
            this.chart3D2.C3Axes.YMax = 3F;
            this.chart3D2.C3Axes.YMin = -3F;
            this.chart3D2.C3Axes.YTick = 1F;
            this.chart3D2.C3Axes.ZMax = 6F;
            this.chart3D2.C3Axes.ZMin = -6F;
            this.chart3D2.C3Axes.ZTick = 3F;
            barStyle1.IsBarSingleColor = false;
            barStyle1.XLength = 0.5F;
            barStyle1.YLength = 0.5F;
            barStyle1.ZOrigin = 0F;
            dataSeries1.BarStyle = barStyle1;
            lineStyle2.IsVisible = true;
            lineStyle2.LineColor = System.Drawing.Color.Black;
            lineStyle2.Pattern = System.Drawing.Drawing2D.DashStyle.Solid;
            lineStyle2.PlotMethod = Chart3DLib.LineStyle.PlotLinesMethodEnum.Lines;
            lineStyle2.Thickness = 1F;
            dataSeries1.LineStyle = lineStyle2;
            dataSeries1.Point4Array = null;
            dataSeries1.PointArray = null;
            dataSeries1.PointList = ((System.Collections.ArrayList)(resources.GetObject("dataSeries1.PointList")));
            dataSeries1.XDataMin = -5F;
            dataSeries1.XNumber = 10;
            dataSeries1.XSpacing = 1F;
            dataSeries1.YDataMin = -5F;
            dataSeries1.YNumber = 10;
            dataSeries1.YSpacing = 1F;
            dataSeries1.ZNumber = 10;
            dataSeries1.ZSpacing = 1F;
            dataSeries1.ZZDataMin = -5F;
            this.chart3D2.C3DataSeries = dataSeries1;
            barStyle2.IsBarSingleColor = false;
            barStyle2.XLength = 0.5F;
            barStyle2.YLength = 0.5F;
            barStyle2.ZOrigin = 0F;
            dataSeries2.BarStyle = barStyle2;
            lineStyle3.IsVisible = true;
            lineStyle3.LineColor = System.Drawing.Color.Black;
            lineStyle3.Pattern = System.Drawing.Drawing2D.DashStyle.Solid;
            lineStyle3.PlotMethod = Chart3DLib.LineStyle.PlotLinesMethodEnum.Lines;
            lineStyle3.Thickness = 1F;
            dataSeries2.LineStyle = lineStyle3;
            dataSeries2.Point4Array = null;
            dataSeries2.PointArray = null;
            dataSeries2.PointList = ((System.Collections.ArrayList)(resources.GetObject("dataSeries2.PointList")));
            dataSeries2.XDataMin = -5F;
            dataSeries2.XNumber = 10;
            dataSeries2.XSpacing = 1F;
            dataSeries2.YDataMin = -5F;
            dataSeries2.YNumber = 10;
            dataSeries2.YSpacing = 1F;
            dataSeries2.ZNumber = 10;
            dataSeries2.ZSpacing = 1F;
            dataSeries2.ZZDataMin = -5F;
            this.chart3D2.C3DataSeriesSupport = dataSeries2;
            lineStyle4.IsVisible = true;
            lineStyle4.LineColor = System.Drawing.Color.LightGray;
            lineStyle4.Pattern = System.Drawing.Drawing2D.DashStyle.Solid;
            lineStyle4.PlotMethod = Chart3DLib.LineStyle.PlotLinesMethodEnum.Lines;
            lineStyle4.Thickness = 1F;
            this.chart3D2.C3Grid.GridStyle = lineStyle4;
            this.chart3D2.C3Grid.IsXGrid = true;
            this.chart3D2.C3Grid.IsYGrid = true;
            this.chart3D2.C3Grid.IsZGrid = true;
            this.chart3D2.C3Labels.LabelFont = new System.Drawing.Font("Arial", 10F);
            this.chart3D2.C3Labels.LabelFontColor = System.Drawing.Color.Black;
            this.chart3D2.C3Labels.TickFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart3D2.C3Labels.TickFontColor = System.Drawing.Color.Black;
            this.chart3D2.C3Labels.Title = "My 3D Chart";
            this.chart3D2.C3Labels.TitleColor = System.Drawing.Color.Black;
            this.chart3D2.C3Labels.TitleFont = new System.Drawing.Font("Arial Narrow", 14F);
            this.chart3D2.C3Labels.XLabel = "X Axis";
            this.chart3D2.C3Labels.YLabel = "Y Axis";
            this.chart3D2.C3Labels.ZLabel = "Z Axis";
            this.chart3D2.C3SetMode = 326;
            this.chart3D2.C3ViewAngle.Azimuth = -37.5F;
            this.chart3D2.C3ViewAngle.Elevation = 70F;
            this.chart3D2.Location = new System.Drawing.Point(339, 44);
            this.chart3D2.Name = "chart3D2";
            this.chart3D2.Size = new System.Drawing.Size(496, 453);
            this.chart3D2.TabIndex = 27;
            // 
            // chart3D1
            // 
            this.chart3D1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chart3D1.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.chart3D1.BackColor = System.Drawing.Color.White;
            this.chart3D1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lineStyle5.IsVisible = true;
            lineStyle5.LineColor = System.Drawing.Color.Black;
            lineStyle5.Pattern = System.Drawing.Drawing2D.DashStyle.Solid;
            lineStyle5.PlotMethod = Chart3DLib.LineStyle.PlotLinesMethodEnum.Lines;
            lineStyle5.Thickness = 1F;
            this.chart3D1.C3Axes.AxisStyle = lineStyle5;
            this.chart3D1.C3Axes.XMax = 5F;
            this.chart3D1.C3Axes.XMin = -5F;
            this.chart3D1.C3Axes.XTick = 1F;
            this.chart3D1.C3Axes.YMax = 3F;
            this.chart3D1.C3Axes.YMin = -3F;
            this.chart3D1.C3Axes.YTick = 1F;
            this.chart3D1.C3Axes.ZMax = 6F;
            this.chart3D1.C3Axes.ZMin = -6F;
            this.chart3D1.C3Axes.ZTick = 3F;
            barStyle3.IsBarSingleColor = false;
            barStyle3.XLength = 0.5F;
            barStyle3.YLength = 0.5F;
            barStyle3.ZOrigin = 0F;
            dataSeries3.BarStyle = barStyle3;
            lineStyle6.IsVisible = true;
            lineStyle6.LineColor = System.Drawing.Color.Black;
            lineStyle6.Pattern = System.Drawing.Drawing2D.DashStyle.Solid;
            lineStyle6.PlotMethod = Chart3DLib.LineStyle.PlotLinesMethodEnum.Lines;
            lineStyle6.Thickness = 1F;
            dataSeries3.LineStyle = lineStyle6;
            dataSeries3.Point4Array = null;
            dataSeries3.PointArray = null;
            dataSeries3.PointList = ((System.Collections.ArrayList)(resources.GetObject("dataSeries3.PointList")));
            dataSeries3.XDataMin = -5F;
            dataSeries3.XNumber = 10;
            dataSeries3.XSpacing = 1F;
            dataSeries3.YDataMin = -5F;
            dataSeries3.YNumber = 10;
            dataSeries3.YSpacing = 1F;
            dataSeries3.ZNumber = 10;
            dataSeries3.ZSpacing = 1F;
            dataSeries3.ZZDataMin = -5F;
            this.chart3D1.C3DataSeries = dataSeries3;
            barStyle4.IsBarSingleColor = false;
            barStyle4.XLength = 0.5F;
            barStyle4.YLength = 0.5F;
            barStyle4.ZOrigin = 0F;
            dataSeries4.BarStyle = barStyle4;
            lineStyle7.IsVisible = true;
            lineStyle7.LineColor = System.Drawing.Color.Black;
            lineStyle7.Pattern = System.Drawing.Drawing2D.DashStyle.Solid;
            lineStyle7.PlotMethod = Chart3DLib.LineStyle.PlotLinesMethodEnum.Lines;
            lineStyle7.Thickness = 1F;
            dataSeries4.LineStyle = lineStyle7;
            dataSeries4.Point4Array = null;
            dataSeries4.PointArray = null;
            dataSeries4.PointList = ((System.Collections.ArrayList)(resources.GetObject("dataSeries4.PointList")));
            dataSeries4.XDataMin = -5F;
            dataSeries4.XNumber = 10;
            dataSeries4.XSpacing = 1F;
            dataSeries4.YDataMin = -5F;
            dataSeries4.YNumber = 10;
            dataSeries4.YSpacing = 1F;
            dataSeries4.ZNumber = 10;
            dataSeries4.ZSpacing = 1F;
            dataSeries4.ZZDataMin = -5F;
            this.chart3D1.C3DataSeriesSupport = dataSeries4;
            lineStyle8.IsVisible = true;
            lineStyle8.LineColor = System.Drawing.Color.LightGray;
            lineStyle8.Pattern = System.Drawing.Drawing2D.DashStyle.Solid;
            lineStyle8.PlotMethod = Chart3DLib.LineStyle.PlotLinesMethodEnum.Lines;
            lineStyle8.Thickness = 1F;
            this.chart3D1.C3Grid.GridStyle = lineStyle8;
            this.chart3D1.C3Grid.IsXGrid = true;
            this.chart3D1.C3Grid.IsYGrid = true;
            this.chart3D1.C3Grid.IsZGrid = true;
            this.chart3D1.C3Labels.LabelFont = new System.Drawing.Font("Arial", 10F);
            this.chart3D1.C3Labels.LabelFontColor = System.Drawing.Color.Black;
            this.chart3D1.C3Labels.TickFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart3D1.C3Labels.TickFontColor = System.Drawing.Color.Black;
            this.chart3D1.C3Labels.Title = "My 3D Chart";
            this.chart3D1.C3Labels.TitleColor = System.Drawing.Color.Black;
            this.chart3D1.C3Labels.TitleFont = new System.Drawing.Font("Arial Narrow", 14F);
            this.chart3D1.C3Labels.XLabel = "X Axis";
            this.chart3D1.C3Labels.YLabel = "Y Axis";
            this.chart3D1.C3Labels.ZLabel = "Z Axis";
            this.chart3D1.C3SetMode = 148;
            this.chart3D1.C3ViewAngle.Azimuth = -37.5F;
            this.chart3D1.C3ViewAngle.Elevation = 30F;
            this.chart3D1.Location = new System.Drawing.Point(22, 44);
            this.chart3D1.Name = "chart3D1";
            this.chart3D1.Size = new System.Drawing.Size(278, 242);
            this.chart3D1.TabIndex = 26;
            // 
            // PSO3D
            // 
            this.AcceptButton = this.RunPSO;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 680);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lAniStep);
            this.Controls.Add(this.btnEUp);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.btnEDown);
            this.Controls.Add(this.chart3D2);
            this.Controls.Add(this.btnRright);
            this.Controls.Add(this.chart3D1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtFunction);
            this.Controls.Add(this.PSOpara);
            this.Controls.Add(this.fxindex);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRleft);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RunPSO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComTime);
            this.Controls.Add(this.PSOGraph);
            this.Name = "PSO3D";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PSO 3D visual";
            this.Load += new System.EventHandler(this.PSO3D_Load);
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
        private System.Windows.Forms.Button btnExit;
        private ZedGraph.ZedGraphControl PSOGraph;
        private System.Windows.Forms.TextBox ComTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PSO_dynamic;
        private System.Windows.Forms.Button RunPSO;
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
        private System.Windows.Forms.Button btnRleft;
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
        private Chart3DLib.Chart3D chart3D1;
        private Chart3DLib.Chart3D chart3D2;
        private System.Windows.Forms.Label lAniStep;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnRright;
        private System.Windows.Forms.Button btnEUp;
        private System.Windows.Forms.Button btnEDown;
    }
}

