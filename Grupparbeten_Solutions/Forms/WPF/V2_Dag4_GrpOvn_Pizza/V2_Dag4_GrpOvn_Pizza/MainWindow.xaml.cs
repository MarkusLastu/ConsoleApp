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
        private void cmdHamta_Click(object sender, RoutedEventArgs e)
        {
            string Pizzastorlek = null;
            if (rbAlternativ1.IsChecked == true)
            {
                Pizzastorlek = rbAlternativ1.Content.ToString();
            }
            else if (rbAlternativ2.IsChecked == true)
            {
                Pizzastorlek = rbAlternativ2.Content.ToString();
            }
            else if (rbAlternativ3.IsChecked == true)
            {
                Pizzastorlek = rbAlternativ3.Content.ToString();
            }
            MessageBox.Show("You voted for " + Pizzastorlek);

        }
    }
}