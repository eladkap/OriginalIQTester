using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;
using Graphs;
using OriginalIQTesterLogic;
using System.ComponentModel;
using System.Threading.Tasks;
using Utilities;

// 1440x1080 - Slides projector
// 1368x766 - Laptop
// 1920x1040 - Wide Screen

namespace OriginalIQTestFormApp
{
    public partial class MainForm : Form
    {
        private static Color EmptyColor = Color.White;
        private static Color bg1 = Color.FromArgb(26, 32, 40); // backcolor1
        private static Color bg2 = Color.FromArgb(37, 46, 59); // backcolor2
        private static Color fc1 = Color.Azure; // forecolor1

        public Size screenSize;
        private Logger _logger;

        int boardLines = 5;
        int vertices;
        int mode;

        Board initialBoard;
        Board finalBoard;

        SolutionForm solutionForm;

        private BackgroundWorker solveBackgroundworker;

        public MainForm()
        {
            InitializeComponent();
            screenSize = GetScreenResolution();
            //MessageBox.Show($"{screenSize.Width}x{screenSize.Height}");
            vertices = Graph.CalculateVertices(boardLines);
            SetBoards();
            SetDefaultMode();
            SetDefaultBoardLines();
            DisableProgressBar();
            CreateSolveBackgroundWorker();
            SetLogger();
            SetScreen();
            SetControlsStyle();
            ResizeResolution(screenSize);
            //WindowState = FormWindowState.Maximized;
        }

        private void ResizeResolution(Size resolution)
        {
            screenSize = resolution;
            SetScreen();
            initialBoard.ResizeControlsByResolution(resolution);
            finalBoard.ResizeControlsByResolution(resolution);
        }

        private Size GetScreenResolution()
        {
            Screen screen = Screen.FromControl(this);
            Rectangle area = screen.WorkingArea;
            return area.Size;
        }

        private void SetControlsStyle()
        {
            BackColor = bg1;
            groupBox_boardLines.BackColor = bg2;
            groupBox_mode.BackColor = bg2;
            radioButton_4.ForeColor = fc1;
            radioButton_5.ForeColor = fc1;
            radioButton_advanced.ForeColor = fc1;
            radioButton_classic.ForeColor = fc1;
            label1.ForeColor = fc1;
            label2.ForeColor = fc1;
            groupBox_boardLines.ForeColor = Color.LightCyan;
            groupBox_mode.ForeColor = Color.LightCyan;
        }

        private void SetScreen()
        {
            Location = new Point(0, 0);
            Size = screenSize;
        }

        private void SetLogger()
        {
            _logger = new Logger();
            _logger.LogArrived += LogArrivedHandler;
        }

        private void LogArrivedHandler(object o, LogEventArgs e)
        {
            Invoke(new Action(() =>
            {
                txt_log.AppendText(_logger.GetLastMessage() + "\n");
                txt_log.SelectionStart = txt_log.TextLength;
                txt_log.ScrollToCaret();
            }));
        }

        private void CreateSolveBackgroundWorker()
        {
            solveBackgroundworker = new BackgroundWorker();
            solveBackgroundworker.DoWork += Solve_DoWork;
            solveBackgroundworker.RunWorkerCompleted += SolveCompleted;
            solveBackgroundworker.WorkerSupportsCancellation = true;
        }

        private void SetBoards()
        {
            SetInitialBoard();
            SetFinalBoard();
        }

        private Board SetBoard(Color occupiedColor, int type)
        {
            Board board = new Board(boardLines, occupiedColor, type, screenSize);
            board.Panel.Paint += new PaintEventHandler(panel_Paint);
            foreach (var vertexButton in board.VertexButtonsList)
            {
                vertexButton.Click += new EventHandler(vertex_click);
            }
            if (type == 1)
            {
                flowLayoutPanel1.Controls.Add(board.Panel);
            }
            else
            {
                flowLayoutPanel2.Controls.Add(board.Panel);
            }
            return board;
        }

        private void SetInitialBoard()
        {
            initialBoard = SetBoard(bg1, 1);
        }

        private void SetFinalBoard()
        {
            finalBoard = SetBoard(bg1, 2);
        }

        private void DisableProgressBar()
        {
            progressBar_solve.Style = ProgressBarStyle.Continuous;
            progressBar_solve.MarqueeAnimationSpeed = 0;
        }

        private void EnableProgressBar()
        {
            progressBar_solve.Style = ProgressBarStyle.Marquee;
            progressBar_solve.MarqueeAnimationSpeed = 30;
            progressBar_solve.Show();
        }

        private void SetDefaultMode()
        {
            mode = 1; // classic
            radioButton_classic.Checked = true;
            radioButton_advanced.Checked = false;
        }

        private void SetDefaultBoardLines()
        {
            boardLines = 5;
            radioButton_5.Checked = true;
            radioButton_4.Checked = false;
            finalBoard.Panel.Visible = false;
        }

        public bool[] InitializeVector(bool value)
        {
            bool[] vector = new bool[vertices + 1];
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = value;
            }
            return vector;
        }

        //----------------------Board--------------------------------//

