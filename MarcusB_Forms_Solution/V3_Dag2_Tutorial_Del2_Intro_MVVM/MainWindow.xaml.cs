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
using V3_Dag2_Tutorial_Del2_Intro_MVVM.ViewModels;

namespace V3_Dag2_Tutorial_Del2_Intro_MVVM
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
            DataContext = new MainViewModel();
        }
    }

}