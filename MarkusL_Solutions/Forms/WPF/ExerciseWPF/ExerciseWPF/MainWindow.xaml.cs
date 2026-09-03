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

namespace ExerciseWPF
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

        private void cmdPlus_Click(object sender, RoutedEventArgs e)
        {
            double firstNum = double.Parse(txtTal1.Text);
            double secondNum = double.Parse(txtTal2.Text);
            txtResultat.Text = (firstNum + secondNum).ToString();
        }

        private void cmdMinus_Click(object sender, RoutedEventArgs e)
        {
            double firstNum = double.Parse(txtTal1.Text);
            double secondNum = double.Parse(txtTal2.Text);
            txtResultat.Text = (firstNum - secondNum).ToString();
        }

        private void cmdGanger_Click(object sender, RoutedEventArgs e)
        {
            double firstNum = double.Parse(txtTal1.Text);
            double secondNum = double.Parse(txtTal2.Text);
            txtResultat.Text = (firstNum * secondNum).ToString();
        }

        private void cmdDivision_Click(object sender, RoutedEventArgs e)
        {
            double firstNum = double.Parse(txtTal1.Text);
            double secondNum = double.Parse(txtTal2.Text);
            txtResultat.Text = (firstNum / secondNum).ToString();
        }

        private void cmdAvsluta_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}