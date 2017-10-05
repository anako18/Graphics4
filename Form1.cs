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
        addEdge addEdgeForm;
        addPolygon addPolygonForm;


        //Координаты "центра"
        int OX;
        int OY;

        public Form1()
        {
            InitializeComponent();
            addPointForm = new addPoint(this);
            addEdgeForm = new addEdge(this,addPointForm);
            addPolygonForm = new addPolygon(this, addPointForm);

            Points.ContextMenuStrip = contextMenuStrip1;
            Edges.ContextMenuStrip = contextMenuStrip2;
            Polygons.ContextMenuStrip = contextMenuStrip3;
        }

        public Dictionary<string, Point> points_list;
        public Dictionary<string, Tuple<Point, Point>> edges_list;
        public Dictionary<string, List<Point>> polygon_list;

        private void Form1_Load(object sender, EventArgs e)
        {
            points_list = new Dictionary<string, Point>();
            edges_list = new Dictionary<string, Tuple<Point, Point>>();
            polygon_list = new Dictionary<string, List<Point>>();

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(bmp);

            OX = (pictureBox1.Width / 2);
            OY = (pictureBox1.Height / 2);
            Redraw();

        }

        public void AddNewPoint(string name, int x, int y)
        {
            points_list.Add(name, new Point(x, y));
            Points.Items.Add(points_list.Last());
            Draw_point();

            //((addEdgeForm.Controls["panel1"] as Panel).Controls["listBox1"] as ListBox).Items.Add(points_list.Last());
           // ((addEdgeForm.Controls["panel2"] as Panel).Controls["listBox2"] as ListBox).Items.Add(points_list.Last());
           // (addPolygonForm.Controls["listBox1"] as ListBox).Items.Add(points_list.Last());

            Points.Enabled = true;
        }

        public ListBox getPoints()
        {
            return Points;
        }

        
        public void AddNewEdge(string name, Point A, Point B)
        {
            edges_list.Add(name,Tuple.Create(A, B));
            Edges.Items.Add(edges_list.Last());
            g.DrawLine(pen, A.X + OX, A.Y + OY, B.X + OX, B.Y + OY);
            pictureBox1.Refresh();
            Edges.Enabled = true;
        }

        public void refresh_listboxes()
        {
            if (Points.Items.Count > 0)
            {
                ((addEdgeForm.Controls["panel1"] as Panel).Controls["listBox1"] as ListBox).Items.Clear();
                ((addEdgeForm.Controls["panel1"] as Panel).Controls["listBox1"] as ListBox).Items.AddRange(Points.Items);

                ((addEdgeForm.Controls["panel2"] as Panel).Controls["listBox2"] as ListBox).Items.Clear();
                ((addEdgeForm.Controls["panel2"] as Panel).Controls["listBox2"] as ListBox).Items.AddRange(Points.Items);

                (addPolygonForm.Controls["listBox1"] as ListBox).Items.Clear();
                (addPolygonForm.Controls["listBox1"] as ListBox).Items.AddRange(Points.Items);
            }
        }


        private void addPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refresh_listboxes();
            addPointForm.ShowDialog();
        }

        private void Draw_point()
        {
            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            g.DrawString(points_list.Last().Key,drawFont,drawBrush, points_list.Last().Value.X + OX, points_list.Last().Value.Y + OY);
            g.DrawEllipse(pen, new Rectangle(points_list.Last().Value.X + OX, points_list.Last().Value.Y + OY, 1, 1));
            pictureBox1.Refresh();  
        }

        private void addEdgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refresh_listboxes();
            addEdgeForm.ShowDialog();
        }

        private void Redraw()
        {
            g.Clear(Color.White);

            //Draw OX and OY
            Pen penLightGrey = new Pen(Color.LightGray);
            int h = pictureBox1.Height;
            int w = pictureBox1.Width;
            //OX
            g.DrawLine(penLightGrey, 0, h / 2, w, h / 2);
            g.DrawLine(penLightGrey, w - 10, (h / 2) - 2, w, h / 2);
            g.DrawLine(penLightGrey, w - 10, (h / 2) + 2, w, h / 2);

            //OY
            g.DrawLine(penLightGrey, w / 2, 0, w / 2, h);
            g.DrawLine(penLightGrey, (w / 2) - 2, 10, w / 2, 0);
            g.DrawLine(penLightGrey, (w / 2) + 2, 10, w / 2, 0);


            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            //Draw Points
            foreach (var pnt in points_list)
            {
                g.DrawEllipse(pen, new Rectangle(pnt.Value.X + OX, pnt.Value.Y + OY, 1, 1));
                g.DrawString(pnt.Key, drawFont, drawBrush, pnt.Value.X + OX, pnt.Value.Y + OY);
            }
            //Draw Edges
            foreach (var edg in edges_list)
            {
                g.DrawLine(pen, edg.Value.Item1.X + OX, edg.Value.Item1.Y + OY, edg.Value.Item2.X + OX, edg.Value.Item2.Y + OY);
            }
            this.Refresh();
        }

        //Delete Point
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Delete all the edges with this point
            for (int i = edges_list.Count-1; i>=0; i--)
            {
                if (edges_list.ElementAt(i).Key.Contains(Points.SelectedItem.ToString().Split(',')[0].Substring(1)))
                {
                    Edges.Items.Remove(edges_list.ElementAt(i));
                    edges_list.Remove(edges_list.ElementAt(i).Key);
                }
            }
            points_list.Remove(Points.SelectedItem.ToString().Split(',')[0].Substring(1));
            Points.Items.Remove(Points.SelectedItem);
            Redraw();
        }

        //Delete edge
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            edges_list.Remove(Edges.SelectedItem.ToString().Split(',')[0].Substring(1));
            Edges.Items.Remove(Edges.SelectedItem);
            Redraw();
        }

        //Delete polygon
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            List<Point> pol = polygon_list[Polygons.SelectedItem.ToString().Split(',')[0].Substring(1)];
            int cnt = 0;
            foreach (var pnt in pol)
            {
                //Delete all the edges with this points
                for (int i = edges_list.Count - 1; i >= 0; i--)
                {
                    if (edges_list.ElementAt(i).Key.Contains(Polygons.SelectedItem.ToString().Split(',')[0].Substring(1)[i]))
                    {
                        Edges.Items.Remove(edges_list.ElementAt(i));
                        edges_list.Remove(edges_list.ElementAt(i).Key);
                    }
                }
                //Delete points
                points_list.Remove(Polygons.SelectedItem.ToString().Split(',')[0].Substring(1)[cnt].ToString());
                for (var i = Points.Items.Count - 1; i >= 0; i--)
                {
                    if (Points.Items[i].ToString().Contains(Polygons.SelectedItem.ToString().Split(',')[0].Substring(1)[cnt].ToString()))
                        Points.Items.Remove(Points.Items[i]);
                }
                cnt++;
            }
            //Delete polygon
            polygon_list.Remove(Polygons.SelectedItem.ToString().Split(',')[0].Substring(1));
            Polygons.Items.Remove(Polygons.SelectedItem);
            Polygons.Items.Remove(Polygons.SelectedItem);
            Redraw();
        }

        private void addPolygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refresh_listboxes();
            addPolygonForm.ShowDialog();
        }


        public void addPolygon()
        {
            Polygons.Items.Add(polygon_list.Last());
            Polygons.Enabled = true;
        }
    }
}
