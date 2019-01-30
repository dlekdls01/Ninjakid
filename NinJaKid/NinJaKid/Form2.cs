using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NinJaKid
{
    public partial class Form2 : Form
    {
        Form1 form1;
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.Equals(textBox1.Text, string.Empty))
                return;
            if (string.Equals(textBox2.Text, string.Empty))
                return;
            form1 = new Form1(this);
            form1.id = textBox1.Text;
            form1.Show();
            this.Visible = false; 
        }
    }
}
