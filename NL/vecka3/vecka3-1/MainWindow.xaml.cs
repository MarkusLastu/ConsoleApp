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
using vecka3_1.Models;

namespace vecka3_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Supabase.Client _client;
        public MainWindow()
        {

            _client = new Supabase.Client(
                "https://ezfckwjovbziivgdngge.supabase.co",
                "sb_publishable_bPfNWbHp5ProIAxBSAo2Ug_TyXN5n0m");

            InitializeComponent();
        }
        //        private async void Window_Loaded(object sender, RoutedEventArgs e)
        private async void Window_Loaded(
            object sender, RoutedEventArgs e)
 {
            await _client. InitializeAsync ();
            await LoadCats();
            await LoadShelters();
 }

        private async Task LoadCats()
        {
            var result = await _client
            .From<Cat>()
            .Get();
            Cats = result.Models;
            cmbCats.ItemsSource = Cats;
            cmbAge.ItemsSource = Cats;
            var properties = typeof(Cat)
            .GetProperties()
            .Where(p => p.GetCustomAttributes(typeof(ColumnAttribute),
           false).Any())
            .Select(p => p.Name)
            .ToList();
            cmbCatProperty.ItemsSource = properties;
        }
        private async Task LoadShelters()
        {
            var result = await _client
            .From<Shelter>()
            .Get();
            shelters = result.Models;
            cmbShelters.ItemsSource = shelters;
            var properties = typeof(Shelter)
            .GetProperties()
            .Where(p => p.GetCustomAttributes(typeof(ColumnAttribute), false).Any())
            .Select(p => p.Name)
            .ToList();
            cmbShelterProperty.ItemsSource = properties;

        }

        private async Task<List<Cat>> RunSelect()
        {
            string expression = txtSelect.Text.Trim();
            string[] conditions = expression.Split(" AND ");
            int? age = null;
            string city = null;
            foreach (string condition in conditions)
            {
                string[] parts = condition.Split(' ');

                string column = parts[0];
                string operatorText = parts[1];
                string value = parts[2];
                if (column == "age")
                {
                    age = int.Parse(value);
                }
                else if (column == "city")
                {
                    city = value;
                }
            }
            var result = await _client
            .From<Cat>()
            .Select("*, shelter:shelters(*)")
            .Get();
            List<Cat> cats = result.Models;
            List<Cat> Filteredcats = cats;
            if (age.HasValue)
            {
                Filteredcats = cats
                .Where(c => c.Age < age.Value)
                .ToList();
            }
            if (city != null)
            {
                Filteredcats = Filteredcats
                .Where(c => c.Shelter.City == city)
                .ToList();
            }
            return Filteredcats;
         
        }
        private async void btnRun_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Cat> cats = await RunSelect();
                txtResult.Text = "";
                foreach (Cat cat in cats)
                {
                    txtResult.Text +=
                    $"{cat.Name} - {cat.Age} år - {cat.Color}\n";
                }
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
        }
        private void cmbCatProperty_SelectionChanged(object sender,SelectionChangedEventArgs e)
        {
            if (cmbCatProperty.SelectedItem != null)
            {
                var selected = cmbCatProperty.SelectedItem.ToString();
                var property = typeof(Cat).GetProperty(selected);
                txtSelect.Text += selected.ToLower();
                cmbCatValue.ItemsSource = cats
                .Select(c => property.GetValue(c)?.ToString())
                .Distinct()
                .ToList();
            }
        }
        private void cmbShelterProperty_SelectionChanged(object sender,
       SelectionChangedEventArgs e)
        {
            if (cmbShelterProperty.SelectedItem != null)
            {
                var selected = cmbShelterProperty.SelectedItem.ToString();
                var property = typeof(Shelter).GetProperty(selected);
                txtSelect.Text += selected.ToLower();
                cmbShelterValue.ItemsSource = shelters
                .Select(c => property.GetValue(c)?.ToString())
                .Distinct()
                .ToList();
            }
        }
        private async void btnRun_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Cat> cats = await RunSelect();
                txtResult.Text = "";
                foreach (Cat cat in cats)
                {
                    txtResult.Text +=
                    $" {cat.Name} - {cat.Age} år - {cat.Color} \n";
                }
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
        }
    }
}
    
