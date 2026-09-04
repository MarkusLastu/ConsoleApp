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

namespace V2_Dag5_Fredagsgodis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Person> personer = new List<Person>();

        public MainWindow()
        {
            InitializeComponent();
            SkapaPersoner();
            cmbPersonPicker.ItemsSource = personer;
        }

        private void SkapaPersoner()
        {
            Gymmare markusL = new Gymmare("Markus L", 500)
            {
                SuperPower = "Finger Styrka: Trycker HÅRT på datortangenterna",
                SpecialAttack = "CapsLock-vrålet: Trycker in CapsLock med en sån enorm kraft att tryckvågen får motståndarens kod att sluta kompilera.",
                Specialisering = "Mekanisk Hållfasthet: Kan skriva tusentals rader kod på ett mekaniskt tangentbord utan att fingrarna tar slut på glykogen.",
                Weakness = "Merge Conflicts i gymmet: Blir helt handlingsförlamad om någon har lämnat kvar vikter på skivstången utan att städa sin branch först."
            };
            personer.Add(markusL);

            // lägg till fler gymmare / musiker etc här
        }

        private void cmbPersonPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbPersonPicker.SelectedItem is Person valdPerson)
            {
                lblInfo.Content = valdPerson.Presentera();
            }
        }

        private void btnSuperPower_Click(object sender, RoutedEventArgs e)
        {
            if (cmbPersonPicker.SelectedItem is Person valdPerson)
            {
                valdPerson.AnvandSuperkraft();
            }
        }

    }
}