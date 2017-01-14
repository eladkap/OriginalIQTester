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
        private static Color EmptyColor = Color.White;

        int boardLines = 5;
        int vertices;
        bool[] initialVector;
        bool[] finalVector;
        int mode;

        Board initialBoard;
        Board finalBoard;

        SolutionForm solutionForm;

        private BackgroundWorker solveBackgroundworker;

        public MainForm()
        {
            InitializeComponent();

            vertices = CalculateVertices(boardLines);

            SetInitialBoard();
            SetFinalBoard();

            SetMode();
            DisableProgressBar();
            solveBackgroundworker = new BackgroundWorker();
            solveBackgroundworker.DoWork += Solve_DoWork;
            solveBackgroundworker.RunWorkerCompleted += SolveCompleted;
            WindowState = FormWindowState.Maximized;
        }

        private Board SetBoard(bool[] vector, Color occupiedColor, Point location)
        {
            Board board = new Board(boardLines, occupiedColor, vector);
            board.Panel.Paint += new PaintEventHandler(panel_Paint);
            board.Panel.Location = new Point(location.X, location.Y);
            foreach (var vertexButton in board.VertexButtonsList)
            {
                vertexButton.Click += new EventHandler(vertex_click);
            }
            Controls.Add(board.Panel);
            return board;
        }

        private void SetInitialBoard()
        {
            initialVector = InitializeVector(true);
            initialBoard = SetBoard(initialVector, Color.Blue, new Point(40, 160));
        }

        private void SetFinalBoard()
        {
            finalVector = InitializeVector(false);
            finalBoard = SetBoard(finalVector, Color.Green, new Point(570, 160));
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

        private void SetMode()
        {
            mode = 1; // classic
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

        private int CalculateVertices(int boardLines)
        {
            int sum = 0;
            for (int i = 1; i <= boardLines; i++)
            {
                sum += i;
            }
            return sum;
        }

        //----------------------Board--------------------------------//

        protected void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            if (initialBoard.Panel == panel)
            {
                initialVector = InitializeVector(true);
                //initialBoard.BuildGraphVertices(initialVector);
                initialBoard.Vector = initialVector;
                initialBoard.BuildGraphEdges(e, initialVector);
            }
            else if (finalBoard.Panel == panel)
            {
                finalVector = InitializeVector(false);
                //finalBoard.BuildGraphVertices(finalVector);
                finalBoard.Vector = finalVector;
                finalBoard.BuildGraphEdges(e, finalVector);
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
            MessageBox.Show($"{vertexIndex} {board.OccupiedColor} {board.Vector[vertexIndex]}");
            board.Update(vertexIndex);
            /*
            if (board == initialBoard)
            {
                UpdateBoard(initialBoard, initialVector, srcBtn, vertexIndex);
            }
            else if (board == finalBoard)
            {
                UpdateBoard(finalBoard, finalVector, srcBtn, vertexIndex);
            }
            */
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

        //-------------------------------------------------------//

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
