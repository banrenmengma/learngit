namespace PSO_MutiObjective
{
    partial class SelectProblem
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
            this.cbProblem = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.problem = new System.Windows.Forms.PictureBox();
            this.selectP = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.problem)).BeginInit();
            this.SuspendLayout();
            // 
            // cbProblem
            // 
            this.cbProblem.FormattingEnabled = true;
            this.cbProblem.Location = new System.Drawing.Point(23, 37);
            this.cbProblem.Name = "cbProblem";
            this.cbProblem.Size = new System.Drawing.Size(151, 21);
            this.cbProblem.TabIndex = 0;
            this.cbProblem.SelectedIndexChanged += new System.EventHandler(this.cbProblem_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(23, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Problem";
            // 
            // problem
            // 
            this.problem.Location = new System.Drawing.Point(23, 77);
            this.problem.Name = "problem";
            this.problem.Size = new System.Drawing.Size(496, 289);
            this.problem.TabIndex = 2;
            this.problem.TabStop = false;
            // 
            // selectP
            // 
            this.selectP.Location = new System.Drawing.Point(220, 37);
            this.selectP.Name = "selectP";
            this.selectP.Size = new System.Drawing.Size(138, 21);
            this.selectP.TabIndex = 3;
            this.selectP.Text = "Confirm Problem";
            this.selectP.UseVisualStyleBackColor = true;
            this.selectP.Click += new System.EventHandler(this.selectP_Click);
            // 
            // SelectProblem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 378);
            this.Controls.Add(this.selectP);
            this.Controls.Add(this.problem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbProblem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectProblem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectProblem";
            this.Load += new System.EventHandler(this.SelectProblem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.problem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbProblem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox problem;
        private System.Windows.Forms.Button selectP;
    }
}