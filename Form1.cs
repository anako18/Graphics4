using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphics4
{

    public partial class Form1 : Form
    {
        Graphics g;

        Pen pen = new Pen(Color.Black);

        addPoint addPointForm;

        //Координаты "центра"
        int OX;
        int OY;

        public Form1()
        {
            InitializeComponent();
            addPointForm = new addPoint(this);
        }

        Dictionary<string, Point> points_list;

        private void Form1_Load(object sender, EventArgs e)
        {
            points_list = new Dictionary<string, Point>(); 
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(bmp);

            //g = pictureBox1.CreateGraphics();
            Pen penLightGrey = new Pen(Color.LightGray);
            int h = pictureBox1.Height;
            int w = pictureBox1.Width;
            //ось х
            g.DrawLine(penLightGrey, 0, h / 2, w, h / 2);
            g.DrawLine(penLightGrey, w - 10, (h / 2) - 2, w, h / 2);
            g.DrawLine(penLightGrey, w - 10, (h / 2) + 2, w, h / 2);

            //ось у
            g.DrawLine(penLightGrey, w / 2, 0, w / 2, h);
            g.DrawLine(penLightGrey, (w / 2) - 2, 10, w / 2, 0);
            g.DrawLine(penLightGrey, (w / 2) + 2, 10, w / 2, 0);

            OX = (pictureBox1.Width / 2);
            OY = (pictureBox1.Height / 2);
            //Point[] myPointArray = { new Point(0, 0), new Point(50, 30), new Point(30, 60) };
            //g.DrawPolygon(penLightGrey, myPointArray);

        }

        public void AddNewPoint(string name, int x, int y)
        {
            points_list.Add(name, new Point(x, y));
            Points.Items.Add(points_list.Last());
            Draw_point();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addPointForm.Show();
        }

        private void Draw_point()
        {
            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            g.DrawString(points_list.Last().Key,drawFont,drawBrush, points_list.Last().Value.X + OX, points_list.Last().Value.Y + OY);
            g.DrawEllipse(pen, new Rectangle(points_list.Last().Value.X + OX, points_list.Last().Value.Y + OY, 1, 1));
            pictureBox1.Refresh();
            
        }


    }
}