        protected void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            if (initialBoard.Panel == panel)
            {
                initialBoard.BuildGraphEdges(e);
            }
            else if (finalBoard.Panel == panel)
            {
                finalBoard.BuildGraphEdges(e);
            }
        }

        private Board GetBoardByButton(Button vertexButton)
        {
            foreach (var button in initialBoard.VertexButtonsList)
            {
                if (button == vertexButton)
                {
                    return initialBoard;
                }
            }
            foreach (var button in finalBoard.VertexButtonsList)
            {
                if (button == vertexButton)
                {
                    return finalBoard;
                }
            }
            return null;
        }

        private void vertex_click(object sender, EventArgs e)
        {
            Button srcBtn = (Button)sender;
            Board board = GetBoardByButton(srcBtn);
            int vertexIndex = int.Parse(srcBtn.Text);
            board.ChangeState(vertexIndex);
        }

        private void UpdateBoard(Board board, bool[] vector, Button srcBtn, int vertexIndex)
        {
            if (vector[vertexIndex])
            {
                vector[vertexIndex] = false;
                srcBtn.BackColor = EmptyColor;
            }
            else
            {
                vector[vertexIndex] = true;
                srcBtn.BackColor = board.OccupiedColor;
            }
        }

        //--------------------Solver-----------------------------------//  

        private void btn_solve_Click(object sender, EventArgs e)
        {
            if (!initialBoard.IsLegalBoard())
            {
                MessageBox.Show($"Illegal initial board.");
                return;
            }
            if (!finalBoard.IsLegalBoard())
            {
                MessageBox.Show("Illegal final board.");
                return;
            }
            StartSolving();
        }

        private void StartSolving()
        {
            btn_solve.Enabled = false;
            btn_cancel.Enabled = true;
            EnableProgressBar();
            Invoke(new Action(() => progressBar_solve.Maximum = 100));
            Invoke(new Action(() => progressBar_solve.Value = 0));
            Task.Run(() => solveBackgroundworker.RunWorkerAsync());
        }

        private void ShowMessageNoSolution()
        {
            MessageBox.Show("No solution exists.");
            DisableProgressBar();
        }

        private void ShowSolution(List<Step> stepsList)
        {
            solutionForm = new SolutionForm(vertices, boardLines, stepsList, initialBoard.Vector, this, screenSize);
            solutionForm._mainForm = this;
            solutionForm.ShowDialog();
        }

        private void radioButton_advanced_CheckedChanged(object sender, EventArgs e)
        {
            finalBoard.Panel.Visible = radioButton_advanced.Checked;
            mode = radioButton_advanced.Checked ? 2 : 1;
        }

        private void radioButton_classic_CheckedChanged(object sender, EventArgs e)
        {
            mode = radioButton_classic.Checked ? 1 : 2;
        }

        //-------------------Solve Background worker--------------------------//

        private void SolveCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Invoke(new Action(() => progressBar_solve.Hide()));
            Invoke(new Action(() => btn_solve.Enabled = true));
            if (e.Result == null) // e.Cancelled
            {
                MessageBox.Show("Solving cancelled.");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error in solving. process aborted.");
            }
            else
            {
                MessageBox.Show("Solving completed.");
                List<Step> stepsList = (List<Step>)e.Result;
                if (stepsList.Count == 0)
                {
                    ShowMessageNoSolution();
                }
                else
                {
                    ShowSolution(stepsList);
                }
            }
            _logger.ClearLogger();
            Invoke(new Action(() => txt_log.Clear()));
        }

        private void Solve_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = Solve(worker);
        }

        private List<Step> Solve(BackgroundWorker worker)
        {
            GameLogic gameLogic = new GameLogic(boardLines, initialBoard.Vector, finalBoard.Vector, mode);
            List<Step> stepsList = gameLogic.SolveGame(solveBackgroundworker, _logger);
            return stepsList;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            CancelSolving();
        }

        private void CancelSolving()
        {
            if (solveBackgroundworker.IsBusy)
            {
                solveBackgroundworker.CancelAsync();
                btn_cancel.Enabled = false;
                btn_solve.Enabled = true;
                DisableProgressBar();
            }
        }

        private void radioButton_4_CheckedChanged(object sender, EventArgs e)
        {
            boardLines = 4;
            LoadBoards();
        }

        private void radioButton_5_CheckedChanged(object sender, EventArgs e)
        {
            boardLines = 5;
            LoadBoards();
        }

        private void radioButton_6_CheckedChanged(object sender, EventArgs e)
        {
            boardLines = 6;
            LoadBoards();
        }

        private void LoadBoards()
        {
            initialBoard.Panel.Dispose();
            finalBoard.Panel.Dispose();
            SetBoards();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            float width_ratio = (Screen.PrimaryScreen.Bounds.Width / 1280);
            float height_ratio = (Screen.PrimaryScreen.Bounds.Height / 800f);


            SizeF scale = new SizeF(width_ratio, height_ratio);

            this.Scale(scale);

            //And for font size
            foreach (Control control in this.Controls)
            {
                control.Font = new Font("Microsoft Sans Serif", control.Font.SizeInPoints * width_ratio * height_ratio);
                if (control.HasChildren)
                {
                    foreach (Control childControl in control.Controls)
                    {
                        childControl.Font = new Font("Microsoft Sans Serif", childControl.Font.SizeInPoints * width_ratio * height_ratio);
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void Exit()
        {
            Environment.Exit(0);
        }
    }
}
