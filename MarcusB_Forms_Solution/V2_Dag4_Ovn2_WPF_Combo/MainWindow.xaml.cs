using System.Diagnostics;
using System.IO;
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

namespace V2_Dag4_Ovn2_WPF_Combo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillComboBoxWithText();
        }

        private void cmdHamta_Click(object sender, RoutedEventArgs e)
        {
            string valdDessert = null;
            if (rbAlternativ1.IsChecked == true)
            {
                valdDessert = rbAlternativ1.Content.ToString();
            }
            else if (rbAlternativ2.IsChecked == true)
            {
                valdDessert = rbAlternativ2.Content.ToString();
            }
            else if (rbAlternativ3.IsChecked == true)
            {
                valdDessert = rbAlternativ3.Content.ToString();
            }
            MessageBox.Show("You voted for " + valdDessert);
        }

        public void FillComboBoxWithText()
        {
            try
            {
                string filePath = System.IO.Path.Combine(
                    AppContext.BaseDirectory,
                        "ImportFiler",
                        "dessert.txt");
                Debug.WriteLine(filePath);
                using StreamReader sr = new StreamReader(filePath);

                string line = sr.ReadLine();
                
                while (line != null)
                {
                    cmbVal.Items.Add(line);
                    line = sr.ReadLine();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cmbVal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string valdDessert = cmbVal.SelectedItem as string;
            if(cmbVal.SelectedIndex >= 0)
            {
                txtResultat.Text = "You voted for " + valdDessert;
            }
            else
            {
                txtResultat.Text = "Du måste välja ett alternativ";
            }
        }
    }
}