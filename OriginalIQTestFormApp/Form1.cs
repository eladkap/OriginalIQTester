using System.Collections.Generic;
using System.Windows.Forms;
using Logic;
using System.Drawing;
using System;
using System.Drawing.Drawing2D;

namespace OriginalIQTestFormApp
{
    public partial class Form1 : Form
    {
        List<Button> Vlist;

        public Form1()
        {
            InitializeComponent();
            BuildGraphVertices();
            BuildGraphEdges();
        }

        public void BuildGraphEdges()
        {
            Graph G = new Graph(15, 5);
            foreach (var vertex1 in G.V)
            {
                foreach (var vertex2 in G.V)
                {
                    if (vertex1.Index<vertex2.Index && vertex1.IsNeigbor(vertex2))
                    {

                    }
                
                    
                }
            } 
        }

        public void BuildGraphVertices()
        {
            Vlist = new List<Button>();
            Pen pen = new Pen(Color.Black, 3);
            Font font = new Font("Arial", 14, FontStyle.Regular);

            int btnX = panel1.Width / 2 ;
            int btnY = 10;

            int h = 100;
            int deltaH = 50;
            int shiftX = deltaH / (int)Math.Sqrt(3);
            int k = 1;
            for (int i = 1; i <= Constants.LINES; i++)
            {
                int firstBtnX = btnX;
                for (int j = 1; j <= i; j++,k++)
                {
                    Button btn = new Button();
                    btn.BackColor = Color.Black;
                    btn.Width = 20;
                    btn.Height = 20;

                    //GraphicsPath p = new GraphicsPath();
                    //p.AddEllipse(2, 2, btn.Width - 8, btn.Height - 8);
                    //btn.Region = new Region(p);

                    btn.Location = new Point(btnX, btnY);

                    //btn.CreateGraphics().DrawEllipse(pen, 5, 5, 20, 20);
                    btn.Text = $"";
                    btn.Font = font;
                    panel1.Controls.Add(btn);
                    Vlist.Add(btn);


                    if (i > 1)
                    {
                        btnX += shiftX*2;
                    }
                }

                btnX = firstBtnX - shiftX;
                btnY += deltaH;
            }

        }
    }
}
