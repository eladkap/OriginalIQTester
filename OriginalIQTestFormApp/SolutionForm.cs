using Graphs;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OriginalIQTestFormApp
{
    public partial class SolutionForm : Form
    {
        Graph currentGraph;
        int boardLines;
        int vertices;
        bool[] initialVector;
        List<Step> stepsList;
        int currentStepNumber;

        public SolutionForm(int vertices, int boardLines, List<Step> stepsList, bool[] initialVector)
        {
            InitializeComponent();
            this.stepsList = stepsList;
            this.boardLines = boardLines;
            this.vertices = vertices;
            this.initialVector = initialVector;
            currentGraph = new Graph(boardLines, initialVector);
            currentStepNumber = 0;
            LoadStepsList();
        }

        private void LoadStepsList()
        {
            foreach (Step step in stepsList)
            {
                listBox_stepsList.Items.Add(step);
            }
        }

        private void UpdateGraph(Graph currentGraph)
        {
            foreach (var vertex in currentGraph.V)
            {
                if (vertex.HasChecker)
                {
                    // update button accordingly
                }
            }
        }

        //*********************Move Buttons Methods******************************//

        private void GotoFirstStep()
        {
            currentStepNumber = 0;
        }

        private void GotoLastStep()
        {
            currentStepNumber = stepsList.Count - 1;
        }

        private void GotoNextStep()
        {
            if (currentStepNumber < stepsList.Count)
            {
                currentStepNumber++;
            }
        }

        private void GotoPreviousStep()
        {
            if (currentStepNumber > 0)
            {
                currentStepNumber--;
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
            currentStepNumber = listBox_stepsList.SelectedIndex;
        }
    }
}
