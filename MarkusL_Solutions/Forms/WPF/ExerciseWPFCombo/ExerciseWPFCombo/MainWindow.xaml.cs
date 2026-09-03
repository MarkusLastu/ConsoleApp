using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace ExerciseWPFCombo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillComboboxWithText();
        }

        private void cmdHamta_Click(object sender, RoutedEventArgs e)
        {
            string valdDessert = null;
            if (rbAlternativ1.IsChecked == true)
                valdDessert = rbAlternativ1.Content.ToString();
            else if (rbAlternativ2.IsChecked == true)
                valdDessert = rbAlternativ2.Content.ToString();
            else if (rbAlternativ3.IsChecked == true)
                valdDessert = rbAlternativ3.Content.ToString();

            MessageBox.Show("You voted for " + valdDessert);
        }

        public void FillComboboxWithText()
        {
            try
            {
                string filePath = @"C:\Projekt_GitHub\ConsoleApp\MarkusL_Solutions\Forms\FormsExtraFiles\dessert.txt";

                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        cmbVal.Items.Add(line);
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void cmbVal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string valdDessert = null;
            if (cmbVal.SelectedIndex > -1)
            {
                valdDessert = cmbVal.SelectedItem.ToString();
            }
            txtResultat.Text = "You voted for " + valdDessert;
        }
    }
}