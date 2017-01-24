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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBox_stepsList = new System.Windows.Forms.ListBox();
            this.btn_play = new System.Windows.Forms.Button();
            this.btn_pause = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_previous = new System.Windows.Forms.Button();
            this.btn_last = new System.Windows.Forms.Button();
            this.btn_first = new System.Windows.Forms.Button();
            this.timer_play = new System.Windows.Forms.Timer(this.components);
            this.lbl_stateIndex = new System.Windows.Forms.Label();
            this.progressBar_steps = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel_currBoard = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(233, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // listBox_stepsList
            // 
            this.listBox_stepsList.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.listBox_stepsList.FormattingEnabled = true;
            this.listBox_stepsList.ItemHeight = 25;
            this.listBox_stepsList.Location = new System.Drawing.Point(3, 87);
            this.listBox_stepsList.Name = "listBox_stepsList";
            this.listBox_stepsList.Size = new System.Drawing.Size(233, 329);
            this.listBox_stepsList.TabIndex = 3;
            this.listBox_stepsList.SelectedIndexChanged += new System.EventHandler(this.listBox_stepsList_SelectedIndexChanged);
            // 
            // btn_play
            // 
            this.btn_play.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_play.BackgroundImage")));
            this.btn_play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_play.Location = new System.Drawing.Point(115, 3);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(50, 50);
            this.btn_play.TabIndex = 4;
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // btn_pause
            // 
            this.btn_pause.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_pause.BackgroundImage")));
            this.btn_pause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_pause.Location = new System.Drawing.Point(171, 3);
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
            this.btn_next.Location = new System.Drawing.Point(283, 3);
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
            this.btn_previous.Location = new System.Drawing.Point(227, 3);
            this.btn_previous.Name = "btn_previous";
            this.btn_previous.Size = new System.Drawing.Size(50, 50);
            this.btn_previous.TabIndex = 4;
            this.btn_previous.UseVisualStyleBackColor = true;
            this.btn_previous.Click += new System.EventHandler(this.btn_previous_Click);
            // 
            // btn_last
            // 
            this.btn_last.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_last.BackgroundImage")));
            this.btn_last.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_last.Location = new System.Drawing.Point(59, 3);
            this.btn_last.Name = "btn_last";
            this.btn_last.Size = new System.Drawing.Size(50, 50);
            this.btn_last.TabIndex = 4;
            this.btn_last.UseVisualStyleBackColor = true;
            this.btn_last.Click += new System.EventHandler(this.btn_last_Click);
            // 
            // btn_first
            // 
            this.btn_first.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_first.BackgroundImage")));
            this.btn_first.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_first.Location = new System.Drawing.Point(3, 3);
            this.btn_first.Name = "btn_first";
            this.btn_first.Size = new System.Drawing.Size(50, 50);
            this.btn_first.TabIndex = 4;
            this.btn_first.UseVisualStyleBackColor = true;
            this.btn_first.Click += new System.EventHandler(this.btn_first_Click);
            // 
            // timer_play
            // 
            this.timer_play.Interval = 1000;
            this.timer_play.Tick += new System.EventHandler(this.timer_play_Tick);
            // 
            // lbl_stateIndex
            // 
            this.lbl_stateIndex.AutoSize = true;
            this.lbl_stateIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_stateIndex.Location = new System.Drawing.Point(83, 474);
            this.lbl_stateIndex.Name = "lbl_stateIndex";
            this.lbl_stateIndex.Size = new System.Drawing.Size(51, 37);
            this.lbl_stateIndex.TabIndex = 5;
            this.lbl_stateIndex.Text = "#1";
            // 
            // progressBar_steps
            // 
            this.progressBar_steps.Location = new System.Drawing.Point(3, 59);
            this.progressBar_steps.Name = "progressBar_steps";
            this.progressBar_steps.Size = new System.Drawing.Size(330, 23);
            this.progressBar_steps.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.13514F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.86487F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 535F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBox_stepsList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.125F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.875F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1350, 640);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel_currBoard, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(289, 87);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.92982F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.07018F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(517, 550);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_first);
            this.flowLayoutPanel1.Controls.Add(this.btn_last);
            this.flowLayoutPanel1.Controls.Add(this.btn_play);
            this.flowLayoutPanel1.Controls.Add(this.btn_pause);
            this.flowLayoutPanel1.Controls.Add(this.btn_previous);
            this.flowLayoutPanel1.Controls.Add(this.btn_next);
            this.flowLayoutPanel1.Controls.Add(this.progressBar_steps);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 398);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(511, 149);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // flowLayoutPanel_currBoard
            // 
            this.flowLayoutPanel_currBoard.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel_currBoard.Name = "flowLayoutPanel_currBoard";
            this.flowLayoutPanel_currBoard.Size = new System.Drawing.Size(511, 389);
            this.flowLayoutPanel_currBoard.TabIndex = 8;
            // 
            // SolutionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.lbl_stateIndex);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SolutionForm";
            this.Text = "Original IQ Tester: Solution";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox_stepsList;
        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btn_pause;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_previous;
        private System.Windows.Forms.Button btn_last;
        private System.Windows.Forms.Button btn_first;
        private System.Windows.Forms.Timer timer_play;
        private System.Windows.Forms.Label lbl_stateIndex;
        private System.Windows.Forms.ProgressBar progressBar_steps;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_currBoard;
    }
}