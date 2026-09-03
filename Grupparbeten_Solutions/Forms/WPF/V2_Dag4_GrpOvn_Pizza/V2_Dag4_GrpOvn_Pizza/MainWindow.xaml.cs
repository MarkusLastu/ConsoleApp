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

namespace V2_Dag4_GrpOvn_Pizza
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cmdBestall_Click(object sender, RoutedEventArgs e)
        {
            if (cmbPizza.SelectedIndex == -1 ||
               (rbSmall.IsChecked == false && rbMedium.IsChecked == false && rbLarge.IsChecked == false))
            {
                MessageBox.Show("Du måste välja både en pizza och en storlek innan du kan beställa!");
                return;
            }

            string valdPizza = cmbPizza.SelectedItem.ToString();
            string valdStorlek = "";
            int pris = 0;

            if (rbSmall.IsChecked == true)
            {
                valdStorlek = "Small";
                pris = 85;
                this.Background = Brushes.LightSkyBlue;
            }
            else if (rbMedium.IsChecked == true)
            {
                valdStorlek = "Medium";
                pris = 100;
                this.Background = Brushes.LightGreen;
            }
            else if (rbLarge.IsChecked == true)
            {
                valdStorlek = "Large";
                pris = 120;
                this.Background = Brushes.LightCoral;
            }

            txtResultat.Text = "Du beställde:\n" +
                               "Storlek: " + valdStorlek + ".\n" +
                               "Pizza: " + valdPizza + ".\n\n" +
                               "Totalpris: " + pris + " kr.";

            cmbPizza.SelectedIndex = -1;
            rbSmall.IsChecked = false;
            rbMedium.IsChecked = false;
            rbLarge.IsChecked = false;
        }
    }
}