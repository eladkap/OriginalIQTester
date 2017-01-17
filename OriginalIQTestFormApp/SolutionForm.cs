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
        int q = 1;

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
            //ShowGraphsList(); // for check
        }

        private void BuildGraphsList()
        {
            graphsList = new List<Graph>();
            //textBox1.AppendText(VectorToString(initialVector)); // works
            Graph currentGraph = new Graph(boardLines, initialVector);
            //textBox1.AppendText($"Graph: {currentGraph}\n");
            textBox1.AppendText($"0#: {GetVectorString(currentGraph)}\n");
            graphsList.Add(currentGraph);
            int i = 1;
            foreach (Step step in stepsList)
            {
                currentGraph.PerformStep(step);
                textBox1.AppendText($"{i}: {currentGraph}\n");
                // textBox1.AppendText($"{i}#: {GetVectorString(currentGraph)}\n");
                graphsList.Add(currentGraph);
                i++;
            }
        }

        private void ShowGraphsList()
        {
            foreach (Graph graph in graphsList)
            {
                MessageBox.Show(GetVectorString(graph));
            }
        }

        private void SetCurrentBoard()
        {
            currentBoard = SetBoard(Color.Cyan, new Point(352, 109), 1);
        }

        private Board SetBoard(Color occupiedColor, Point location, int type)
        {
            Board board = new Board(boardLines, occupiedColor, type);
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
            currentGraphIndex = stepsList.Count - 1;
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

        private string GetVectorString(Graph graph)
        {
            string str = "";
            for (int i = 1; i < graph.V.Count; i++)
            {
                if (graph.V[i].HasChecker)
                {
                    str += $"({i},T) ";
                }
                else
                {
                    str += $"({i},F) ";
                }
            }
            return str;
        }

        private string VectorToString(bool[] vector)
        {
            string str = "";
            for (int i = 1; i < vector.Length; i++)
            {
                if (vector[i])
                {
                    str += "1 ";
                }
                else
                {
                    str += "0 ";
                }
            }
            return str;
        }

        private void UpdateBoardState()
        {
            //currentBoard._verticeslist[1].BackColor = Color.Green;

            Graph currentGraph = graphsList[currentGraphIndex];
            // textBox1.Text = ($"{currentGraphIndex}#{GetVectorString(currentGraph)}\n");

            for (int i = 1; i < currentGraph.V.Count; i++)
            {
                Vertex vertex = currentGraph.V[i];
                if (vertex.HasChecker)
                {
                    currentBoard._verticeslist[i - 1].BackColor = Color.Green;
                    currentBoard._verticeslist[i - 1].Update();
                }
                else
                {
                    currentBoard._verticeslist[i - 1].BackColor = Color.White;
                    currentBoard._verticeslist[i - 1].Update();
                }
            }
            q++;
            //currentBoard.SetBoardState(graphsList[currentGraphIndex]);
            //listBox_stepsList.SelectedIndex = currentGraphIndex + 1;
            lbl_stateIndex.Text = $"{currentGraphIndex + 1}";
            progressBar_steps.Value = currentGraphIndex;
            Invalidate();
            Update();
        }
    }
}
