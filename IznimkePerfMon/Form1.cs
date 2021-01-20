using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vsite.CSharp.Iznimke
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            numericUpDown1.Enabled = false;
            timer1.Interval = (int)(numericUpDown1.Value * 1000);
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            numericUpDown1.Enabled = true;
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                int b = 0;
                int res = 5 / b;
            }
            catch (DivideByZeroException exception)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("{0}: {1}", DateTime.Now.ToString("HH:mm:ss.ff"), exception.Message));
            }
        }
    }
}
