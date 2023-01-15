namespace Vsite.CSharp.Iznimke
{
    public partial class PeriodičniBacačIznimki : Form
    {
        public PeriodičniBacačIznimki()
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
