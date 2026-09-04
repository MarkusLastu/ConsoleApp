using System.Text;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.CodeDom;

namespace V2_Dag5_Fredagsgodis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            // Starta formuläret
            InitializeComponent();

            // Skapa personer och lägg till dem i listan
            Personer.CreateMarkusL();
            Personer.CreateNiklas();
            Personer.CreateMarcusB();

            // Bind listan till ComboBoxen
            cmbPersonPicker.ItemsSource = Personer.personLista;
        }

        

        

        private void cmbPersonPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbPersonPicker.SelectedItem is PersonClass valdPerson)
            {
                // lblInfo.Content = valdPerson.Presentera();
                txtInfo.Text = valdPerson.Presentera();
            }
        }

        private void btnSuperPower_Click(object sender, RoutedEventArgs e)
        {
            if (cmbPersonPicker.SelectedItem is PersonClass valdPerson)
            {
                valdPerson.AnvandSuperkraft();
            }
        }

    }
}