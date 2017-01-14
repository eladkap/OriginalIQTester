namespace OriginalIQTestFormApp
{
    partial class SolutionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolutionForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBox_stepsList = new System.Windows.Forms.ListBox();
            this.btn_play = new System.Windows.Forms.Button();
            this.btn_pause = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_previous = new System.Windows.Forms.Button();
            this.btn_last = new System.Windows.Forms.Button();
            this.btn_first = new System.Windows.Forms.Button();
            this.timer_play = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(349, 137);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 300);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(322, 91);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // listBox_stepsList
            // 
            this.listBox_stepsList.FormattingEnabled = true;
            this.listBox_stepsList.Location = new System.Drawing.Point(67, 137);
            this.listBox_stepsList.Name = "listBox_stepsList";
            this.listBox_stepsList.Size = new System.Drawing.Size(120, 303);
            this.listBox_stepsList.TabIndex = 3;
            // 
            // btn_play
            // 
            this.btn_play.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_play.BackgroundImage")));
            this.btn_play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_play.Location = new System.Drawing.Point(538, 464);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(50, 50);
            this.btn_play.TabIndex = 4;
            this.btn_play.UseVisualStyleBackColor = true;
            // 
            // btn_pause
            // 
            this.btn_pause.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_pause.BackgroundImage")));
            this.btn_pause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_pause.Location = new System.Drawing.Point(611, 464);
            this.btn_pause.Name = "btn_pause";
            this.btn_pause.Size = new System.Drawing.Size(50, 50);
            this.btn_pause.TabIndex = 4;
            this.btn_pause.UseVisualStyleBackColor = true;
            this.btn_pause.Click += new System.EventHandler(this.btn_pause_Click);
            // 
            // btn_next
            // 
            this.btn_next.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_next.BackgroundImage")));
            this.btn_next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_next.Location = new System.Drawing.Point(682, 464);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(50, 50);
            this.btn_next.TabIndex = 4;
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_previous
            // 
            this.btn_previous.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_previous.BackgroundImage")));
            this.btn_previous.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_previous.Location = new System.Drawing.Point(762, 464);
            this.btn_previous.Name = "btn_previous";
            this.btn_previous.Size = new System.Drawing.Size(50, 50);
            this.btn_previous.TabIndex = 4;
            this.btn_previous.UseVisualStyleBackColor = true;
            // 
            // btn_last
            // 
            this.btn_last.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_last.BackgroundImage")));
            this.btn_last.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_last.Location = new System.Drawing.Point(454, 464);
            this.btn_last.Name = "btn_last";
            this.btn_last.Size = new System.Drawing.Size(50, 50);
            this.btn_last.TabIndex = 4;
            this.btn_last.UseVisualStyleBackColor = true;
            // 
            // btn_first
            // 
            this.btn_first.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_first.BackgroundImage")));
            this.btn_first.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_first.Location = new System.Drawing.Point(376, 464);
            this.btn_first.Name = "btn_first";
            this.btn_first.Size = new System.Drawing.Size(50, 50);
            this.btn_first.TabIndex = 4;
            this.btn_first.UseVisualStyleBackColor = true;
            // 
            // timer_play
            // 
            this.timer_play.Interval = 1000;
            // 
            // SolutionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 530);
            this.Controls.Add(this.btn_previous);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.btn_pause);
            this.Controls.Add(this.btn_first);
            this.Controls.Add(this.btn_last);
            this.Controls.Add(this.btn_play);
            this.Controls.Add(this.listBox_stepsList);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "SolutionForm";
            this.Text = "Original IQ Tester: Solution";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox_stepsList;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_previous;
        private System.Windows.Forms.Button btn_last;
        private System.Windows.Forms.Button btn_first;
        private System.Windows.Forms.Timer timer_play;
    }
}