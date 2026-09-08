using Intro_MVVM.ViewModels;
using System.Windows;

namespace Intro_MVVM
{
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainViewModel();

            DataContext = _viewModel;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.InitializeAsync();
        }
    }
}