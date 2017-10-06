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
    public partial class addPolygon : Form
    {

        
        public addPolygon()
        {
            InitializeComponent();
        }

        Form1 parent;
        addPoint addPointWindow;

        public addPolygon(Form1 frm1, addPoint pointw)
        {
            InitializeComponent();
            parent = frm1;
            addPointWindow = pointw;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addPointWindow.Show();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        //->
        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
                listBox2.Enabled = true;
                if (listBox2.Items.Count >= 3)
                    create_polygon_button.Enabled = true;
                else
                    create_polygon_button.Enabled = false;
            }
        }

        //<-
        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                listBox1.Items.Add(listBox2.SelectedItem);
                listBox2.Items.Remove(listBox2.SelectedItem);
                if (listBox2.Items.Count == 0)
                    listBox2.Enabled = false;
                if (listBox2.Items.Count < 3)
                    create_polygon_button.Enabled = false;
            }
        }


        private void create_polygon_button_Click(object sender, EventArgs e)
        {

            string newname = "";
            
            List<Point> list_verts = new List<Point>();
            int x2, y2, x1, y1;
            foreach( var x in listBox2.Items)
            {
                string[] s =x.ToString().Split(',');
                newname += s[0].Substring(1);
                x1 = System.Convert.ToInt32(string.Join("", s[1].ToCharArray().Where(Char.IsDigit)));
                y1 = System.Convert.ToInt32(string.Join("", s[2].ToCharArray().Where(Char.IsDigit)));
                list_verts.Add(new Point(x1, y1));
            }
            
            for( int i = 0; i < list_verts.Count - 1; i++)
            {
                        string edgename = newname[i].ToString() + newname[i + 1].ToString();
                        parent.AddNewEdge(edgename, new Point(list_verts[i].X, list_verts[i].Y),
                                                    new Point(list_verts[i + 1].X, list_verts[i + 1].Y));
            }
            parent.AddNewEdge((newname[list_verts.Count - 1].ToString() + newname[0].ToString()), new Point(list_verts[list_verts.Count - 1].X, list_verts[list_verts.Count - 1].Y),
                                                    new Point(list_verts[0].X, list_verts[0].Y));

            
            listBox1.Items.AddRange(listBox2.Items);
            listBox2.Items.Clear();
            parent.polygon_list.Add(newname, list_verts);
            parent.addPolygon();
            parent.Redraw();
        }
    }
}
