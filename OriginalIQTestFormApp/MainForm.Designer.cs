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
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton_classic = new System.Windows.Forms.RadioButton();
            this.radioButton_advanced = new System.Windows.Forms.RadioButton();
            this.btn_solve = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.radioButton_4 = new System.Windows.Forms.RadioButton();
            this.radioButton_5 = new System.Windows.Forms.RadioButton();
            this.groupBox_mode = new System.Windows.Forms.GroupBox();
            this.groupBox_boardLines = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel_Screen = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel_screen = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar_solve = new System.Windows.Forms.ProgressBar();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton_6 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox_mode.SuspendLayout();
            this.groupBox_boardLines.SuspendLayout();
            this.tableLayoutPanel_screen.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(233, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(435, 72);
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
            // btn_solve
            // 
            this.btn_solve.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_solve.Font = new System.Drawing.Font("Century", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_solve.Location = new System.Drawing.Point(3, 3);
            this.btn_solve.Name = "btn_solve";
            this.btn_solve.Size = new System.Drawing.Size(123, 35);
            this.btn_solve.TabIndex = 5;
            this.btn_solve.Text = "Solve";
            this.btn_solve.UseVisualStyleBackColor = false;
            this.btn_solve.Click += new System.EventHandler(this.btn_solve_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_cancel.Enabled = false;
            this.btn_cancel.Font = new System.Drawing.Font("Century", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(181, 3);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(123, 35);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // txt_log
            // 
            this.txt_log.BackColor = System.Drawing.Color.Black;
            this.txt_log.ForeColor = System.Drawing.SystemColors.Window;
            this.txt_log.Location = new System.Drawing.Point(839, 121);
            this.txt_log.MaximumSize = new System.Drawing.Size(300, 100);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.ReadOnly = true;
            this.txt_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_log.Size = new System.Drawing.Size(240, 100);
            this.txt_log.TabIndex = 6;
            // 
            // radioButton_4
            // 
            this.radioButton_4.AutoSize = true;
            this.radioButton_4.Font = new System.Drawing.Font("Century", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
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
            this.groupBox_mode.Location = new System.Drawing.Point(3, 3);
            this.groupBox_mode.Name = "groupBox_mode";
            this.groupBox_mode.Size = new System.Drawing.Size(172, 133);
            this.groupBox_mode.TabIndex = 7;
            this.groupBox_mode.TabStop = false;
            this.groupBox_mode.Text = "Mode";
            // 
            // groupBox_boardLines
            // 
            this.groupBox_boardLines.Controls.Add(this.radioButton_4);
            this.groupBox_boardLines.Controls.Add(this.radioButton_6);
            this.groupBox_boardLines.Controls.Add(this.radioButton_5);
            this.groupBox_boardLines.Location = new System.Drawing.Point(216, 3);
            this.groupBox_boardLines.Name = "groupBox_boardLines";
            this.groupBox_boardLines.Size = new System.Drawing.Size(175, 133);
            this.groupBox_boardLines.TabIndex = 8;
            this.groupBox_boardLines.TabStop = false;
            this.groupBox_boardLines.Text = "Board lines";
            // 
            // flowLayoutPanel_Screen
            // 
            this.flowLayoutPanel_Screen.AutoSize = true;
            this.flowLayoutPanel_Screen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel_Screen.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel_Screen.Name = "flowLayoutPanel_Screen";
            this.flowLayoutPanel_Screen.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel_Screen.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Initial board";
            // 
            // tableLayoutPanel_screen
            // 
            this.tableLayoutPanel_screen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel_screen.ColumnCount = 3;
            this.tableLayoutPanel_screen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.65877F));
            this.tableLayoutPanel_screen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.34123F));
            this.tableLayoutPanel_screen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 247F));
            this.tableLayoutPanel_screen.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel_screen.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel_screen.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel_screen.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel_screen.Controls.Add(this.tableLayoutPanel1, 1, 3);
            this.tableLayoutPanel_screen.Controls.Add(this.progressBar_solve, 1, 4);
            this.tableLayoutPanel_screen.Controls.Add(this.flowLayoutPanel2, 1, 2);
            this.tableLayoutPanel_screen.Controls.Add(this.txt_log, 2, 2);
            this.tableLayoutPanel_screen.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel_screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_screen.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_screen.Name = "tableLayoutPanel_screen";
            this.tableLayoutPanel_screen.RowCount = 5;
            this.tableLayoutPanel_screen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.13592F));
            this.tableLayoutPanel_screen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.76699F));
            this.tableLayoutPanel_screen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.68932F));
            this.tableLayoutPanel_screen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.27184F));
            this.tableLayoutPanel_screen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.13592F));
            this.tableLayoutPanel_screen.Size = new System.Drawing.Size(1084, 601);
            this.tableLayoutPanel_screen.TabIndex = 13;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 121);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox_mode, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox_boardLines, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 383);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(426, 139);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.10811F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.89189F));
            this.tableLayoutPanel1.Controls.Add(this.btn_solve, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_cancel, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(435, 383);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(370, 49);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // progressBar_solve
            // 
            this.progressBar_solve.Location = new System.Drawing.Point(435, 528);
            this.progressBar_solve.Name = "progressBar_solve";
            this.progressBar_solve.Size = new System.Drawing.Size(304, 23);
            this.progressBar_solve.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar_solve.TabIndex = 4;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(435, 121);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // radioButton_6
            // 
            this.radioButton_6.AutoSize = true;
            this.radioButton_6.Font = new System.Drawing.Font("Century", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_6.Location = new System.Drawing.Point(13, 87);
            this.radioButton_6.Name = "radioButton_6";
            this.radioButton_6.Size = new System.Drawing.Size(39, 27);
            this.radioButton_6.TabIndex = 3;
            this.radioButton_6.Text = "6";
            this.radioButton_6.UseVisualStyleBackColor = true;
            this.radioButton_6.CheckedChanged += new System.EventHandler(this.radioButton_6_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1084, 601);
            this.Controls.Add(this.flowLayoutPanel_Screen);
            this.Controls.Add(this.tableLayoutPanel_screen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Original IQ Tester";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox_mode.ResumeLayout(false);
            this.groupBox_mode.PerformLayout();
            this.groupBox_boardLines.ResumeLayout(false);
            this.groupBox_boardLines.PerformLayout();
            this.tableLayoutPanel_screen.ResumeLayout(false);
            this.tableLayoutPanel_screen.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton_classic;
        private System.Windows.Forms.RadioButton radioButton_advanced;
        private System.Windows.Forms.Button btn_solve;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.RadioButton radioButton_4;
        private System.Windows.Forms.RadioButton radioButton_5;
        private System.Windows.Forms.GroupBox groupBox_mode;
        private System.Windows.Forms.GroupBox groupBox_boardLines;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_Screen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_screen;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ProgressBar progressBar_solve;
        private System.Windows.Forms.RadioButton radioButton_6;
    }
}

