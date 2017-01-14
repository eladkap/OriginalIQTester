using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;
using Graphs;
using OriginalIQTesterLogic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace OriginalIQTestFormApp
{
    public partial class MainForm : Form
    {
        static Color OccupiedColor = Color.Blue;
        static Color EmptyColor = Color.White;
        static int DeltaH = 50;
        static double ShiftXRatio = 1.4;
        static int ButtonSize = 32;
        static int IndexFont = 10;
        static int PanelPaddingY = 10;
        static int PanelWidth = 400;
        static int PanelHeight = 300;

        int boardLines = 5;
        int vertices;
        List<Button> Vlist;
        Dictionary<int, Button> vertexToButtonDict;
        bool[] initialVector;
        bool[] finalVector;
        Graph graph;
        int mode;

        SolutionForm solutionForm;

        private BackgroundWorker solveBackgroundworker;

        public MainForm()
        {
            InitializeComponent();
            panel1.Paint += new PaintEventHandler(panel_Paint);
            panel2.Paint += new PaintEventHandler(panel_Paint);
            vertexToButtonDict = new Dictionary<int, Button>();
            vertices = CalculateVertices(boardLines);
            InitializeInitialVector();
            graph = new Graph(boardLines, initialVector);
            InitializeFinalVector();
            InitialMode();
            SetPanelSize(panel1, PanelWidth, PanelHeight);
            SetPanelSize(panel2, PanelWidth, PanelHeight);
            DisableProgressBar();
            solveBackgroundworker = new BackgroundWorker();
            solveBackgroundworker.DoWork += Solve_DoWork;
            solveBackgroundworker.RunWorkerCompleted += SolveCompleted;
            WindowState = FormWindowState.Maximized;
        }

        private void DisableProgressBar()
        {
            progressBar_solve.Style = ProgressBarStyle.Continuous;
            progressBar_solve.MarqueeAnimationSpeed = 0;
            progressBar_solve.Hide();
        }

        private void EnableProgressBar()
        {
            progressBar_solve.Style = ProgressBarStyle.Marquee;
            progressBar_solve.MarqueeAnimationSpeed = 30;
            progressBar_solve.Show();
        }

        private void InitialMode()
        {
            mode = 1; // classic
        }

        private void SetPanelSize(Panel panel, int panelWidth, int panelHeight)
        {
            panel.Size = new Size(PanelWidth, PanelHeight);
        }

        protected void panel_Paint(object sender, PaintEventArgs e)
        {
            BuildGraphVertices();
            BuildGraphEdges(e);
        }

        public void InitializeInitialVector()
        {
            initialVector = new bool[vertices + 1];
            for (int i = 0; i < initialVector.Length; i++)
            {
                initialVector[i] = true;
            }
        }

        public void InitializeFinalVector()
        {
            finalVector = new bool[vertices + 1];
            for (int i = 0; i < finalVector.Length; i++)
            {
                finalVector[i] = true;
            }
        }

        private int CalculateVertices(int boardLines)
        {
            int sum = 0;
            for (int i = 1; i <= boardLines; i++)
            {
                sum += i;
            }
            return sum;
        }

        public void BuildGraphEdges(PaintEventArgs e)
        {

            Graph G = new Graph(boardLines, initialVector);
            for (int i = 1; i < G.V.Count; i++)
            {
                for (int j = 1; j < G.V.Count; j++)
                {
                    if (G.V[i].Index < G.V[j].Index && G.V[i].IsNeighbor(G.V[j].Index))
                    {
                        Button btn1 = vertexToButtonDict[G.V[i].Index];
                        Button btn2 = vertexToButtonDict[G.V[j].Index];

                        Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));

                        int x1 = btn1.Location.X + btn1.Width / 2;
                        int y1 = btn1.Location.Y + btn1.Height / 2;
                        int x2 = btn2.Location.X + btn2.Width / 2;
                        int y2 = btn2.Location.Y + btn2.Height / 2;
                        e.Graphics.DrawLine(pen, x1, y1, x2, y2);
                    }
                }
            }
        }

        public void BuildGraphVertices()
        {
            Vlist = new List<Button>();
            Pen pen = new Pen(Color.Black, 3);
            Font font = new Font("Arial", IndexFont, FontStyle.Regular);

            int btnX = panel1.Width / 2;
            int btnY = PanelPaddingY;

            int deltaH = DeltaH;
            int shiftX = (int)(deltaH / ShiftXRatio);
            int k = 1;
            for (int i = 1; i <= boardLines; i++)
            {
                int firstBtnX = btnX;
                for (int j = 1; j <= i; j++, k++)
                {
                    Button btn = new Button();
                    btn.Click += new EventHandler(vertex_click);

                    btn.BackColor = OccupiedColor;
                    btn.Width = ButtonSize;
                    btn.Height = ButtonSize;

                    //GraphicsPath p = new GraphicsPath();
                    //p.AddEllipse(2, 2, btn.Width - 8, btn.Height - 8);
                    //btn.Region = new Region(p);

                    btn.Location = new Point(btnX, btnY);

                    //btn.CreateGraphics().DrawEllipse(pen, 5, 5, 20, 20);
                    btn.Text = $"{k}";
                    btn.Font = font;
                    panel1.Controls.Add(btn);
                    Vlist.Add(btn);
                    vertexToButtonDict[k] = btn;


                    if (i > 1)
                    {
                        btnX += shiftX * 2;
                    }
                }

                btnX = firstBtnX - shiftX;
                btnY += deltaH;
            }

        }

        private void vertex_click(object sender, EventArgs e)
        {
            Button srcBtn = (Button)sender;

            int vertexIndex = int.Parse(srcBtn.Text);
            if (initialVector[vertexIndex])
            {
                initialVector[vertexIndex] = false;
                srcBtn.BackColor = EmptyColor;
            }
            else
            {
                initialVector[vertexIndex] = true;
                srcBtn.BackColor = OccupiedColor;
            }
        }

        private int CountCheckers(bool[] vector)
        {
            int count = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                count += vector[i] ? 1 : 0;
            }
            return count;
        }

        private bool IsLegalInitialBoard()
        {
            return CountCheckers(initialVector) < initialVector.Length;
        }

        private void btn_solve_Click(object sender, EventArgs e)
        {
            if (!IsLegalInitialBoard())
            {
                MessageBox.Show("Illegal initial board.");
                return;
            }
            StartSolving();
        }

        private void StartSolving()
        {
            btn_solve.Enabled = false;
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

            solutionForm = new SolutionForm(vertices, boardLines, stepsList, initialVector);
            solutionForm.ShowDialog();
            solutionForm.Focus();
        }

        private void radioButton_advanced_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = radioButton_advanced.Checked;
            mode = radioButton_advanced.Checked ? 2 : 1;
        }

        private void radioButton_classic_CheckedChanged(object sender, EventArgs e)
        {
            mode = radioButton_classic.Checked ? 1 : 2;
        }

        private void timer_solve_Tick(object sender, EventArgs e)
        {
            EnableProgressBar();
        }

        //-------------------Solve Background worker--------------------------//

        private void SolveCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar_solve.Hide();
            btn_solve.Enabled = true;
            MessageBox.Show("Solve completed.");
            if (!e.Cancelled)
            {
                List<Step> stepsList = (List<Step>)e.Result;
                if (stepsList == null)
                {
                    ShowMessageNoSolution();
                }
                else
                {
                    ShowSolution(stepsList);
                }
            }
        }

        private void Solve_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = Solve(worker, e);
        }

        private List<Step> Solve(BackgroundWorker worker, DoWorkEventArgs e)
        {
            GameLogic gameLogic = new GameLogic(boardLines, initialVector, finalVector, mode);
            List<Step> stepsList = gameLogic.SolveGame();
            return stepsList;
        }
    }
}
