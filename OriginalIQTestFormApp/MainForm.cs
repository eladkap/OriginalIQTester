﻿using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;
using Graphs;
using OriginalIQTesterLogic;
using System.ComponentModel;
using System.Threading.Tasks;
using Utilities;

namespace OriginalIQTestFormApp
{
    public partial class MainForm : Form
    {
        private static Color EmptyColor = Color.White;

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
            vertices = Graph.CalculateVertices(boardLines);
            SetBoards();

            SetDefaultMode();
            SetDefaultBoardLines();
            DisableProgressBar();
            CreateSolveBackgroundWorker();
            SetLogger();
            //WindowState = FormWindowState.Maximized;
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

        private Board SetBoard(Color occupiedColor, Point location, int type)
        {
            Board board = new Board(boardLines, occupiedColor, type);
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
            initialBoard = SetBoard(Color.Blue, new Point(40, 160), 1);
        }

        private void SetFinalBoard()
        {
            finalBoard = SetBoard(Color.Green, new Point(570, 160), 2);
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
            solutionForm = new SolutionForm(vertices, boardLines, stepsList, initialBoard.Vector);
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

        private void radioButton_5_CheckedChanged(object sender, EventArgs e)
        {
            boardLines = 5;
            LoadBoards();
        }

        private void radioButton_4_CheckedChanged(object sender, EventArgs e)
        {
            boardLines = 4;
            LoadBoards();
        }

        private void LoadBoards()
        {
            initialBoard.Panel.Dispose();
            finalBoard.Panel.Dispose();
            SetBoards();
        }
    }
}