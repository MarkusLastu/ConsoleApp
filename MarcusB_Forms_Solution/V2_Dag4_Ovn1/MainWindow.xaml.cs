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

namespace V2_Dag4_Ovn1
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

        private bool validateInput(string input1, string input2)
        {
            if (string.IsNullOrWhiteSpace(input1) || string.IsNullOrWhiteSpace(input2))
            {
                MessageBox.Show("Vänligen fyll i båda talen innan du klickar på plus-knappen.");
                return false;
            }

            if (double.TryParse(input1, out _) && double.TryParse(input2, out _))
            {
                return true;
            }

            MessageBox.Show("Vänligen ange giltiga tal i båda fälten.");
            return false;
        }

        private void cmdPlus_Click(object sender, RoutedEventArgs e)
        {
            bool inputIsValid = validateInput(txtTal1.Text, txtTal2.Text);

            if (inputIsValid)
            {
                txtResultat.Text = (double.Parse(txtTal1.Text) + double.Parse(txtTal2.Text)).ToString();
            }
        }

        private void cmdMinus_Click(object sender, RoutedEventArgs e)
        {
            bool inputIsValid = validateInput(txtTal1.Text, txtTal2.Text);

            if (inputIsValid)
            {
                txtResultat.Text = (double.Parse(txtTal1.Text) - double .Parse(txtTal2.Text)).ToString();
            }
        }

        private void cmdGanger_Click(object sender, RoutedEventArgs e)
        {
            bool inputIsValid = validateInput(txtTal1.Text, txtTal2.Text);

            if (inputIsValid)
            {
                txtResultat.Text = (double.Parse(txtTal1.Text) * double.Parse(txtTal2.Text)).ToString();
            }
        }

        private void cmdDivision_Click(object sender, RoutedEventArgs e)
        {
            bool inputIsValid = validateInput(txtTal1.Text, txtTal2.Text);

            if (inputIsValid)
            {
                txtResultat.Text = (double.Parse(txtTal1.Text) / double.Parse(txtTal2.Text)).ToString();
            }
        }

        private void cmdAvsluta_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}