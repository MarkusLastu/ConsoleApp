using System;
using System.IO;
using System.Windows.Forms;

namespace MarkusL_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Anropas när programmet startar för att fylla rullgardinsmenyn
            FillArrayWithValues();
        }

        // --- DEL 1: Knappar och Textruta ---
        private void cmdStang_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmdDolj_Click(object sender, EventArgs e)
        {
            lblVisa.Text = "Det är väl inte så svårt";
        }

        private void cmdVisa_Click(object sender, EventArgs e)
        {
            // Visar texten från textrutan, annars en standardtext
            if (string.IsNullOrWhiteSpace(txtText.Text))
                lblVisa.Text = "Välkommen att programmera i C#";
            else
                lblVisa.Text = txtText.Text;
        }

        // --- DEL 2: Switch-sats och filläsning ---
        private void cmdBeslut_Click(object sender, EventArgs e)
        {
            string input = txtVal.Text;
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
                // Sökväg till din fil
                string filePath = @"C:\Projekt_GitHub\ConsoleApp\MarkusL_Forms_Solution\MarkusL_Forms\ExtraFiles\dessert.txt";

                using StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();

                while (line != null)
                {
                    cmbDesert.Items.Add(line);
                    line = sr.ReadLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fel vid inläsning av fil: " + ex.Message);
            }
        }

        private void cmbDesert_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDesert.SelectedItem != null)
            {
                txtVal.Text = cmbDesert.SelectedItem.ToString();
            }
            else
            {
                txtVal.Text = string.Empty;
            }
        }
    }
}