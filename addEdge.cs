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
    public partial class addEdge : Form
    {
        public addEdge()
        {
            InitializeComponent();
        }

        Form1 parent;
        addPoint addPointWindow;

        public addEdge(Form1 frm1, addPoint pointw)
        {
            InitializeComponent();
            parent = frm1;
            addPointWindow = pointw;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addPointWindow.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void addEdge_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //create_edge_button.Enabled = true;
            panel2.Enabled = true;
            listBox2.Items.Remove(listBox1.SelectedItem);
            panel1.Enabled = false;
            ok_button.Enabled = false;
        }

        private void cancel_button_click(object sender, EventArgs e)
        {
            panel2.Enabled = false;
            panel1.Enabled = true;
            create_edge_button.Enabled = false;
            listBox2.Items.Add(listBox1.SelectedItem);
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            ok_button.Enabled = true;
        }

        private void listBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            create_edge_button.Enabled = true;
        }



        private void create_edge_button_Click(object sender, EventArgs e)
        {
            string[] s1 = listBox1.SelectedItem.ToString().Split(',');
            string[] s2 = listBox2.SelectedItem.ToString().Split(',');
            string newname = s1[0].Substring(1) + s2[0].Substring(1);
            int x1 = System.Convert.ToInt32( string.Join("", s1[1].ToCharArray().Where(Char.IsDigit)));
            int x2 = System.Convert.ToInt32(string.Join("", s2[1].ToCharArray().Where(Char.IsDigit)));
            int y1 = System.Convert.ToInt32(string.Join("", s1[2].ToCharArray().Where(Char.IsDigit)));
            int y2 = System.Convert.ToInt32(string.Join("", s2[2].ToCharArray().Where(Char.IsDigit)));
            parent.AddNewEdge(newname, new Point(x1, y1), new Point(x2, y2));
        }
    }
}
