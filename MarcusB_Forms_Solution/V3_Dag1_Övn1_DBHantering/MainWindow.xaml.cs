using System.Data.Common;
using System.Diagnostics;
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
using V3_Dag1_Övn1_DBHantering.Models;

namespace V3_Dag1_Övn1_DBHantering
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Globala variabler
        private readonly Supabase.Client _client;
        private List<Cat> cats;
        private List<Shelter> shelters;
        public List<Argument> ArgumentList = new List<Argument>();



        // MainWindow constructor - Programmet körs
        public MainWindow()
        {
            InitializeComponent();

            _client = new Supabase.Client(
                "https://hslfdhpruwakjtjjeliu.supabase.co",
                "sb_publishable_HiCLJR1gIrUCO5uM4_Z87A_l_nteqZS");
        }

        private async void Window_Loaded(
        object sender, RoutedEventArgs e)
        {
            await _client.InitializeAsync();
            await LoadCats();
            await LoadShelters();
        }

        // Ladda från DB
        private async Task LoadCats()
        {
            var result = await _client
                .From<Cat>()
                .Get();

            cats = result.Models;

            cats.Insert(0, new Cat());
        }

        private async Task LoadShelters()
        {
            var result = await _client
                .From<Shelter>()
                .Get();

            shelters = result.Models;

            shelters.Insert(0, new Shelter());
        }



        // Bygg upp selectsträngen i txtSelect.Text
        public void UpdateSelectText(List<Argument> queryArgumentList)
        {
            foreach (var value in queryArgumentList)
            {
                Debug.WriteLine(value);
            }

            txtSelect.Text = string.Join(
                "\nAND ",
                queryArgumentList.Select(a => a.ToString()));
        }





        private async Task<List<Cat>> RunSelect()
        {
            string expression = txtSelect.Text.Trim().ToLower();
            // Exempel: "age < 3"

            string[] conditions = expression.Split(" and ");
            string column;
            string operatorText;
            string value;
            Supabase.Postgrest.Constants.Operator op;

            var result = await _client
            .From<Cat>()
            .Select("*,Shelter(*)")
            .Get();

            var filteredResult = result;

            foreach (string condition in conditions)
            {
                string[] parts = expression.Split(' ');
                column = parts[0];
                operatorText = parts[1];
                value = parts[2];


                switch (operatorText)
                {
                    case "<": op = Supabase.Postgrest.Constants.Operator.LessThan; break;
                    case ">": op = Supabase.Postgrest.Constants.Operator.GreaterThan; break;
                    case "=": op = Supabase.Postgrest.Constants.Operator.Equals; break;
                    case "!=": op = Supabase.Postgrest.Constants.Operator.NotEqual; break;
                    case "<=": op = Supabase.Postgrest.Constants.Operator.LessThanOrEqual; break;
                    case ">=": op = Supabase.Postgrest.Constants.Operator.GreaterThanOrEqual; break;
                    case "like": op = Supabase.Postgrest.Constants.Operator.Like; break;

                    default: throw new Exception("Ogiltig operator");
                }
            }

            return result.Models;
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


        private void btnAddCondition_Click(object sender, RoutedEventArgs e)
        {
            string column = (cmbColumnType.SelectedItem as ComboBoxItem)?.Content?.ToString();
            string operatorType = (cmbOperatorType.SelectedItem as ComboBoxItem)?.Content?.ToString();
            string value = txtArgumentValue.Text;

            Argument argument = new Argument(column, operatorType, value);

            CreateArgumentList(argument);
        }




        public void CreateArgumentList(Argument incomingArgument)
        {
            ArgumentList.Add(incomingArgument);            
            UpdateSelectText(ArgumentList);

        }
    }
}