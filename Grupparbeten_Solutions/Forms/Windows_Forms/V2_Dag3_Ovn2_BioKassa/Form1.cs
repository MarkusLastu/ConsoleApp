namespace V2_Dag3_Ovn2_BioKassa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateComboBoxes();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PopulateComboBoxes()
        {
            // Create an instance of BioMeny
            BioMeny bioMeny = new BioMeny();
            // Populate the snack combo box
            foreach (var snack in bioMeny.Snacks)
            {
                cmb_Products.Items.Add(snack.Namn);
            }
            // Populate the drink combo box
            foreach (var drink in bioMeny.Drinks)
            {
                cmb_Drinks.Items.Add(drink.Namn);
            }

            // Populate the movie combo box
            


            // Populate the ticket combo box
            foreach (var ticket in bioMeny.Tickets)
            {
                cmb_Tickets.Items.Add(ticket.Typ);
            }

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
