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
using System.Diagnostics;

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
            
            List<string> pizzaTypes = new List<string>();
            pizzaTypes = ReadFile.ReadFileToList("PizzaTypes.txt");
            List<Pizza> pizzas = ReadFile.CreatePizzaList(pizzaTypes);
            cmbPizza.Items.Clear();
            cmbPizza_FillDropdownPizzaTypes(pizzas);
        }

        private void cmbPizza_FillDropdownPizzaTypes(List<Pizza> pizzas)
        {
            foreach (Pizza pizza in pizzas)
            {
                cmbPizza.Items.Add(pizza);
            }
        }

        public void cmbPizza_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbPizza.SelectedIndex != -1)
            {
                string selectedPizza = cmbPizza.SelectedItem.ToString();
            }
        }

        private void cmdHamta_Click(object sender, RoutedEventArgs e)
        {
            string Pizzastorlek = null;
            if (rbSmall.IsChecked == true)
            {
                Pizzastorlek = rbSmall.Content.ToString();
            }
            else if (rbLarge.IsChecked == true)
            {
                Pizzastorlek = rbLarge.Content.ToString();
            }
            else if (rbExtraLarge.IsChecked == true)
            {
                Pizzastorlek = rbExtraLarge.Content.ToString();
            }
        }

        private void cmdBestall_Click(object sender, RoutedEventArgs e)
        {
            if (cmbPizza.SelectedIndex == -1 ||
               (rbSmall.IsChecked == false && rbLarge.IsChecked == false && rbExtraLarge.IsChecked == false))
            {
                MessageBox.Show("Du måste välja både en pizza och en storlek innan du kan beställa!");
                return;
            }

            Pizza selectedPizza = (Pizza)cmbPizza.SelectedItem;
            string valdPizza = selectedPizza.Name;
            int prisPizza = selectedPizza.Price;
            Debug.WriteLine($"Vald pizza: {valdPizza}, Pris: {prisPizza}");
            string valdStorlek = "";
            int prisStorlek = 0;

            if (rbSmall.IsChecked == true)
            {
                valdStorlek = "Small";
                prisStorlek = 0;
                //this.Background = Brushes.LightSkyBlue;
            }
            else if (rbLarge.IsChecked == true)
            {
                valdStorlek = "Large";
                prisStorlek = 20;
                //this.Background = Brushes.LightGreen;
            }
            else if (rbExtraLarge.IsChecked == true)
            {
                valdStorlek = "Extra Large";
                prisStorlek = 50;
                //this.Background = Brushes.LightCoral;
            }

            txtResultat.Text = "Du beställde:\n" +
                               "Storlek: " + valdStorlek + ".\n" +
                               "Pizza: " + valdPizza + ".\n\n" +
                               "Totalpris: " + (prisPizza + prisStorlek) + " kr.";

            cmbPizza.SelectedIndex = -1;
            rbSmall.IsChecked = false;
            rbLarge.IsChecked = false;
            rbExtraLarge.IsChecked = false;
        }
    }
}