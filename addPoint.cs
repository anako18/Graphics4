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
    public partial class addPoint : Form
    {
        private Form1 parent;

        public addPoint(int w, int h)
        {
            InitializeComponent();
        }

        public addPoint(Form1 frm1, int w, int h)
        {
            InitializeComponent();
            parent = frm1;
            x.Minimum = -w / 2;
            y.Minimum = -h / 2;
            x.Maximum = w / 2;
            y.Maximum = h / 2;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try {
                    parent.AddNewPoint(pointName.Text, System.Convert.ToInt32(x.Value), System.Convert.ToInt32(y.Value));
                    parent.refresh_listboxes();
                    this.Hide();
                    label1.Visible = false;
            }
            catch(ArgumentException)
            {
                label1.Visible = true;
                this.Refresh();
            }
        }
    }
}
