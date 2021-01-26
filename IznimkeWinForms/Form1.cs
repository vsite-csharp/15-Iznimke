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

        // Pokrenuti program (ne iz Visual Studija!) i pritisnuti tipku na formi. Provjeriti što će se dogoditi nastavi li se izvođenje programa.

        private void buttonException_Click(object sender, EventArgs e)
        {
            throw new Exception("Iz forme");
        }
    }
}
