namespace OriginalIQTestFormApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton_classic = new System.Windows.Forms.RadioButton();
            this.radioButton_advanced = new System.Windows.Forms.RadioButton();
            this.progressBar_solve = new System.Windows.Forms.ProgressBar();
            this.btn_solve = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(322, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Initial board";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(567, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Final board";
            // 
            // radioButton_classic
            // 
            this.radioButton_classic.AutoSize = true;
            this.radioButton_classic.Font = new System.Drawing.Font("Century", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_classic.Location = new System.Drawing.Point(39, 496);
            this.radioButton_classic.Name = "radioButton_classic";
            this.radioButton_classic.Size = new System.Drawing.Size(91, 27);
            this.radioButton_classic.TabIndex = 3;
            this.radioButton_classic.Text = "Classic";
            this.radioButton_classic.UseVisualStyleBackColor = true;
            this.radioButton_classic.CheckedChanged += new System.EventHandler(this.radioButton_classic_CheckedChanged);
            // 
            // radioButton_advanced
            // 
            this.radioButton_advanced.AutoSize = true;
            this.radioButton_advanced.Checked = true;
            this.radioButton_advanced.Font = new System.Drawing.Font("Century", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_advanced.Location = new System.Drawing.Point(39, 531);
            this.radioButton_advanced.Name = "radioButton_advanced";
            this.radioButton_advanced.Size = new System.Drawing.Size(115, 27);
            this.radioButton_advanced.TabIndex = 3;
            this.radioButton_advanced.TabStop = true;
            this.radioButton_advanced.Text = "Advanced";
            this.radioButton_advanced.UseVisualStyleBackColor = true;
            this.radioButton_advanced.CheckedChanged += new System.EventHandler(this.radioButton_advanced_CheckedChanged);
            // 
            // progressBar_solve
            // 
            this.progressBar_solve.Location = new System.Drawing.Point(416, 572);
            this.progressBar_solve.Name = "progressBar_solve";
            this.progressBar_solve.Size = new System.Drawing.Size(281, 23);
            this.progressBar_solve.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar_solve.TabIndex = 4;
            // 
            // btn_solve
            // 
            this.btn_solve.Font = new System.Drawing.Font("Century", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_solve.Location = new System.Drawing.Point(480, 496);
            this.btn_solve.Name = "btn_solve";
            this.btn_solve.Size = new System.Drawing.Size(135, 48);
            this.btn_solve.TabIndex = 5;
            this.btn_solve.Text = "Solve";
            this.btn_solve.UseVisualStyleBackColor = true;
            this.btn_solve.Click += new System.EventHandler(this.btn_solve_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 619);
            this.Controls.Add(this.btn_solve);
            this.Controls.Add(this.progressBar_solve);
            this.Controls.Add(this.radioButton_advanced);
            this.Controls.Add(this.radioButton_classic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainForm";
            this.Text = "Original IQ Tester";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton_classic;
        private System.Windows.Forms.RadioButton radioButton_advanced;
        private System.Windows.Forms.ProgressBar progressBar_solve;
        private System.Windows.Forms.Button btn_solve;
    }
}

