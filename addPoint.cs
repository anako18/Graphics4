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

        public addPoint()
        {
            InitializeComponent();
        }

        public addPoint(Form1 frm1)
        {
            InitializeComponent();
            parent = frm1;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try {
                    parent.AddNewPoint(pointName.Text, System.Convert.ToInt32(x.Value), System.Convert.ToInt32(y.Value));
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
