using Graphs;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OriginalIQTestFormApp
{
    public partial class SolutionForm : Form
    {
        Graph graph;
        bool[] initialVector;
        List<Step> stepsList;


        public SolutionForm(List<Step> stepsList, bool[] initialVector)
        {
            InitializeComponent();
            this.stepsList = stepsList;
            this.initialVector = initialVector;
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

        private void GotoFirstStep()
        {

        }

        private void GotoLastStep()
        {

        }

        private void GotoNextStep()
        {

        }

        private void GotoPreviousStep()
        {

        }

        private void PlaySteps()
        {
            timer_play.Enabled = true;
        }

        private void PauseSteps()
        {
            timer_play.Enabled = false;
        }

        private void btn_pause_Click(object sender, System.EventArgs e)
        {
            PauseSteps();
        }

        private void btn_next_Click(object sender, System.EventArgs e)
        {

        }
    }
}
