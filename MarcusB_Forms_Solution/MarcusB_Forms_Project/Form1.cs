namespace V2_Dag3_Ovn1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmdStang_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void cmdVisa_Click(object sender, EventArgs e)
        {
            lblVisa.Text = txtText.Text;
        }
        private void cmdDolj_Click(object sender, EventArgs e)
        {
            lblVisa.Text = "Det är väl inte så svårt";
        }

        
    }
}
