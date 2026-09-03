using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace V2_Dag3_Ovn2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FillArrayWithValues();
        }

        private void cmdBeslut_Click(object sender, EventArgs e)
        {
            string input = txtVal.Text;

            //oavsett om du svarat "Ja" eller "ja" så ändas svaret till ja
            switch (input.ToLower())
            {
                case "ja":
                case "kanske":

                    MessageBox.Show("Toppen!");
                    break;
                case "nej":
                    MessageBox.Show("Tråkigt!");
                    break;

            }
        }
        public void FillArrayWithValues()
        {
            try
            {
                //using StreamReader sr = new StreamReader(@"ImportFiler\dessert.txt");

                string filePath = Path.Combine(
                    AppContext.BaseDirectory,
                        "ImportFiler",
                        "dessert.txt");

                using StreamReader sr = new StreamReader(filePath);

                string line = sr.ReadLine();

                // string[] valuesText = new string[10];
                List<string> valuesText = new List<string>();

                //initialisera räknare i
                int i = 0;
                while (line != null)
                {
                    valuesText.Add(line);
                    line = sr.ReadLine();
                    Debug.WriteLine($"Läser rad {i}: {valuesText[i]}");
                    ++i;
                }
                //skriver ut arrayen:
                string output = string.Empty;
                foreach (var item in valuesText)
                {
                    if (item != null)
                    {
                        output += item + "\n";
                        cmbDesserts.Items.Add(item);
                    }
                }

                MessageBox.Show(output);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }

        }

        private void cmbDesserts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kontrollera att något faktiskt är valt
            if (cmbDesserts.SelectedItem != null)
            {
                txtVal.Text = cmbDesserts.SelectedItem.ToString();
            }
            else
            {
                txtVal.Text = string.Empty; // tomt om inget är valt
            }
        }

        private void cmdValtDessert_Click(object sender, EventArgs e)
        {
            string selectedDessert = txtVal.Text;

            if (string.IsNullOrEmpty(selectedDessert))
            {
                txtVal.BackColor = System.Drawing.Color.White;
            }
            else
            {
                switch (selectedDessert)
                {
                    case "Äppelpaj":
                        txtVal.BackColor = System.Drawing.Color.Green;

                        break;
                    case "Chockladglass":
                        txtVal.BackColor = System.Drawing.Color.Blue;
                        break;
                    case "Frukt":
                        txtVal.BackColor = System.Drawing.Color.Pink;
                        break;
                    case "Grogg":
                        txtVal.BackColor = System.Drawing.Color.Yellow;
                        break;
                    case "Öl":
                        txtVal.BackColor = System.Drawing.Color.Brown;
                        break;
                    case "Vodka":
                        txtVal.BackColor = System.Drawing.Color.LightGray;
                        break;
                    case "Rökheroin":
                        txtVal.BackColor = System.Drawing.Color.DarkGray;
                        break;
                    case "Kokostoppar":
                        txtVal.BackColor = System.Drawing.Color.Orange;
                        break;

                    default:
                        txtVal.BackColor = System.Drawing.Color.Red;
                        break;
                }





            }
        }
    }
}

