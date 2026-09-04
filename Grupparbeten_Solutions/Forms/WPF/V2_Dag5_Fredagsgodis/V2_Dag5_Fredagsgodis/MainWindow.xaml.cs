using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
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
using static V2_Dag5_Fredagsgodis.Personer;

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
            string jsonText = File.ReadAllText("personInfo.json");
            Debug.WriteLine(jsonText);
            Personer.CreatePersonsFromJson(jsonText);

            // Bind listan till ComboBoxen
            cmbPersonPicker.ItemsSource = Personer.personLista;

        }


        private void cmbPersonPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbPersonPicker.SelectedItem is PersonClass valdPerson)
            {
                // lblInfo.Content = valdPerson.Presentera();
                txtInfo.Text = valdPerson.Presentera();
                imgPerson.Source = new BitmapImage(new Uri(valdPerson.Image, UriKind.RelativeOrAbsolute));
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