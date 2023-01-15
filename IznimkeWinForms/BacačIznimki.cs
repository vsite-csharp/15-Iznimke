namespace Vsite.CSharp.Iznimke
{
    public partial class BacačIznimki : Form
    {
        public BacačIznimki()
        {
            InitializeComponent();
        }

        // TODO:080 Pokrenuti program pomoću Ctrl + F5 ili izvan Visual Studija i pritisnuti tipku na formi. Provjeriti što će se dogoditi nastavi li se izvođenje programa.

        private void buttonException_Click(object sender, EventArgs e)
        {
            throw new Exception("Iz forme");
        }
    }
}
