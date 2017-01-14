using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Graphs;

namespace OriginalIQTestFormApp
{
    public class Board
    {
        private static Color EmptyColor = Color.White;
        private static int DeltaH = 50;
        private static double ShiftXRatio = 1.4;
        private static int ButtonSize = 32;
        private static int IndexFont = 10;
        private static int PanelPaddingY = 10;
        private static int PanelWidth = 400;
        private static int PanelHeight = 300;

        private Color _occupiedColor;
        private int _boardLines;
        private Graph _graph;
        private Panel _panel;
        private List<Button> _verticeslist;
        private Dictionary<int, Button> _vertexToButtonDict;

        public Panel Panel { get { return _panel; } }

        public Graph Graph { get { return _graph; } }

        public List<Button> VertexButtonsList { get { return _verticeslist; } }

        public Button GetVertexButton(int index)
        {
            return _verticeslist[index];
        }

        public Color OccupiedColor { get { return _occupiedColor; } }

        public bool[] Vector { get; set; }

        public Board(int boardLines, Color occupiedColor, bool[] vector)
        {
            _occupiedColor = occupiedColor;
            _boardLines = boardLines;
            _panel = new Panel();
            SetPanelSize(_panel, PanelWidth, PanelHeight);
            _vertexToButtonDict = new Dictionary<int, Button>();
            _verticeslist = new List<Button>();
            Vector = vector;
            BuildGraphVertices(vector);
        }

        private void SetPanelSize(Panel panel, int panelWidth, int panelHeight)
        {
            panel.Size = new Size(PanelWidth, PanelHeight);
        }

        public void BuildGraphVertices(bool[] vector)
        {
            Pen pen = new Pen(Color.Black, 3);
            Font font = new Font("Arial", IndexFont, FontStyle.Regular);

            int btnX = _panel.Width / 2;
            int btnY = PanelPaddingY;

            int deltaH = DeltaH;
            int shiftX = (int)(deltaH / ShiftXRatio);
            int k = 1;
            for (int i = 1; i <= _boardLines; i++)
            {
                int firstBtnX = btnX;
                for (int j = 1; j <= i; j++, k++)
                {
                    Button btn = new Button();

                    btn.BackColor = vector[k] ? _occupiedColor : EmptyColor;
                    btn.Width = ButtonSize;
                    btn.Height = ButtonSize;

                    btn.Location = new Point(btnX, btnY);

                    btn.Text = $"{k}";
                    btn.Font = font;
                    _panel.Controls.Add(btn);
                    _verticeslist.Add(btn);
                    _vertexToButtonDict[k] = btn;

                    if (i > 1)
                    {
                        btnX += shiftX * 2;
                    }
                }

                btnX = firstBtnX - shiftX;
                btnY += deltaH;
            }
        }
        public void BuildGraphEdges(PaintEventArgs e, bool[] vector)
        {
            _graph = new Graph(_boardLines, vector);
            for (int i = 1; i < _graph.V.Count; i++)
            {
                for (int j = 1; j < _graph.V.Count; j++)
                {
                    if (_graph.V[i].Index < _graph.V[j].Index && _graph.V[i].IsNeighbor(_graph.V[j].Index))
                    {
                        Button btn1 = _vertexToButtonDict[_graph.V[i].Index];
                        Button btn2 = _vertexToButtonDict[_graph.V[j].Index];

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

        public void Update(int vertexIndex)
        {
            Vector[vertexIndex] = !Vector[vertexIndex];
            _verticeslist[vertexIndex - 1].BackColor = Vector[vertexIndex] ? _occupiedColor : EmptyColor;
        }
    }
}
