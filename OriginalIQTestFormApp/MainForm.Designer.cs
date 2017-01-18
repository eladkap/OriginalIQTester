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
            this.btn_cancel = new System.Windows.Forms.Button();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.radioButton_4 = new System.Windows.Forms.RadioButton();
            this.radioButton_5 = new System.Windows.Forms.RadioButton();
            this.groupBox_mode = new System.Windows.Forms.GroupBox();
            this.groupBox_boardLines = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_mode.SuspendLayout();
            this.groupBox_boardLines.SuspendLayout();
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
            this.radioButton_classic.Location = new System.Drawing.Point(28, 19);
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
            this.radioButton_advanced.Font = new System.Drawing.Font("Century", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_advanced.Location = new System.Drawing.Point(28, 54);
            this.radioButton_advanced.Name = "radioButton_advanced";
            this.radioButton_advanced.Size = new System.Drawing.Size(115, 27);
            this.radioButton_advanced.TabIndex = 3;
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
            this.btn_solve.Location = new System.Drawing.Point(416, 496);
            this.btn_solve.Name = "btn_solve";
            this.btn_solve.Size = new System.Drawing.Size(135, 48);
            this.btn_solve.TabIndex = 5;
            this.btn_solve.Text = "Solve";
            this.btn_solve.UseVisualStyleBackColor = true;
            this.btn_solve.Click += new System.EventHandler(this.btn_solve_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Enabled = false;
            this.btn_cancel.Font = new System.Drawing.Font("Century", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(562, 496);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(135, 48);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // txt_log
            // 
            this.txt_log.BackColor = System.Drawing.Color.Black;
            this.txt_log.ForeColor = System.Drawing.SystemColors.Window;
            this.txt_log.Location = new System.Drawing.Point(12, 598);
            this.txt_log.MaximumSize = new System.Drawing.Size(300, 100);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ReadOnly = true;
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_log.Size = new System.Drawing.Size(278, 100);
            this.txt_log.TabIndex = 6;
            // 
            // radioButton_4
            // 
            this.radioButton_4.AutoSize = true;
            this.radioButton_4.Font = new System.Drawing.Font("Century", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_4.Location = new System.Drawing.Point(13, 19);
            this.radioButton_4.Name = "radioButton_4";
            this.radioButton_4.Size = new System.Drawing.Size(39, 27);
            this.radioButton_4.TabIndex = 3;
            this.radioButton_4.Text = "4";
            this.radioButton_4.UseVisualStyleBackColor = true;
            this.radioButton_4.CheckedChanged += new System.EventHandler(this.radioButton_4_CheckedChanged);
            // 
            // radioButton_5
            // 
            this.radioButton_5.AutoSize = true;
            this.radioButton_5.Checked = true;
            this.radioButton_5.Font = new System.Drawing.Font("Century", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_5.Location = new System.Drawing.Point(13, 54);
            this.radioButton_5.Name = "radioButton_5";
            this.radioButton_5.Size = new System.Drawing.Size(39, 27);
            this.radioButton_5.TabIndex = 3;
            this.radioButton_5.TabStop = true;
            this.radioButton_5.Text = "5";
            this.radioButton_5.UseVisualStyleBackColor = true;
            this.radioButton_5.CheckedChanged += new System.EventHandler(this.radioButton_5_CheckedChanged);
            // 
            // groupBox_mode
            // 
            this.groupBox_mode.Controls.Add(this.radioButton_classic);
            this.groupBox_mode.Controls.Add(this.radioButton_advanced);
            this.groupBox_mode.Location = new System.Drawing.Point(12, 477);
            this.groupBox_mode.Name = "groupBox_mode";
            this.groupBox_mode.Size = new System.Drawing.Size(175, 100);
            this.groupBox_mode.TabIndex = 7;
            this.groupBox_mode.TabStop = false;
            this.groupBox_mode.Text = "Mode";
            // 
            // groupBox_boardLines
            // 
            this.groupBox_boardLines.Controls.Add(this.radioButton_4);
            this.groupBox_boardLines.Controls.Add(this.radioButton_5);
            this.groupBox_boardLines.Location = new System.Drawing.Point(204, 477);
            this.groupBox_boardLines.Name = "groupBox_boardLines";
            this.groupBox_boardLines.Size = new System.Drawing.Size(153, 100);
            this.groupBox_boardLines.TabIndex = 8;
            this.groupBox_boardLines.TabStop = false;
            this.groupBox_boardLines.Text = "Board lines";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 741);
            this.Controls.Add(this.txt_log);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_solve);
            this.Controls.Add(this.progressBar_solve);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox_mode);
            this.Controls.Add(this.groupBox_boardLines);
            this.Name = "MainForm";
            this.Text = "Original IQ Tester";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_mode.ResumeLayout(false);
            this.groupBox_mode.PerformLayout();
            this.groupBox_boardLines.ResumeLayout(false);
            this.groupBox_boardLines.PerformLayout();
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
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.RadioButton radioButton_4;
        private System.Windows.Forms.RadioButton radioButton_5;
        private System.Windows.Forms.GroupBox groupBox_mode;
        private System.Windows.Forms.GroupBox groupBox_boardLines;
    }
}

