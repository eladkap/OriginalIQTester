using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;
using Graphs;

namespace OriginalIQTestFormApp
{
    public partial class Form1 : Form
    {
        int boardLines = 5;
        List<Button> Vlist;
        Dictionary<int, Button> vertexToButtonDict;
        bool[] U_init;

        public Form1()
        {
            InitializeComponent();
            panel1.Paint += new PaintEventHandler(panel_Paint);
            vertexToButtonDict = new Dictionary<int, Button>();
            InitialU_init();
        }

        protected void panel_Paint(object sender, PaintEventArgs e)
        {
            BuildGraphVertices();
            BuildGraphEdges(e);
        }

        public void InitialU_init()
        {
            U_init = new bool[CalculateVertices(boardLines) + 1];
            for (int i = 0; i < U_init.Length; i++)
            {
                U_init[i] = true;
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

            Graph G = new Graph(boardLines, U_init);
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
            Font font = new Font("Arial", 14, FontStyle.Regular);

            int btnX = panel1.Width / 2;
            int btnY = 10;

            int deltaH = 100;
            int shiftX = (int)(deltaH / 1.4);
            int k = 1;
            for (int i = 1; i <= boardLines; i++)
            {
                int firstBtnX = btnX;
                for (int j = 1; j <= i; j++, k++)
                {
                    Button btn = new Button();
                    btn.Click += new EventHandler(vertex_click);

                    btn.BackColor = Color.Red;
                    btn.Width = 40;
                    btn.Height = 40;

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
            if (U_init[vertexIndex])
            {
                U_init[vertexIndex] = false;
                srcBtn.BackColor = Color.Black;
            }
            else
            {
                U_init[vertexIndex] = true;
                srcBtn.BackColor = Color.Red;
            }
        }
    }
}
