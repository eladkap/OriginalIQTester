using Graphs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OriginalIQTestFormApp
{
    public partial class SolutionForm : Form
    {
        List<Graph> graphsList;
        int boardLines;
        int vertices;
        bool[] initialVector;
        List<Step> stepsList;
        int currentGraphIndex;
        Board currentBoard;
        public MainForm _mainForm;

        public SolutionForm(int vertices, int boardLines, List<Step> stepsList, bool[] initialVector)
        {
            InitializeComponent();
            this.stepsList = stepsList;
            this.boardLines = boardLines;
            this.vertices = vertices;
            this.initialVector = initialVector;
            BuildGraphsList();
            currentGraphIndex = 0;
            SetCurrentBoard();
            LoadStepsList();
            progressBar_steps.Maximum = stepsList.Count;
            UpdateBoardState();
        }

        private void BuildGraphsList()
        {
            graphsList = new List<Graph>();
            Graph currentGraph = new Graph(boardLines, initialVector);
            graphsList.Add(currentGraph);
            int i = 2;
            foreach (Step step in stepsList)
            {
                Graph newGraph = currentGraph.CopyGraph();
                newGraph.PerformStep(step);
                graphsList.Add(newGraph);
                currentGraph = newGraph;
                i++;
            }
        }

        private void SetCurrentBoard()
        {
            currentBoard = SetBoard(Color.Cyan, new Point(352, 109), 1);
        }

        private Board SetBoard(Color occupiedColor, Point location, int type)
        {
            Board board = new Board(boardLines, occupiedColor, type, _mainForm.screenSize);
            board.Vector = initialVector;
            board.Panel.Paint += new PaintEventHandler(panel_Paint);
            board.Panel.Location = new Point(location.X, location.Y);
            Controls.Add(board.Panel);
            return board;
        }

        protected void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            if (currentBoard.Panel == panel)
            {
                currentBoard.BuildGraphEdges(e);
            }
        }

        private void LoadStepsList()
        {
            foreach (Step step in stepsList)
            {
                listBox_stepsList.Items.Add(step);
            }
        }

        //*********************Move Buttons Methods******************************//

        private void GotoFirstStep()
        {
            currentGraphIndex = 0;
            UpdateBoardState();
        }

        private void GotoLastStep()
        {
            currentGraphIndex = stepsList.Count;
            UpdateBoardState();
        }

        private void GotoNextStep()
        {
            if (currentGraphIndex < stepsList.Count)
            {
                currentGraphIndex++;
                UpdateBoardState();
            }
        }

        private void GotoPreviousStep()
        {
            if (currentGraphIndex > 0)
            {
                currentGraphIndex--;
                UpdateBoardState();
            }
        }

        private void PlaySteps()
        {
            timer_play.Enabled = true;
        }

        private void PauseSteps()
        {
            timer_play.Enabled = false;
        }

        //*********************Button Click Methods******************************//

        private void btn_pause_Click(object sender, System.EventArgs e)
        {
            PauseSteps();
        }

        private void btn_next_Click(object sender, System.EventArgs e)
        {
            GotoNextStep();
        }

        private void btn_first_Click(object sender, System.EventArgs e)
        {
            GotoFirstStep();
        }

        private void btn_last_Click(object sender, System.EventArgs e)
        {
            GotoLastStep();
        }

        private void btn_play_Click(object sender, System.EventArgs e)
        {
            PlaySteps();
        }

        private void btn_previous_Click(object sender, System.EventArgs e)
        {
            GotoPreviousStep();
        }

        //*********************Timer Tick Method******************************//

        private void timer_play_Tick(object sender, System.EventArgs e)
        {
            GotoNextStep();
        }

        private void listBox_stepsList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            currentGraphIndex = listBox_stepsList.SelectedIndex;
            UpdateBoardState();
        }


        private void UpdateBoardState()
        {
            Graph currentGraph = graphsList[currentGraphIndex];
            for (int i = 1; i < currentGraph.V.Count; i++)
            {
                Vertex vertex = currentGraph.V[i];
                if (vertex.HasChecker)
                {
                    currentBoard._verticeslist[i - 1].BackColor = Color.Green;
                }
                else
                {
                    currentBoard._verticeslist[i - 1].BackColor = Color.White;
                }
            }
            lbl_stateIndex.Text = $"{currentGraphIndex + 1}";
            progressBar_steps.Value = currentGraphIndex;
        }
    }
}
