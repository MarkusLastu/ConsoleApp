using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using System.Windows;


namespace WpfMVVM_dag3
{
    public partial class MainWindow : Window 
    { 
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.MainViewModel();
        }
    }



}

