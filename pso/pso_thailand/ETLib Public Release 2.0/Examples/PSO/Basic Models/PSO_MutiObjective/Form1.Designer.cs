namespace PSO_MutiObjective
{
    partial class MultiObjPSO
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
            this.button1 = new System.Windows.Forms.Button();
            this.PSOGraph = new ZedGraph.ZedGraphControl();
            this.ObjVal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PSO_Pareto = new ZedGraph.ZedGraphControl();
            this.label2 = new System.Windows.Forms.Label();
            this.NumberPareto = new System.Windows.Forms.TextBox();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ptype4 = new System.Windows.Forms.TextBox();
            this.ptype3 = new System.Windows.Forms.TextBox();
            this.ptype2 = new System.Windows.Forms.TextBox();
            this.ptype1 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.percGapU = new System.Windows.Forms.TextBox();
            this.percBotE = new System.Windows.Forms.TextBox();
            this.percTopE = new System.Windows.Forms.TextBox();
            this.nElite = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.PSOcn = new System.Windows.Forms.TextBox();
            this.PSOcl = new System.Windows.Forms.TextBox();
            this.PSOcg = new System.Windows.Forms.TextBox();
            this.PSOcp = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.PSOwmax = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.PSOnb = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.PSOwmin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.moveS = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.PSOiter = new System.Windows.Forms.NumericUpDown();
            this.PSOnumParticles = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cAnimation = new System.Windows.Forms.CheckBox();
            this.cRandomExp = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.randomS = new System.Windows.Forms.TextBox();
            this.nRep = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.lproblem = new System.Windows.Forms.Label();
            this.selectPr = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PSOnb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSOiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSOnumParticles)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1114, 710);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Exit_Click);
            // 
            // PSOGraph
            // 
            this.PSOGraph.Location = new System.Drawing.Point(22, 463);
            this.PSOGraph.Name = "PSOGraph";
            this.PSOGraph.ScrollGrace = 0;
            this.PSOGraph.ScrollMaxX = 0;
            this.PSOGraph.ScrollMaxY = 0;
            this.PSOGraph.ScrollMaxY2 = 0;
            this.PSOGraph.ScrollMinX = 0;
            this.PSOGraph.ScrollMinY = 0;
            this.PSOGraph.ScrollMinY2 = 0;
            this.PSOGraph.Size = new System.Drawing.Size(440, 280);
            this.PSOGraph.TabIndex = 1;
            // 
            // ObjVal
            // 
            this.ObjVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ObjVal.Location = new System.Drawing.Point(37, 46);
            this.ObjVal.Name = "ObjVal";
            this.ObjVal.ReadOnly = true;
            this.ObjVal.Size = new System.Drawing.Size(100, 20);
            this.ObjVal.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(34, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Computational Time";
            // 
            // PSO_Pareto
            // 
            this.PSO_Pareto.Location = new System.Drawing.Point(22, 33);
            this.PSO_Pareto.Name = "PSO_Pareto";
            this.PSO_Pareto.ScrollGrace = 0;
            this.PSO_Pareto.ScrollMaxX = 0;
            this.PSO_Pareto.ScrollMaxY = 0;
            this.PSO_Pareto.ScrollMaxY2 = 0;
            this.PSO_Pareto.ScrollMinX = 0;
            this.PSO_Pareto.ScrollMinY = 0;
            this.PSO_Pareto.ScrollMinY2 = 0;
            this.PSO_Pareto.Size = new System.Drawing.Size(440, 402);
            this.PSO_Pareto.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(193, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "# of Pareto Solutions";
            // 
            // NumberPareto
            // 
            this.NumberPareto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.NumberPareto.Location = new System.Drawing.Point(196, 46);
            this.NumberPareto.Name = "NumberPareto";
            this.NumberPareto.ReadOnly = true;
            this.NumberPareto.Size = new System.Drawing.Size(100, 20);
            this.NumberPareto.TabIndex = 5;
            // 
            // PSO_dynamic
            // 
            this.PSO_dynamic.Enabled = false;
            this.PSO_dynamic.Location = new System.Drawing.Point(484, 679);
            this.PSO_dynamic.Name = "PSO_dynamic";
            this.PSO_dynamic.Size = new System.Drawing.Size(100, 26);
            this.PSO_dynamic.TabIndex = 7;
            this.PSO_dynamic.Text = "Animate";
            this.PSO_dynamic.UseVisualStyleBackColor = true;
            this.PSO_dynamic.Click += new System.EventHandler(this.PSO_dynamic_Click);
            // 
            // RunPSO
            // 
            this.RunPSO.Location = new System.Drawing.Point(1114, 672);
            this.RunPSO.Name = "RunPSO";
            this.RunPSO.Size = new System.Drawing.Size(105, 26);
            this.RunPSO.TabIndex = 8;
            this.RunPSO.Text = "RunPSO";
            this.RunPSO.UseVisualStyleBackColor = true;
            this.RunPSO.Click += new System.EventHandler(this.MOPSOrun_Click);
            // 
            // Animation
            // 
            this.Animation.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolTip;
            this.Animation.Location = new System.Drawing.Point(484, 33);
            this.Animation.Name = "Animation";
            this.Animation.ScrollGrace = 0;
            this.Animation.ScrollMaxX = 0;
            this.Animation.ScrollMaxY = 0;
            this.Animation.ScrollMaxY2 = 0;
            this.Animation.ScrollMinX = 0;
            this.Animation.ScrollMinY = 0;
            this.Animation.ScrollMinY2 = 0;
            this.Animation.Size = new System.Drawing.Size(596, 601);
            this.Animation.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Pareto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 447);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Average Objective";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(481, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Animation";
            // 
            // AniStepRun
            // 
            this.AniStepRun.Enabled = false;
            this.AniStepRun.Location = new System.Drawing.Point(598, 679);
            this.AniStepRun.Name = "AniStepRun";
            this.AniStepRun.Size = new System.Drawing.Size(100, 26);
            this.AniStepRun.TabIndex = 13;
            this.AniStepRun.Text = "Animate_Step";
            this.AniStepRun.UseVisualStyleBackColor = true;
            this.AniStepRun.Click += new System.EventHandler(this.ActivateStepAni_Click);
            // 
            // AniStep
            // 
            this.AniStep.Enabled = false;
            this.AniStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.AniStep.ForeColor = System.Drawing.Color.Red;
            this.AniStep.Location = new System.Drawing.Point(484, 653);
            this.AniStep.Name = "AniStep";
            this.AniStep.Size = new System.Drawing.Size(100, 20);
            this.AniStep.TabIndex = 14;
            this.AniStep.TextChanged += new System.EventHandler(this.AniStep_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(481, 637);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Step for Animation";
            // 
            // Back
            // 
            this.Back.Enabled = false;
            this.Back.Location = new System.Drawing.Point(598, 711);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(50, 26);
            this.Back.TabIndex = 16;
            this.Back.Text = "<<";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Forward
            // 
            this.Forward.Enabled = false;
            this.Forward.Location = new System.Drawing.Point(649, 711);
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
            this.label7.Location = new System.Drawing.Point(595, 637);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Ani_Speed (ms/step)";
            // 
            // AniSpeed
            // 
            this.AniSpeed.Enabled = false;
            this.AniSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.AniSpeed.ForeColor = System.Drawing.Color.Blue;
            this.AniSpeed.Location = new System.Drawing.Point(598, 653);
            this.AniSpeed.Name = "AniSpeed";
            this.AniSpeed.Size = new System.Drawing.Size(100, 20);
            this.AniSpeed.TabIndex = 18;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(540, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 22);
            this.button2.TabIndex = 20;
            this.button2.Text = "Rescale";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Rescale_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ObjVal);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.NumberPareto);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.Location = new System.Drawing.Point(747, 649);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(333, 87);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result Summary";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(484, 711);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 26);
            this.button3.TabIndex = 25;
            this.button3.Text = "Stop";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ptype4);
            this.groupBox1.Controls.Add(this.ptype3);
            this.groupBox1.Controls.Add(this.ptype2);
            this.groupBox1.Controls.Add(this.ptype1);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.percGapU);
            this.groupBox1.Controls.Add(this.percBotE);
            this.groupBox1.Controls.Add(this.percTopE);
            this.groupBox1.Controls.Add(this.nElite);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.PSOcn);
            this.groupBox1.Controls.Add(this.PSOcl);
            this.groupBox1.Controls.Add(this.PSOcg);
            this.groupBox1.Controls.Add(this.PSOcp);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.PSOwmax);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.PSOnb);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.PSOwmin);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.moveS);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.PSOiter);
            this.groupBox1.Controls.Add(this.PSOnumParticles);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(1097, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 491);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MOPSO parameters";
            // 
            // ptype4
            // 
            this.ptype4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ptype4.Location = new System.Drawing.Point(111, 463);
            this.ptype4.Name = "ptype4";
            this.ptype4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ptype4.Size = new System.Drawing.Size(50, 20);
            this.ptype4.TabIndex = 68;
            // 
            // ptype3
            // 
            this.ptype3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ptype3.Location = new System.Drawing.Point(111, 437);
            this.ptype3.Name = "ptype3";
            this.ptype3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ptype3.Size = new System.Drawing.Size(50, 20);
            this.ptype3.TabIndex = 67;
            // 
            // ptype2
            // 
            this.ptype2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ptype2.Location = new System.Drawing.Point(111, 409);
            this.ptype2.Name = "ptype2";
            this.ptype2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ptype2.Size = new System.Drawing.Size(50, 20);
            this.ptype2.TabIndex = 66;
            // 
            // ptype1
            // 
            this.ptype1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ptype1.Location = new System.Drawing.Point(111, 383);
            this.ptype1.Name = "ptype1";
            this.ptype1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ptype1.Size = new System.Drawing.Size(51, 20);
            this.ptype1.TabIndex = 65;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(13, 468);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(91, 13);
            this.label22.TabIndex = 64;
            this.label22.Text = "% type par. type 4";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(13, 440);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(91, 13);
            this.label23.TabIndex = 63;
            this.label23.Text = "% type par. type 3";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(13, 414);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(91, 13);
            this.label24.TabIndex = 62;
            this.label24.Text = "% type par. type 2";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label25.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label25.Location = new System.Drawing.Point(13, 386);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(91, 13);
            this.label25.TabIndex = 61;
            this.label25.Text = "% type par. type 1";
            // 
            // percGapU
            // 
            this.percGapU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.percGapU.Location = new System.Drawing.Point(111, 359);
            this.percGapU.Name = "percGapU";
            this.percGapU.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.percGapU.Size = new System.Drawing.Size(51, 20);
            this.percGapU.TabIndex = 60;
            // 
            // percBotE
            // 
            this.percBotE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.percBotE.Location = new System.Drawing.Point(111, 331);
            this.percBotE.Name = "percBotE";
            this.percBotE.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.percBotE.Size = new System.Drawing.Size(51, 20);
            this.percBotE.TabIndex = 59;
            // 
            // percTopE
            // 
            this.percTopE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.percTopE.Location = new System.Drawing.Point(111, 303);
            this.percTopE.Name = "percTopE";
            this.percTopE.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.percTopE.Size = new System.Drawing.Size(51, 20);
            this.percTopE.TabIndex = 58;
            // 
            // nElite
            // 
            this.nElite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.nElite.Location = new System.Drawing.Point(111, 277);
            this.nElite.Name = "nElite";
            this.nElite.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nElite.Size = new System.Drawing.Size(51, 20);
            this.nElite.TabIndex = 57;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(13, 362);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(75, 13);
            this.label18.TabIndex = 56;
            this.label18.Text = "% Unexp. Gap";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(13, 334);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 13);
            this.label19.TabIndex = 55;
            this.label19.Text = "% Bottom Elite";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(13, 308);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(60, 13);
            this.label20.TabIndex = 54;
            this.label20.Text = "% Top Elite";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(13, 280);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(34, 13);
            this.label21.TabIndex = 53;
            this.label21.Text = "#Elite";
            // 
            // PSOcn
            // 
            this.PSOcn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.PSOcn.Location = new System.Drawing.Point(111, 251);
            this.PSOcn.Name = "PSOcn";
            this.PSOcn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PSOcn.Size = new System.Drawing.Size(50, 20);
            this.PSOcn.TabIndex = 52;
            // 
            // PSOcl
            // 
            this.PSOcl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.PSOcl.Location = new System.Drawing.Point(111, 226);
            this.PSOcl.Name = "PSOcl";
            this.PSOcl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PSOcl.Size = new System.Drawing.Size(50, 20);
            this.PSOcl.TabIndex = 51;
            // 
            // PSOcg
            // 
            this.PSOcg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.PSOcg.Location = new System.Drawing.Point(111, 198);
            this.PSOcg.Name = "PSOcg";
            this.PSOcg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PSOcg.Size = new System.Drawing.Size(51, 20);
            this.PSOcg.TabIndex = 50;
            // 
            // PSOcp
            // 
            this.PSOcp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.PSOcp.Location = new System.Drawing.Point(111, 172);
            this.PSOcp.Name = "PSOcp";
            this.PSOcp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PSOcp.Size = new System.Drawing.Size(51, 20);
            this.PSOcp.TabIndex = 49;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(13, 257);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 13);
            this.label11.TabIndex = 48;
            this.label11.Text = "cn";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(13, 229);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "cl";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(13, 203);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(19, 13);
            this.label16.TabIndex = 46;
            this.label16.Text = "cg";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(13, 175);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(19, 13);
            this.label17.TabIndex = 45;
            this.label17.Text = "cp";
            // 
            // PSOwmax
            // 
            this.PSOwmax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.PSOwmax.Location = new System.Drawing.Point(114, 122);
            this.PSOwmax.Name = "PSOwmax";
            this.PSOwmax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PSOwmax.Size = new System.Drawing.Size(48, 20);
            this.PSOwmax.TabIndex = 44;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(13, 151);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 13);
            this.label15.TabIndex = 43;
            this.label15.Text = "# local";
            // 
            // PSOnb
            // 
            this.PSOnb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.PSOnb.Location = new System.Drawing.Point(114, 149);
            this.PSOnb.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.PSOnb.Name = "PSOnb";
            this.PSOnb.Size = new System.Drawing.Size(48, 20);
            this.PSOnb.TabIndex = 42;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(13, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 41;
            this.label13.Text = "wmax";
            // 
            // PSOwmin
            // 
            this.PSOwmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.PSOwmin.Location = new System.Drawing.Point(114, 96);
            this.PSOwmin.Name = "PSOwmin";
            this.PSOwmin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PSOwmin.Size = new System.Drawing.Size(48, 20);
            this.PSOwmin.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(10, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Move. Strategy";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(13, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 13);
            this.label14.TabIndex = 40;
            this.label14.Text = "wmin";
            // 
            // moveS
            // 
            this.moveS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.moveS.Location = new System.Drawing.Point(114, 20);
            this.moveS.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.moveS.Name = "moveS";
            this.moveS.Size = new System.Drawing.Size(48, 20);
            this.moveS.TabIndex = 21;
            this.moveS.ValueChanged += new System.EventHandler(this.moveS_ValueChanged_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(13, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "# particles";
            // 
            // PSOiter
            // 
            this.PSOiter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.PSOiter.Location = new System.Drawing.Point(114, 46);
            this.PSOiter.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.PSOiter.Name = "PSOiter";
            this.PSOiter.Size = new System.Drawing.Size(48, 20);
            this.PSOiter.TabIndex = 36;
            // 
            // PSOnumParticles
            // 
            this.PSOnumParticles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.PSOnumParticles.Location = new System.Drawing.Point(114, 72);
            this.PSOnumParticles.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PSOnumParticles.Name = "PSOnumParticles";
            this.PSOnumParticles.Size = new System.Drawing.Size(48, 20);
            this.PSOnumParticles.TabIndex = 37;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(13, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "# iteration";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cAnimation);
            this.groupBox3.Controls.Add(this.cRandomExp);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.randomS);
            this.groupBox3.Controls.Add(this.nRep);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox3.Location = new System.Drawing.Point(1098, 536);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(174, 119);
            this.groupBox3.TabIndex = 76;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Experiment Setting";
            // 
            // cAnimation
            // 
            this.cAnimation.AutoSize = true;
            this.cAnimation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cAnimation.Location = new System.Drawing.Point(11, 93);
            this.cAnimation.Name = "cAnimation";
            this.cAnimation.Size = new System.Drawing.Size(72, 17);
            this.cAnimation.TabIndex = 75;
            this.cAnimation.Text = "Animation";
            this.cAnimation.UseVisualStyleBackColor = true;
            // 
            // cRandomExp
            // 
            this.cRandomExp.AutoSize = true;
            this.cRandomExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cRandomExp.Location = new System.Drawing.Point(11, 19);
            this.cRandomExp.Name = "cRandomExp";
            this.cRandomExp.Size = new System.Drawing.Size(84, 17);
            this.cRandomExp.TabIndex = 74;
            this.cRandomExp.Text = "Radom Exp.";
            this.cRandomExp.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label26.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label26.Location = new System.Drawing.Point(11, 44);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(73, 13);
            this.label26.TabIndex = 69;
            this.label26.Text = "Random seed";
            // 
            // randomS
            // 
            this.randomS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.randomS.Location = new System.Drawing.Point(108, 39);
            this.randomS.Name = "randomS";
            this.randomS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.randomS.Size = new System.Drawing.Size(50, 20);
            this.randomS.TabIndex = 70;
            // 
            // nRep
            // 
            this.nRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.nRep.Location = new System.Drawing.Point(108, 65);
            this.nRep.Name = "nRep";
            this.nRep.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nRep.Size = new System.Drawing.Size(50, 20);
            this.nRep.TabIndex = 72;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label27.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label27.Location = new System.Drawing.Point(11, 70);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(70, 13);
            this.label27.TabIndex = 71;
            this.label27.Text = "# Replication";
            // 
            // lproblem
            // 
            this.lproblem.AutoSize = true;
            this.lproblem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lproblem.ForeColor = System.Drawing.Color.Green;
            this.lproblem.Location = new System.Drawing.Point(759, 9);
            this.lproblem.Name = "lproblem";
            this.lproblem.Size = new System.Drawing.Size(121, 13);
            this.lproblem.TabIndex = 77;
            this.lproblem.Text = "****Test Problem****";
            // 
            // selectPr
            // 
            this.selectPr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.selectPr.ForeColor = System.Drawing.Color.Red;
            this.selectPr.Location = new System.Drawing.Point(889, 5);
            this.selectPr.Name = "selectPr";
            this.selectPr.Size = new System.Drawing.Size(129, 22);
            this.selectPr.TabIndex = 78;
            this.selectPr.Text = "Select problem";
            this.selectPr.UseVisualStyleBackColor = true;
            this.selectPr.Click += new System.EventHandler(this.selectPr_Click);
            // 
            // MultiObjPSO
            // 
            this.AcceptButton = this.RunPSO;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 753);
            this.Controls.Add(this.selectPr);
            this.Controls.Add(this.lproblem);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.AniSpeed);
            this.Controls.Add(this.Forward);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AniStep);
            this.Controls.Add(this.AniStepRun);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Animation);
            this.Controls.Add(this.RunPSO);
            this.Controls.Add(this.PSO_dynamic);
            this.Controls.Add(this.PSO_Pareto);
            this.Controls.Add(this.PSOGraph);
            this.Controls.Add(this.button1);
            this.Name = "MultiObjPSO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MO Evolutionary Strategy";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MOPSOForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PSOnb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSOiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PSOnumParticles)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private ZedGraph.ZedGraphControl PSOGraph;
        private System.Windows.Forms.TextBox ObjVal;
        private System.Windows.Forms.Label label1;
        private ZedGraph.ZedGraphControl PSO_Pareto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NumberPareto;
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ptype4;
        private System.Windows.Forms.TextBox ptype3;
        private System.Windows.Forms.TextBox ptype2;
        private System.Windows.Forms.TextBox ptype1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox percGapU;
        private System.Windows.Forms.TextBox percBotE;
        private System.Windows.Forms.TextBox percTopE;
        private System.Windows.Forms.TextBox nElite;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox PSOcn;
        private System.Windows.Forms.TextBox PSOcl;
        private System.Windows.Forms.TextBox PSOcg;
        private System.Windows.Forms.TextBox PSOcp;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox PSOwmax;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown PSOnb;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox PSOwmin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown moveS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown PSOiter;
        private System.Windows.Forms.NumericUpDown PSOnumParticles;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cAnimation;
        private System.Windows.Forms.CheckBox cRandomExp;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox randomS;
        private System.Windows.Forms.TextBox nRep;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lproblem;
        private System.Windows.Forms.Button selectPr;
    }
}

